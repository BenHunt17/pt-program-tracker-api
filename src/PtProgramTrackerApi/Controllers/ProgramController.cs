using Microsoft.AspNetCore.Mvc;
using PtProgramTrackerApi.Domain.Dtos.Program;
using PtProgramTrackerApi.Domain.Interfaces.Services;
using System.Net;

namespace PtProgramTrackerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramController : ControllerBase
    {
        private readonly IProgramService _ProgramService;

        public ProgramController(IProgramService ProgramService)
        {
            _ProgramService = ProgramService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Program), (int)HttpStatusCode.OK)]
        public IActionResult GetById(int id)
        {
            var Program = _ProgramService.GetById(id);
            return Ok(Program);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Program>), (int)HttpStatusCode.OK)]
        public IActionResult FindAll()
        {
            var Programs = _ProgramService.FindAll();
            return Ok(Programs);
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Program), (int)HttpStatusCode.Created)]
        public IActionResult Upsert(ProgramDto input)
        {
            var Program = _ProgramService.UpsertProgram(input);
            return Created("{id}", Program);
        }

        [HttpPut("{id}/workouts")]
        [ProducesResponseType(typeof(Program), (int)HttpStatusCode.OK)]
        public IActionResult UpsertProgramWorkouts(int id, WorkoutDto input)
        {
            var Program = _ProgramService.UpsertProgramWorkout(id, input);
            return Ok(Program);
        }

        [HttpPut("{programId}/workouts/{workoutId}/exercises")]
        [ProducesResponseType(typeof(Program), (int)HttpStatusCode.OK)]
        public IActionResult UpdateWorkoutExercises(int programId, int workoutId, [FromBody] IEnumerable<int> exerciseIds)
        {
            var Program = _ProgramService.UpdateProgramWorkoutExercises(programId, workoutId, exerciseIds);
            return Ok(Program);
        }

        [HttpDelete("{id}/workouts/{workoutId}")]
        [ProducesResponseType(typeof(Program), (int)HttpStatusCode.OK)]
        public IActionResult RemoveProgramWorkouts(int programId, int workoutId)
        {
            var Program = _ProgramService.RemoveProgramWorkout(programId, workoutId);
            return Ok(Program);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        public IActionResult Delete(int id)
        {
            _ProgramService.Delete(id);
            return NoContent();
        }
    }
}