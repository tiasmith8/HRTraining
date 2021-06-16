using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
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

        public ProfileController(ProfileContext profileContext, DeviceContext deviceContext)
        {
            _profileContext = profileContext;
            _deviceContext = deviceContext;
            _profileContext.Database.EnsureCreated();
        }

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
    }
}
