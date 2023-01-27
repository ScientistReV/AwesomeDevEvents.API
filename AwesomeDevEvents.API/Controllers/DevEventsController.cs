using AwesomeDevEvents.API.Entities;
using AwesomeDevEvents.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDevEvents.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventDbContext _devEventDbContext;

        public DevEventsController(DevEventDbContext devEventDbContext)
        {
            _devEventDbContext = devEventDbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var events = _devEventDbContext.DevEvents.Where(d => !d.IsDeleted).ToList();

            if (events == null)
                return NotFound();

            return Ok(events);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var devEvent = _devEventDbContext.DevEvents.SingleOrDefault(p => p.Id == id);

            if (devEvent == null)
                return NotFound();

            return Ok(devEvent);
        }

        [HttpPost]
        public IActionResult Create(DevEvent devEvent)
        {
            _devEventDbContext.DevEvents.Add(devEvent);

            return CreatedAtAction(nameof(GetById), new { id = devEvent.Id }, devEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent devEvent)
        {
            var devEventOrigin = _devEventDbContext.DevEvents.SingleOrDefault(p => p.Id == id);

            if (devEventOrigin == null)
                return NotFound();

            devEventOrigin.Update(devEvent.Title, devEvent.Description, devEvent.StartedEvent, devEvent.EndEvent);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var devEventOrigin = _devEventDbContext.DevEvents.SingleOrDefault(p => p.Id == id);

            if (devEventOrigin == null)
                return NotFound();

            devEventOrigin.Deleted();

            return NoContent();
        }

        [HttpPost("{id}/speakers")]

        public IActionResult CreateTalk(DevEventSpeaker speaker, Guid id)
        {
            var devEvent = _devEventDbContext.DevEvents.SingleOrDefault(p => p.Id == id);

            if (devEvent == null)
                return NotFound();

            _devEventDbContext.Speakers.Add(speaker);

            return NoContent();
        }
    }
}
