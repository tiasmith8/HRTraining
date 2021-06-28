using AutoMapper;
using HRTraining.Data;
using HRTraining.Domain.Entities.Activities;
using HRTraining_asp.Domain.Entities.Activities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Controllers
{
    [Route("api/activities")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

        public ActivityController(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActivityModel>>> GetActivities()
        {
            var activities = _dbContext.Set<Activity>();
            var models = _mapper.Map<ActivityModel[]>(activities);

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityModel>> GetActivity(Guid id)
        {
            var activity = _dbContext.Set<Activity>().Where(x => id == x.ID).FirstOrDefault();
            var model = _mapper.Map<ActivityModel>(activity);
            
            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateActivity(ActivityModel activity)
        {
            var entity = _mapper.Map<Activity>(activity);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return Ok(entity.ID);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id)
        {
            var activity = _dbContext.Set<Activity>().FirstOrDefault(x => id == x.ID);
            _dbContext.Remove(activity);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ActivityModel>> UpdateActivity(ActivityModel model, Guid id)
        {
            var entity = _dbContext.Set<Activity>().FirstOrDefault(x => x.ID == id);
            var activity = _mapper.Map(model, entity);

            _dbContext.Update(activity);
            await _dbContext.SaveChangesAsync();

            return Ok(_mapper.Map<ActivityModel>(entity));
        }
    }
}
