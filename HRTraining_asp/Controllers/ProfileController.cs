using AutoMapper;
using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Goals;
using HRTraining.Domain.Entities.Workouts;
using HRTraining_asp.Domain.Entities;
using HRTraining_asp.Domain.Entities.Goals;
using HRTraining_asp.Domain.Entities.Workouts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRDbContext = HRTraining.Data.HRDbContext;
using Profile = HRTraining.Domain.Entities.Profile;

namespace HRTraining.Domain.Controllers
{
    [Route("api/profiles")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly HRDbContext _dbContext;

        public ProfileController(IMapper mapper, HRDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        #region Profile

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfileModel>>> GetProfiles()
        {
            var profiles = _dbContext.Set<Profile>();
            var mapped = _mapper.Map<ProfileModel[]>(profiles);

            return Ok(mapped);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileModel>> GetProfile(Guid id)
        {
            var profileEntity = _dbContext.Set<Profile>().Where(x => x.ID == id)
                .Include(p => p.Devices)
                .Include(p => p.Workouts).ThenInclude(p => p.Activities).ThenInclude(p => p.Targets)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .Include(p => p.Goals)
                .FirstOrDefault();

            var model = _mapper.Map<ProfileModel>(profileEntity);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateProfile(ProfileModel profile)
        {
            var entity = _mapper.Map<Profile>(profile);
            await _dbContext.AddAsync(entity);
            _dbContext.SaveChanges();

            return Ok(entity.ID);
        }

        /// <summary>
        /// Delete a Profile
        /// </summary>
        /// <param name="id">Profile Guid</param>
        /// <returns>200 Ok if the profile is deleted</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProfile(Guid id)
        {
            var profile = _dbContext.Set<Profile>()
                .Include(p => p.Devices)
                .Include(p => p.Workouts).ThenInclude(p => p.Activities).ThenInclude(p => p.Targets)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .Include(p => p.Goals)
                .FirstOrDefault(x => x.ID == id);

            _dbContext.Remove(profile);
            _dbContext.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Update user's profile
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ProfileModel>> UpdateProfile(ProfileModel model, Guid id)
        {
            var entity = _dbContext.Set<Profile>()
                .Include(p => p.Devices)
                .Include(p => p.Workouts).ThenInclude(p => p.Activities).ThenInclude(p => p.Targets)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .Include(p => p.Goals)
                .FirstOrDefault(x => x.ID == id);

            var goal = _mapper.Map(model, entity);
            _dbContext.Update(entity);
            _dbContext.SaveChanges();

            return Ok(_mapper.Map<ProfileModel>(entity));
        }

        #endregion

        #region Settings

        [HttpGet("{id}/settings")]
        public async Task<ActionResult<IEnumerable<SettingsModel>>> GetProfileSettings(Guid id)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Settings).FirstOrDefault();
            var model = _mapper.Map<Settings>(profile.Settings);

            return Ok(model);
        }

        [HttpPost("{id}/settings")]
        public async Task<ActionResult<Guid>> AddSettingsToProfile(Guid id, SettingsModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Settings).FirstOrDefault();
            var entity = _mapper.Map<Settings>(model);
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            profile.Settings = entity;

            _dbContext.Update(profile);
            _dbContext.SaveChanges();

            return Ok(entity.ID);
        }

        //[HttpDelete("{id}/settings/{settingsId}")]
        //public async Task<ActionResult> DeleteSettingsFromProfile(Guid id, Guid settingsId)
        //{
        //    var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Settings).FirstOrDefault();
        //    var settings = _dbContext.Set<Settings>().Where(d => d.ID == settingsId).FirstOrDefault();
        //    _dbContext.Remove(settings);
        //    _dbContext.SaveChanges();

        //    return NoContent();
        //}

        [HttpPut("{id}/settings/{settingsId}")]
        public async Task<ActionResult<DeviceModel>> UpdateProfileSettings(Guid id, Guid settingsId, SettingsModel model)
        {
            var entity = _dbContext.Set<Settings>().Where(s => s.ID == settingsId).FirstOrDefault();
            var settings = _mapper.Map(model, entity);
            _dbContext.Update(settings);
            await _dbContext.SaveChangesAsync();

            return Ok(_mapper.Map<SettingsModel>(entity));
        }

        [HttpGet("{id}/settings/{settingsId}")]
        public async Task<ActionResult<DeviceModel>> GetProfileSettings(Guid id, Guid deviceId)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Settings).FirstOrDefault();
            var model = _mapper.Map<Settings>(profile.Settings);

            return Ok(model);
        }
        #endregion

