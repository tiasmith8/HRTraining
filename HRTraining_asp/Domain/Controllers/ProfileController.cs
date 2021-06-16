using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProfile(Profile profile)
        {
            await _profileContext.UpdateAsync(profile);
            return Ok(profile);
        }

        [HttpGet("{id}/devices")]
        public async Task<ActionResult> GetDevices(Guid id)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            return Ok(profile.Devices);
        }

        [HttpPost("{id}/devices")]
        public async Task<ActionResult> AddDevice(Guid id, Device device)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            await _profileContext.AddDeviceToProfile(id, device);
            return Ok(profile);
        }

        [HttpDelete("{id}/devices")]
        public async Task<ActionResult> DeleteDevice(Guid id, Guid deviceId)
        {
            var profile = await _profileContext.GetByIdAsync<Profile>(id);
            var device = await _deviceContext.GetByIdAsync<Device>(deviceId);
            profile.Devices.Remove(device);
            return Ok(profile);
        }
    }
}
