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
            .Include(e => e.Eventcategories)
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
                    Companyid = e.Companyid,

                }).ToListAsync();

        }

        public async Task<EventregistrationResDto?> GetEventByIdAsync(int eventId)
        {
            var eventEntity = await _context
                                    .Eventregistrations
                                    .Include(e => e.Eventcategories)
                                    .FirstOrDefaultAsync(e => e.Eventid == eventId);
                                    
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
                Companyid = eventEntity.Companyid,

                
                lstcat = eventEntity.Eventcategories.Select(c => new EventCategoryCreateDto
                {
                    EvtCatId = c.EvtCatId,
                    EvtCategory = c.EvtCategory,
                    NoOfVeh = c.NoOfVeh,
                    Status = c.Status,
                    Nooflaps = c.Nooflaps,
                    Entryprice = c.Entryprice,
                    Wheelertype = c.Wheelertype,
                    EventId = c.EventId
                }).ToList()
            };
        }

        public async Task<bool> AddEventAsync(EventregistrationReqDto eventDto,  IFormFile? banner, IFormFile? qrpath)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
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
                    Banner = banner!=null?Utils.saveImg(banner, "Banner"):"",
                    Qrpath = qrpath!=null?Utils.saveImg(qrpath, "QR"):""
                };

                _context.Eventregistrations.Add(eventEntity);
                await _context.SaveChangesAsync();

                if (eventDto.lstcat != null && eventDto.lstcat.Any())
                {
                    var eventCategories = eventDto.lstcat.Select(item => new Eventcategory
                    {
                        EvtCategory = item.EvtCategory,
                        NoOfVeh = item.NoOfVeh,
                        Status = item.Status,
                        Nooflaps = item.Nooflaps,
                        Entryprice = item.Entryprice,
                        Wheelertype = item.Wheelertype,
                        EventId = eventEntity.Eventid // Assign FK after saving event
                    }).ToList();

                    _context.Eventcategories.AddRange(eventCategories);
                    await _context.SaveChangesAsync();
                }

                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
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

            // if (eventDto.Banner != null)
            // {
            //     eventEntity.Banner = Utils.saveImg(eventDto.Banner, "Banner");
            // }
            // if (eventDto.Qrpath != null)
            // {
            //     eventEntity.Qrpath = Utils.saveImg(eventDto.Qrpath, "QR");
            // }

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
