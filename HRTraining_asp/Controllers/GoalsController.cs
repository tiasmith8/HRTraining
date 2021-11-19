using AutoMapper;
using HRTraining.Data;
using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Goals;
using HRTraining_asp.Domain.Entities.Goals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Controllers
{
    [Route("api/goals")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly HRDbContext _dbContext;

        public GoalsController(IMapper mapper, HRDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalModel>>> GetGoals()
        {
            var goals = _dbContext.Set<Goal>();
            var models = _mapper.Map<GoalModel[]>(goals);

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalModel>> GetGoal(Guid id)
        {
            var goal = _dbContext.Set<Goal>().Where(x => x.ID == id).FirstOrDefault();
            var model = _mapper.Map<GoalModel>(goal);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateGoal(GoalModel goal)
        {
            var entity = _mapper.Map<Goal>(goal);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return Ok(entity.ID);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGoal(Guid id)
        {
            var goal = _dbContext.Set<Goal>().FirstOrDefault(x => x.ID == id);
            _dbContext.Remove(goal);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GoalModel>> UpdateGoal(GoalModel model, Guid id)
        {
            var entity = _dbContext.Set<Goal>().FirstOrDefault(x => x.ID == id);
            var goal = _mapper.Map(model, entity);
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return Ok(_mapper.Map<GoalModel>(entity));
        }
    }
}
