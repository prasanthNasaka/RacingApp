using infinitemoto.DTOs;
using infinitemoto.Models;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IEnumerable<EventregistrationResDto>> GetAllEventsAsync()
        {
            return await _context.Eventregistrations
                .Select(e => new EventregistrationResDto
                {
                    Eventid = e.Eventid,
                    Eventtype = e.Eventtype,
                    Eventname = e.Eventname,
                    Startdate = e.Startdate,
                    Enddate = e.Enddate,
                    Isactive = e.Isactive,
                    Banner = e.Banner,
                    Showdashboard = e.Showdashboard,
                    Eventstatus = e.Eventstatus,
                    Bankname = e.Bankname,
                    Ifsccode = e.Ifsccode,
                    Accountname = e.Accountname,
                    Accountnum = e.Accountnum,
                    Qrpath = e.Qrpath,
                    Companyid = e.Companyid
                }).ToListAsync();
        }

        public async Task<EventregistrationResDto?> GetEventByIdAsync(int eventId)
        {
            var eventEntity = await _context.Eventregistrations.FindAsync(eventId);
            if (eventEntity == null)
                return null;

            return new EventregistrationResDto
            {
                Eventid = eventEntity.Eventid,
                Eventtype = eventEntity.Eventtype,
                Eventname = eventEntity.Eventname,
                Startdate = eventEntity.Startdate,
                Enddate = eventEntity.Enddate,
                Isactive = eventEntity.Isactive,
                Banner = eventEntity.Banner,
                Showdashboard = eventEntity.Showdashboard,
                Eventstatus = eventEntity.Eventstatus,
                Bankname = eventEntity.Bankname,
                Ifsccode = eventEntity.Ifsccode,
                Accountname = eventEntity.Accountname,
                Accountnum = eventEntity.Accountnum,
                Qrpath = eventEntity.Qrpath,
                Companyid = eventEntity.Companyid
            };
        }

        public async Task<bool> AddEventAsync(EventregistrationReqDto eventDto)
        {
            var eventEntity = new Eventregistration
            {
                Eventtype = eventDto.Eventtype,
                Eventname = eventDto.Eventname,
                Startdate = eventDto.Startdate.ToUniversalTime(),
                Enddate = eventDto.Enddate.ToUniversalTime(),
                Isactive = eventDto.Isactive,
                Showdashboard = eventDto.Showdashboard,
                Eventstatus = eventDto.Eventstatus,
                Bankname = eventDto.Bankname,
                Ifsccode = eventDto.Ifsccode,
                Accountname = eventDto.Accountname,
                Accountnum = eventDto.Accountnum,
                Companyid = eventDto.Companyid,
                Banner = Utils.saveImg(eventDto.Banner, "Banner"),
                Qrpath = Utils.saveImg(eventDto.Qrpath, "QR")
            };

            _context.Eventregistrations.Add(eventEntity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task UpdateEventAsync(int eventId, EventregistrationReqDto eventDto)
        {
            var eventEntity = await _context.Eventregistrations.FindAsync(eventId);
            if (eventEntity == null) throw new KeyNotFoundException("Event not found");

            eventEntity.Eventtype = eventDto.Eventtype;
            eventEntity.Eventname = eventDto.Eventname;
            eventEntity.Startdate = eventDto.Startdate.ToUniversalTime();
            eventEntity.Enddate = eventDto.Enddate.ToUniversalTime();
            eventEntity.Isactive = eventDto.Isactive;
            eventEntity.Showdashboard = eventDto.Showdashboard;
            eventEntity.Eventstatus = eventDto.Eventstatus;
            eventEntity.Bankname = eventDto.Bankname;
            eventEntity.Ifsccode = eventDto.Ifsccode;
            eventEntity.Accountname = eventDto.Accountname;
            eventEntity.Accountnum = eventDto.Accountnum;
            eventEntity.Companyid = eventDto.Companyid;
            
            if (eventDto.Banner != null)
            {
                eventEntity.Banner = Utils.saveImg(eventDto.Banner, "Banner");
            }
            if (eventDto.Qrpath != null)
            {
                eventEntity.Qrpath = Utils.saveImg(eventDto.Qrpath, "QR");
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEventAsync(int eventId)
        {
            var eventEntity = await _context.Eventregistrations.FindAsync(eventId);
            if (eventEntity == null) throw new KeyNotFoundException("Event not found");

            _context.Eventregistrations.Remove(eventEntity);
            await _context.SaveChangesAsync();
        }
    }
}
