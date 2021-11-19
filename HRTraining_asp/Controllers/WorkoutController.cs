using AutoMapper;
using HRTraining.Domain.Entities;
using HRTraining_asp.Domain.Entities.Workouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRDbContext = HRTraining.Data.HRDbContext;

namespace HRTraining.Domain.Controllers
{
    [Route("api/workouts")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly HRDbContext _dbContext;
        private readonly IMapper _mapper;

        public WorkoutController(HRDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutModel>>> GetWorkouts(Guid userId)
        {
            // Change to searching, filtering, pagination
            // Get by userid
            // var profile = _dbContext.Set<Profile>().Where(p => p.ID == userId).Include(p => p.Workouts).FirstOrDefault();
            // var models = _mapper.Map<WorkoutHistoryModel[]>(profile.Workouts);
            var workouts = _dbContext.Set<Workout>();
            var models = _mapper.Map<WorkoutModel[]>(workouts);

            return Ok(models);
        }

        // Change ActionResult to work with swagger
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutModel>> GetWorkout(Guid id)
        {
            var workout = _dbContext.Set<Workout>().Where(x => x.ID == id).Include(w => w.Activities).FirstOrDefault();
            var model = _mapper.Map<WorkoutModel>(workout);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWorkout(WorkoutModel workout)
        {
            var entity = _mapper.Map<Workout>(workout);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return Ok(entity.ID);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkout(Guid id)
        {
            var workout = _dbContext.Set<Workout>().Include(w => w.Activities).Where(x => x.ID == id).FirstOrDefault();
            _dbContext.Remove(workout);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WorkoutModel>> UpdateWorkout(Guid id, WorkoutModel model)
        {
            var entity = _dbContext.Set<Workout>().Include(w => w.Activities).ThenInclude(w => w.Targets).FirstOrDefault(x => x.ID == id);
            var goal = _mapper.Map(model, entity);
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return Ok(_mapper.Map<WorkoutModel>(entity));
        }
    }
}
