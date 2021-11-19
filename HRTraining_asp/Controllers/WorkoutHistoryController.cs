using AutoMapper;
using HRTraining.Data;
using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Workouts;
using HRTraining_asp.Domain.Entities.Activities.Models;
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
    [Route("api/profile/{profileId}/workoutHistory/")]
    [ApiController]
    public class WorkoutHistoryController : ControllerBase
    {
        private readonly HRDbContext _dbContext;
        private readonly IMapper _mapper;

        public WorkoutHistoryController(HRDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region Workouts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutHistoryModel>>> GetWorkoutHistories(Guid profileId)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == profileId)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var models = _mapper.Map<WorkoutHistoryModel[]>(profile.WorkoutHistory);

            return Ok(models);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutHistoryModel>> GetWorkoutHistory(Guid profileId, Guid id)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == profileId)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = profile.WorkoutHistory.Where(w => w.ID == id);
            var model = _mapper.Map<WorkoutHistoryModel>(entity);

            return Ok(model);
        }

        [HttpGet("{id}/activityHistory/{activityHistoryId}")]
        public async Task<ActionResult<WorkoutHistoryModel>> GetActivityHistory(Guid profileId, Guid id, Guid activityHistoryId)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == profileId)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = profile.WorkoutHistory.Where(w => w.ID == id).FirstOrDefault().ActivityHistories.Where(x => x.ID == activityHistoryId).FirstOrDefault();
            var model = _mapper.Map<ActivityHistoryModel>(entity);

            return Ok(model);
        }

        [HttpPut("{id}/activityHistory/{activityHistoryId}")]
        public async Task<ActionResult<WorkoutHistoryModel>> UpdateActivityHistory(Guid profileId, Guid id, Guid activityHistoryId, ActivityHistoryModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == profileId)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = profile.WorkoutHistory.Where(w => w.ID == id).FirstOrDefault().ActivityHistories.Where(x => x.ID == activityHistoryId).FirstOrDefault();
            var activityHistory = _mapper.Map(model, entity);

            _dbContext.Update(activityHistory);

            return Ok(model);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWorkoutHistory(Guid profileId, WorkoutHistoryModel workoutHistory)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == profileId)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = _mapper.Map<WorkoutHistory>(workoutHistory);
            profile.WorkoutHistory.Add(entity);

            _dbContext.Update(profile);
            return Ok(entity.ID);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteWorkoutHistory(Guid profileId, Guid id)
        {
            _dbContext.Remove(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<WorkoutHistoryModel>> UpdateWorkoutHistory(Guid profileId, Guid id, WorkoutHistoryModel model)
        {
            var profile = _dbContext.Set<Profile>().Where(p => p.ID == profileId)
                .Include(p => p.WorkoutHistory).ThenInclude(p => p.ActivityHistories).ThenInclude(p => p.Targets)
                .FirstOrDefault();
            var entity = profile.WorkoutHistory.Where(d => d.ID == id).FirstOrDefault();
            var workoutHistory = _mapper.Map(model, entity);

            _dbContext.Update(workoutHistory);

            return Ok(model);
        }
        #endregion

    }
}
