using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Goals;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public ProfileController(ProfileContext profileContext, DeviceContext deviceContext
            , GoalsContext goalsContext)
        {
            _profileContext = profileContext;
            _deviceContext = deviceContext;
            _goalsContext = goalsContext;
        }

        #region Profile

        [HttpGet]
        public async Task<ActionResult> GetProfiles()
        {
            var profiles = _profileContext.Queryable<Profile>();
            return Ok(profiles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProfile(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProfile(Profile profile)
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
        public async Task<ActionResult> UpdateProfile(Profile profile)
        {
            await _profileContext.UpdateAsync(profile);
            return Ok(profile);
        }

        #endregion

        #region Devices

        [HttpGet("{id}/devices")]
        public async Task<ActionResult> GetProfileDevices(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile.Devices);
        }

        [HttpPost("{id}/devices")]
        public async Task<ActionResult> AddDeviceToProfile(Guid id, Device device)
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
        public async Task<ActionResult> UpdateProfileDevice(Guid id, Guid deviceId, Device device)
        {
            await _deviceContext.UpdateAsync(device);
            return Ok(device);
        }

        [HttpGet("{id}/devices/{deviceId}")]
        public async Task<ActionResult> GetProfileDevice(Guid id, Guid deviceId)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            var device = profile.Devices.Where(d => d.Id == deviceId).FirstOrDefault();

            return Ok(device);
        }

        #endregion 



        [HttpGet("{id}/goals")]
        public async Task<ActionResult> GetProfileGoals(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile.Goals);
        }

        [HttpPost("{id}/goals")]
        public async Task<ActionResult> CreateProfileGoal(Guid id, Goal goal)
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
        public async Task<ActionResult> UpdateProfileGoal(Guid id, Guid goalId, Goal goal)
        {
            await _goalsContext.UpdateAsync(goal);
            return Ok(goal);
        }

        [HttpGet("{id}/goals/{goalId}")]
        public async Task<ActionResult> GetProfileGoal(Guid id, Guid goalId)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            var goal = profile.Goals.Where(d => d.Id == goalId).FirstOrDefault();

            return Ok(goal);
        }


    }
}
