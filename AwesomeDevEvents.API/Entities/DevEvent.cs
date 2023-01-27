using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDevEvents.API.Entities
{
    public class DevEvent
    {
        public DevEvent()
        {
            Speakers = new List<DevEventSpeaker>();
            IsDeleted = false;

        }
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartedEvent { get; set; }

        public DateTime EndEvent { get; set; }

        public List<DevEventSpeaker> Speakers { get; set; }

        public bool IsDeleted { get; set; }

        public void Update(string title, string description, DateTime startedEvent, DateTime endEvent)
        {
            Title = title;
            Description = description;
            StartedEvent = startedEvent;
            EndEvent = endEvent;

        }

        public void Deleted()
        {
            IsDeleted = true;
        }
     }
}
