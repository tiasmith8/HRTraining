using HRTraining.Domain.Context;
using HRTraining.Domain.Entities.Activities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRTraining.Domain.Controllers
{
    [Route("api/activities")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly ActivityContext _activityContext;

        public ActivityController(ActivityContext activityContext)
        {
            _activityContext = activityContext;
            _activityContext.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Activity>>> GetActivities()
        {
            var activities = _activityContext.Queryable<Activity>();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            var activity = await _activityContext.GetByIdAsync<Activity>(id);
            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateActivity(Activity activity)
        {
            await _activityContext.CreateAsync(activity);
            return Ok(activity.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActivity(Guid id)
        {
            await _activityContext.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Activity>> UpdateActivity(Activity activity)
        {
            await _activityContext.UpdateAsync(activity);
            return Ok(activity);
        }
    }
}
