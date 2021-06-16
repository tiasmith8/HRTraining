using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace HRTraining.Domain.Controllers
{
    [Route("api/workouts")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly WorkoutContext _workoutContext;

        public WorkoutController(WorkoutContext workoutContext)
        {
            _workoutContext = workoutContext;
            _workoutContext.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetUserWorkouts(Guid userId)
        {
            // Change to searching, filtering, pagination
            // Get by userid
            var workouts = _workoutContext.Queryable<Workout>();
            return Ok(workouts);
        }

        // Change ActionResult to work with swagger
        [HttpGet("{id}")]
        public async Task<ActionResult> GetWorkout(Guid id)
        {
            var workout = await _workoutContext.GetByIdAsync<Workout>(id);
            return Ok(workout);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWorkout(Workout workout)
        {
            await _workoutContext.CreateAsync(workout);
            return Ok(workout.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkout(Guid id)
        {
            await _workoutContext.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWorkout(Workout workout)
        {
            await _workoutContext.UpdateAsync(workout);
            return Ok(workout);
        }
    }
}
