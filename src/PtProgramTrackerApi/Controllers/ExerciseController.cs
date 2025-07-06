using Microsoft.AspNetCore.Mvc;
using PtProgramTrackerApi.Domain.Dtos;
using PtProgramTrackerApi.Domain.Entities;
using PtProgramTrackerApi.Domain.Interfaces.Services;
using System.Net;

namespace PtProgramTrackerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Exercise), (int)HttpStatusCode.OK)]
        public IActionResult GetById(int id)
        {
            var exercise = _exerciseService.GetById(id);
            return Ok(exercise);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Exercise>), (int)HttpStatusCode.OK)]
        public IActionResult FindAll()
        {
            var exercises = _exerciseService.FindAll();
            return Ok(exercises);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Exercise), (int)HttpStatusCode.Created)]
        public IActionResult Create(ExerciseDto input)
        {
            var exercise = _exerciseService.Create(input);
            return Created("{id}", exercise);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Exercise), (int)HttpStatusCode.OK)]
        public IActionResult Update(int id, ExerciseDto input)
        {
            var exercise = _exerciseService.Update(id, input);
            return Ok(exercise);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        public IActionResult Delete(int id)
        {
            _exerciseService.Delete(id);
            return NoContent();
        }
    }
}