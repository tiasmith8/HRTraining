using HRTraining.Domain.Context;
using HRTraining.Domain.Entities.Activities;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult> GetActivities()
        {
            var activities = _activityContext.Queryable<Activity>();
            return Ok(activities);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetActivity(Guid id)
        {
            var activity = await _activityContext.GetByIdAsync<Activity>(id);
            return Ok(activity);
        }

        [HttpPost]
        public async Task<ActionResult> CreateActivity(Activity activity)
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
        public async Task<ActionResult> UpdateActivity(Activity activity)
        {
            await _activityContext.UpdateAsync(activity);
            return Ok(activity);
        }
    }
}
