using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Workouts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Controllers
{
    [Route("api/profile/{profileId}/workoutHistory/")]
    [ApiController]
    public class WorkoutHistoryController : ControllerBase
    {
        private readonly WorkoutHistoryContext _workoutHistoryContext;
        private readonly ProfileContext _profileContext;

        public WorkoutHistoryController(WorkoutHistoryContext workoutHistoryContext, ProfileContext profileContext)
        {
            _workoutHistoryContext = workoutHistoryContext;
            _profileContext = profileContext;
            _workoutHistoryContext.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetWorkoutHistories(Guid profileId)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(profileId);
            var workoutHistories = profile.WorkoutHistory;
            return Ok(workoutHistories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetWorkoutHistory(Guid profileId, Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(profileId);
            var workoutHistory = profile.WorkoutHistory.Where(w => w.Id == id);
            return Ok(workoutHistory);
        }

        [HttpPost]
        public async Task<ActionResult> CreateWorkoutHistory(Guid profileId, WorkoutHistory workoutHistory)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(profileId);
            await _workoutHistoryContext.CreateAsync(workoutHistory);
            return Ok(workoutHistory.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkoutHistory(Guid profileId, Guid id)
        {
            await _workoutHistoryContext.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWorkoutHistory(Guid profileId, WorkoutHistory workoutHistory)
        {
            await _workoutHistoryContext.UpdateAsync(workoutHistory);
            return Ok(workoutHistory);
        }
    }
}
