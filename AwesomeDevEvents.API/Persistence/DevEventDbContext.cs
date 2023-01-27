using AwesomeDevEvents.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwesomeDevEvents.API.Persistence
{
    public class DevEventDbContext
    {
        public List<DevEvent> DevEvents { get; set; }

        public List<DevEventSpeaker> Speakers { get; set; }

        public DevEventDbContext()
        {
            DevEvents = new List<DevEvent>();
            Speakers = new List<DevEventSpeaker>();
        }
    }

}
