using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRTraining.Domain.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly WorkoutContext _workoutContext;

        public HomeController(WorkoutContext workoutContext)
        {
            _workoutContext = workoutContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Workout>>> GetUserData(Guid userId)
        {
            // Change to searching, filtering, pagination
            // Get my userid
            var workouts = _workoutContext.Queryable<Workout>();
            return Ok(workouts);
        }

        // Change ActionResult to work with swagger
        [HttpGet("{id}")]
        public async Task<ActionResult<Workout>> GetWorkout(Guid id)
        {
            var workout = await _workoutContext.GetByIdAsync<Workout>(id);
            return Ok(workout);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWorkout(Workout workout)
        {
            await _workoutContext.CreateAsync(workout);
            return Ok();
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
            return Ok();
        }

    }
}
