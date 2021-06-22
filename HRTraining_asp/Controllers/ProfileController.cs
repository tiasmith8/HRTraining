using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities.Workouts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRTraining.Domain.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileContext _profileContext;
        private readonly DeviceContext _deviceContext;
        private readonly GoalsContext _goalsContext;
        private readonly WorkoutContext _workoutContext;
        private readonly WorkoutHistoryContext _workoutHistoryContext;

        public ProfileController(ProfileContext profileContext
            , DeviceContext deviceContext
            , GoalsContext goalsContext
            , WorkoutContext workoutContext
            , WorkoutHistoryContext workoutHistoryContext)
        {
            _profileContext = profileContext;
            _deviceContext = deviceContext;
            _goalsContext = goalsContext;
            _workoutContext = workoutContext;
            _workoutHistoryContext = workoutHistoryContext;
        }

        #region Profile

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Profile>>> GetProfiles()
        {
            var profiles = _profileContext.Queryable<Profile>();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profile>> GetProfile(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProfile(Profile profile)
        {
            await _profileContext.CreateAsync(profile);
            return Ok(profile.Id);
        }

        /// <summary>
        /// Delete a Profile
        /// </summary>
        /// <param name="id">Profile Guid</param>
        /// <returns>200 Ok if the profile is deleted</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfile(Guid id)
        {
            await _profileContext.DeleteByIdAsync(id);
            return Ok();
        }

        /// <summary>
        /// Update user's profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<Profile>> UpdateProfile(Profile profile)
        {
            await _profileContext.UpdateAsync(profile);
            return Ok(profile);
        }

        #endregion

        #region Devices

        [HttpGet("{id}/devices")]
        public async Task<ActionResult<IEnumerable<Device>>> GetProfileDevices(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile.Devices);
        }

        [HttpPost("{id}/devices")]
        public async Task<ActionResult<Guid>> AddDeviceToProfile(Guid id, Device device)
        {
            await _profileContext.AddDeviceToProfile(id, device);
            return Ok(device.Id);
        }

        [HttpDelete("{id}/devices/{deviceId}")]
        public async Task<ActionResult> DeleteDeviceFromProfile(Guid id, Guid deviceId)
        {
            await _deviceContext.DeleteByIdAsync(deviceId);
            return NoContent();
        }

        [HttpPut("{id}/devices/{deviceId}")]
        public async Task<ActionResult<Device>> UpdateProfileDevice(Guid id, Guid deviceId, Device device)
        {
            await _deviceContext.UpdateAsync(device);
            return Ok(device);
        }

        [HttpGet("{id}/devices/{deviceId}")]
        public async Task<ActionResult<Device>> GetProfileDevice(Guid id, Guid deviceId)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            var device = profile.Devices.Where(d => d.Id == deviceId).FirstOrDefault();

            return Ok(device);
        }

        #endregion

        #region Goals
        [HttpGet("{id}/goals")]
        public async Task<ActionResult<IEnumerable<Goal>>> GetProfileGoals(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile.Goals);
        }

        [HttpPost("{id}/goals")]
        public async Task<ActionResult<Guid>> CreateProfileGoal(Guid id, Goal goal)
        {
            await _profileContext.AddGoalToProfile(id, goal);
            //await _goalsContext.CreateAsync(goal, id);
            return Ok(goal.Id);
        }

        [HttpDelete("{id}/goals/{goalId}")]
        public async Task<ActionResult> DeleteProfileGoal(Guid id, Guid goalId)
        {
            await _goalsContext.DeleteByIdAsync(goalId);
            return NoContent();
        }

        [HttpPut("{id}/goals/{goalId}")]
        public async Task<ActionResult<Goal>> UpdateProfileGoal(Guid id, Guid goalId, Goal goal)
        {
            await _goalsContext.UpdateAsync(goal);
            return Ok(goal);
        }

        [HttpGet("{id}/goals/{goalId}")]
        public async Task<ActionResult<Goal>> GetProfileGoal(Guid id, Guid goalId)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            var goal = profile.Goals.Where(d => d.Id == goalId).FirstOrDefault();

            return Ok(goal);
        }
        #endregion

        #region Workouts
        [HttpGet("{id}/workouts")]
        public async Task<ActionResult<IEnumerable<Workout>>> GetProfileWorkouts(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile.Workouts);
        }

        [HttpPost("{id}/workouts")]
        public async Task<ActionResult<Guid>> CreateProfileWorkout(Guid id, Workout workout)
        {
            await _profileContext.AddWorkoutToProfile(id, workout);
            return Ok(workout.Id);
        }

        [HttpDelete("{id}/workouts/{workoutId}")]
        public async Task<ActionResult> DeleteProfileWorkout(Guid id, Guid workoutId)
        {
            await _workoutContext.DeleteByIdAsync(workoutId);
            return NoContent();
        }

        [HttpPut("{id}/workouts/{workoutId}")]
        public async Task<ActionResult<Workout>> UpdateProfileWorkout(Guid id, Guid workoutId, Workout workout)
        {
            await _workoutContext.UpdateAsync(workout);
            return Ok(workout);
        }

        [HttpGet("{id}/workouts/{workoutId}")]
        public async Task<ActionResult<Workout>> GetProfileWorkout(Guid id, Guid workoutId)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            var workout = profile.Workouts.Where(d => d.Id == workoutId).FirstOrDefault();

            return Ok(workout);
        }

        #endregion

        #region WorkoutHistory
        [HttpGet("{id}/workoutHistory")]
        public async Task<ActionResult<IEnumerable<WorkoutHistory>>> GetProfileWorkoutHistory(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile.WorkoutHistory);
        }

        [HttpPost("{id}/workoutHistory")]
        public async Task<ActionResult<Guid>> CreateProfileWorkoutHistory(Guid id, WorkoutHistory workoutHistory)
        {
            await _profileContext.AddWorkoutHistoryToProfile(id, workoutHistory);
            return Ok(workoutHistory.Id);
        }

        [HttpDelete("{id}/workoutHistory/{workoutHistoryId}")]
        public async Task<ActionResult> DeleteProfileWorkoutHistory(Guid id, Guid workoutHistoryId)
        {
            await _workoutHistoryContext.DeleteByIdAsync(workoutHistoryId);
            return NoContent();
        }

        [HttpPut("{id}/workoutHistory/{workoutHistoryId}")]
        public async Task<ActionResult<WorkoutHistory>> UpdateProfileWorkoutHistory(Guid id, Guid workoutHistoryId, WorkoutHistory workoutHistory)
        {
            await _workoutHistoryContext.UpdateAsync(workoutHistory);
            return Ok(workoutHistory);
        }

        [HttpGet("{id}/workoutHistory/{workoutHistoryId}")]
        public async Task<ActionResult<WorkoutHistory>> GetProfileWorkoutHistory(Guid id, Guid workoutHistoryId)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            var workoutHistory = profile.WorkoutHistory.Where(d => d.Id == workoutHistoryId).FirstOrDefault();

            return Ok(workoutHistory);
        }

        #endregion

    }
}
