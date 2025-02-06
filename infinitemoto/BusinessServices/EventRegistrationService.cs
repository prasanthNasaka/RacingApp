using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace infinitemoto.Services
{
    public class EventRegistrationService : IEventRegistrationService
    {
        private readonly DummyProjectSqlContext _context;

        public EventRegistrationService(DummyProjectSqlContext context)
        {
            _context = context;
        }

        // Get all event registrations
        public async Task<IEnumerable<EventregistrationDto>> GetAllEventsAsync()
        {
            return await _context.Eventregistrations
                .Select(e => new EventregistrationDto
                {
                    Eventid = e.Eventid,
                    Eventtype = e.Eventtype,
                    Eventname = e.Eventname,
                    Startdate = e.Startdate,
                    Enddate = e.Enddate,
                    Isactive = e.Isactive,
                    Banner = e.Banner,
                    Showdashboard = e.Showdashboard
                })
                .ToListAsync();
        }

        // Get an event registration by ID
        public async Task<EventregistrationDto?> GetEventByIdAsync(int id)
{
    var eventRegistration = await _context.Eventregistrations.FindAsync(id);

    // ✅ Ensure the event exists before accessing its properties
    if (eventRegistration == null)
        return null;

    return new EventregistrationDto
    {
        Eventid = eventRegistration.Eventid, // 👈 Make sure eventRegistration is not null
        Eventtype = eventRegistration.Eventtype,
        Eventname = eventRegistration.Eventname,
        Startdate = eventRegistration.Startdate,
        Enddate = eventRegistration.Enddate,
        Isactive = eventRegistration.Isactive,
        Banner = eventRegistration.Banner,
        Showdashboard = eventRegistration.Showdashboard
    };
}

        // Create a new event registration
        public async Task<EventregistrationDto> AddEventAsync(EventregistrationDto eventRegistrationDto)
        {
            var eventRegistration = new Eventregistration
            {
                Eventtype = eventRegistrationDto.Eventtype,
                Eventname = eventRegistrationDto.Eventname,
                Startdate = eventRegistrationDto.Startdate,
                Enddate = eventRegistrationDto.Enddate,
                Isactive = eventRegistrationDto.Isactive,
                Banner = eventRegistrationDto.Banner,
                Showdashboard = eventRegistrationDto.Showdashboard
            };

            _context.Eventregistrations.Add(eventRegistration);
            await _context.SaveChangesAsync();

            eventRegistrationDto.Eventid = eventRegistration.Eventid;
            return eventRegistrationDto;
        }

        // Update an existing event registration
        public async Task<bool> UpdateEventAsync(int id, EventregistrationDto eventRegistrationDto)
        {
            if (eventRegistrationDto is null)
            {
                throw new ArgumentNullException(nameof(eventRegistrationDto));
            }

            var eventRegistration = await _context.Eventregistrations.FindAsync(id);
            if (eventRegistration == null) return false;

            eventRegistration.Eventtype = eventRegistrationDto.Eventtype;
            eventRegistration.Eventname = eventRegistrationDto.Eventname;
            eventRegistration.Startdate = eventRegistrationDto.Startdate;
            eventRegistration.Enddate = eventRegistrationDto.Enddate;
            eventRegistration.Isactive = eventRegistrationDto.Isactive;
            eventRegistration.Banner = eventRegistrationDto.Banner;
            eventRegistration.Showdashboard = eventRegistrationDto.Showdashboard;

            await _context.SaveChangesAsync();
            return true;
        }

        // Delete an event registration
        public async Task<bool> DeleteEventAsync(int id)
        {
            var eventRegistration = await _context.Eventregistrations.FindAsync(id);
            if (eventRegistration == null) return false;

            _context.Eventregistrations.Remove(eventRegistration);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
