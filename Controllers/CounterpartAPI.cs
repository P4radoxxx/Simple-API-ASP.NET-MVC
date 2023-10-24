using Microsoft.AspNetCore.Mvc;
using WebAPITest.Modeles;
using WebAPITest.Repositories;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterpartAPI : ControllerBase
    {

        private readonly ICounterpartRepository _counterpartRepository;

        public CounterpartAPI(ICounterpartRepository counterpartRepository)
        {
            _counterpartRepository = counterpartRepository;
        }






        [HttpGet]
        public IActionResult GetAllCounterparts()
        {
            var counterparts = _counterpartRepository.GetAllCounterparts();
            return Ok(counterparts);
        }




        [HttpGet("{id}")]
        public IActionResult GetCounterpart(int id)
        {
            var counterpart = _counterpartRepository.ReadCounterpartID(id);
            if (counterpart == null)
            {
                return NotFound();
            }
            return Ok(counterpart);
        }




        [HttpPost]
        public IActionResult CreateCounterpart([FromBody] Counterpart counterpart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _counterpartRepository.CreateCounterpart(counterpart);
            return CreatedAtAction(nameof(GetCounterpart), new { id = counterpart.CounterpartID }, counterpart);
        }




        [HttpPut("{id}")]
        public IActionResult UpdateCounterpart(int id, [FromBody] Counterpart counterpart)
        {
            if (id != counterpart.CounterpartID)
            {
                return BadRequest();
            }
            _counterpartRepository.UpdateCounterpart(counterpart);
            return NoContent();
        }




        [HttpDelete("{id}")]
        public IActionResult DeleteCounterpart(int id)
        {
            var counterpart = _counterpartRepository.ReadCounterpartID(id);
            if (counterpart == null)
            {
                return NotFound();
            }
            _counterpartRepository.DeleteCounterpart(id);
            return NoContent();
        }
    }
}