        #region Devices

        [HttpGet("{id}/devices")]
        public async Task<ActionResult<IEnumerable<DeviceModel>>> GetProfileDevices(Guid id)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Devices).FirstOrDefault();
            var models = _mapper.Map<DeviceModel[]>(profile.Devices);

            return Ok(models);
        }

        [HttpPost("{id}/devices")]
        public async Task<ActionResult<Guid>> AddDeviceToProfile(Guid id, DeviceModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Devices).FirstOrDefault();
            var entity = _mapper.Map<Device>(model);
            profile.Devices.Add(entity);
            _dbContext.Update(profile);
            _dbContext.SaveChanges();

            return Ok(entity.ID);
        }

        [HttpDelete("{id}/devices/{deviceId}")]
        public async Task<ActionResult> DeleteDeviceFromProfile(Guid id, Guid deviceId)
        {
            var device = _dbContext.Set<Device>().Where(d => d.ID == deviceId).FirstOrDefault();
            _dbContext.Remove(device);
            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/devices/{deviceId}")]
        public async Task<ActionResult<DeviceModel>> UpdateProfileDevice(Guid id, Guid deviceId, DeviceModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Devices).FirstOrDefault();
            var entity = profile.Devices.Where(d => d.ID == deviceId).FirstOrDefault();
            var device = _mapper.Map(model, entity);
            _dbContext.Update(device);
            _dbContext.SaveChanges();

            return Ok(_mapper.Map<DeviceModel>(entity));
        }

        [HttpGet("{id}/devices/{deviceId}")]
        public async Task<ActionResult<DeviceModel>> GetProfileDevice(Guid id, Guid deviceId)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Devices).FirstOrDefault();
            var device = profile.Devices.Where(d => d.ID == deviceId).FirstOrDefault();
            var model = _mapper.Map<DeviceModel>(device);

            return Ok(model);
        }

        #endregion

        #region Goals
        [HttpGet("{id}/goals")]
        public async Task<ActionResult<IEnumerable<GoalModel>>> GetProfileGoals(Guid id)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Goals).FirstOrDefault();
            var models = _mapper.Map<GoalModel[]>(profile.Goals);

            return Ok(models);
        }

        [HttpPost("{id}/goals")]
        public async Task<ActionResult<Guid>> CreateProfileGoal(Guid id, GoalModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Goals).FirstOrDefault();
            var entity = _mapper.Map<Goal>(model);
            profile.Goals.Add(entity);
            _dbContext.Update(profile);
            _dbContext.SaveChanges();

            return Ok(entity.ID);
        }

        [HttpDelete("{id}/goals/{goalId}")]
        public async Task<ActionResult> DeleteProfileGoal(Guid id, Guid goalId)
        {
            var goal = _dbContext.Set<Goal>().Where(d => d.ID == goalId).FirstOrDefault();
            _dbContext.Remove(goal);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/goals/{goalId}")]
        public async Task<ActionResult<GoalModel>> UpdateProfileGoal(Guid id, Guid goalId, GoalModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Goals).FirstOrDefault();
            var entity = profile.Goals.Where(d => d.ID == goalId).FirstOrDefault();
            var goal = _mapper.Map(model, entity);
            _dbContext.Update(goal);
            _dbContext.SaveChanges();

            return Ok(_mapper.Map<GoalModel>(entity));
        }

        [HttpGet("{id}/goals/{goalId}")]
        public async Task<ActionResult<GoalModel>> GetProfileGoal(Guid id, Guid goalId)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Goals).FirstOrDefault();
            var entity = profile.Goals.Where(d => d.ID == goalId).FirstOrDefault();
            var model = _mapper.Map<GoalModel>(entity);

            return Ok(model);
        }
        #endregion

        #region Workouts
        [HttpGet("{id}/workouts")]
        public async Task<ActionResult<IEnumerable<WorkoutModel>>> GetProfileWorkouts(Guid id)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id)
                .Include(p => p.Workouts).ThenInclude(p => p.Activities).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var models = _mapper.Map<WorkoutModel[]>(profile.Workouts);

            return Ok(models);
        }

        [HttpPost("{id}/workouts")]
        public async Task<ActionResult<Guid>> CreateProfileWorkout(Guid id, WorkoutModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id)
                .Include(p => p.Workouts).ThenInclude(p => p.Activities).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = _mapper.Map<Workout>(model);
            profile.Workouts.Add(entity);
            _dbContext.Update(profile);
            _dbContext.SaveChanges();

            // Changing POST to be like the PUT and return the model
            // return Ok(entity.ID);
            return Ok(_mapper.Map<WorkoutModel>(entity));
        }

        [HttpDelete("{id}/workouts/{workoutId}")]
        public async Task<ActionResult> DeleteProfileWorkout(Guid id, Guid workoutId)
        {
            //var profile = _dbContext.Set<Profile>().Where(p => p.ID == id).Include(p => p.Workouts).FirstOrDefault();
            //var entity = profile.WorkoutHistory.Where(d => d.ID == workoutId).FirstOrDefault();
            var workout = _dbContext.Set<Workout>().Where(d => d.ID == workoutId)
                .Include(w => w.Activities).FirstOrDefault();
            _dbContext.Remove(workout);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}/workouts/{workoutId}")]
        public async Task<ActionResult<WorkoutModel>> UpdateProfileWorkout(Guid id, Guid workoutId, WorkoutModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id)
                .Include(p => p.Workouts).ThenInclude(p => p.Activities).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = profile.Workouts.Where(d => d.ID == workoutId).FirstOrDefault();
            var workout = _mapper.Map(model, entity);
            _dbContext.Update(workout);
            _dbContext.SaveChanges();

            return Ok(_mapper.Map<WorkoutModel>(entity));
        }

        [HttpGet("{id}/workouts/{workoutId}")]
        public async Task<ActionResult<Workout>> GetProfileWorkout(Guid id, Guid workoutId)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id)
                .Include(p => p.Workouts).ThenInclude(p => p.Activities).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = profile.Workouts.Where(d => d.ID == workoutId).FirstOrDefault();
            var model = _mapper.Map<WorkoutModel>(entity);

            return Ok(model);
        }

        #endregion

        #region WorkoutHistory
        [HttpGet("{id}/workoutHistory")]
        public async Task<ActionResult<IEnumerable<WorkoutHistoryModel>>> GetProfileWorkoutHistory(Guid id)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var models = _mapper.Map<WorkoutHistoryModel[]>(profile.WorkoutHistory);

            return Ok(models);
        }

        [HttpPost("{id}/workoutHistory")]
        public async Task<ActionResult<Guid>> CreateProfileWorkoutHistory(Guid id, WorkoutHistoryModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = _mapper.Map<WorkoutHistory>(model);
            profile.WorkoutHistory.Add(entity);

            _dbContext.Update(profile);
            _dbContext.SaveChanges();
            return Ok(entity.ID);
        }

        [HttpDelete("{id}/workoutHistory/{workoutHistoryId}")]
        public async Task<ActionResult> DeleteProfileWorkoutHistory(Guid id, Guid workoutHistoryId)
        {
            var workoutHistory = _dbContext.Set<WorkoutHistory>().Where(d => d.ID == workoutHistoryId)
                .Include(w => w.ActivityHistories)
                .FirstOrDefault();

            _dbContext.Remove(workoutHistory);
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/workoutHistory/{workoutHistoryId}")]
        public async Task<ActionResult<WorkoutHistoryModel>> UpdateProfileWorkoutHistory(Guid id, Guid workoutHistoryId, WorkoutHistoryModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = profile.WorkoutHistory.Where(d => d.ID == workoutHistoryId).FirstOrDefault();
            var workoutHistory = _mapper.Map(model, entity);

            _dbContext.Update(workoutHistory);
            _dbContext.SaveChanges();

            return Ok(_mapper.Map<WorkoutHistoryModel>(entity));
        }

        [HttpGet("{id}/workoutHistory/{workoutHistoryId}")]
        public async Task<ActionResult<WorkoutHistoryModel>> GetProfileWorkoutHistoryById(Guid id, Guid workoutHistoryId)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == id)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = profile.WorkoutHistory.Where(d => d.ID == workoutHistoryId).FirstOrDefault();
            var model = _mapper.Map<WorkoutHistoryModel>(entity);

            return Ok(model);
        }

        #endregion

    }
}
