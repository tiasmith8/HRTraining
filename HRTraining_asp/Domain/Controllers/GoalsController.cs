using HRTraining.Domain.Context;
using HRTraining.Domain.Entities;
using HRTraining.Domain.Entities.Goals;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HRTraining.Domain.Controllers
{
    [Route("api/goals")]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly GoalsContext _goalsContext;

        public GoalsController(GoalsContext goalsContext)
        {
            _goalsContext = goalsContext;
            _goalsContext.Database.EnsureCreated();
        }

        [HttpGet]
        public async Task<ActionResult> GetGoals()
        {
            var goals = _goalsContext.Queryable<Goal>();
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetGoal(Guid id)
        {
            var workout = await _goalsContext.GetByIdAsync<Goal>(id);
            return Ok(workout);
        }

        [HttpPost]
        public async Task<ActionResult> CreateGoal(Goal goal)
        {
            await _goalsContext.CreateAsync(goal);
            return Ok(goal.Id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGoal(Guid id)
        {
            await _goalsContext.DeleteByIdAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGoal(Goal goal)
        {
            await _goalsContext.UpdateAsync(goal);
            return Ok(goal);
        }
    }
}
