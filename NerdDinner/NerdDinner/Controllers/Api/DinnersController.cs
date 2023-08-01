using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NerdDinner.Models;
using NerdDinner.Dtos;
using AutoMapper;

namespace NerdDinner.Controllers.Api
{
    public class DinnersController : ApiController
    {
        private ApplicationDbContext _context;

        public DinnersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/dinners
        public IEnumerable<DinnerDto> GetDinners()
        {
            return _context.Dinners.ToList().Select(Mapper.Map<Dinner, DinnerDto>);
        }

        // GET /api/dinners/1
        public IHttpActionResult GetDinner(int id)
        {
            var dinner = _context.Dinners.SingleOrDefault(d => d.Id == id);

            if (dinner == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Dinner, DinnerDto>(dinner));
        }

        // POST /api/dinners
        [HttpPost]
        public IHttpActionResult CreateDinner(DinnerDto dinnerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var dinner = Mapper.Map<DinnerDto, Dinner>(dinnerDto);
            _context.Dinners.Add(dinner);
            _context.SaveChanges();

            dinnerDto.Id = dinner.Id;

            return Created(new Uri(Request.RequestUri + "/" + dinner.Id), dinnerDto);
        }

        // PUT /api/dinners/1
        [HttpPut]
        public void UpdateDinner(int id, DinnerDto dinnerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var dinnerInDb = _context.Dinners.SingleOrDefault(d => d.Id == id);

            if (dinnerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(dinnerDto, dinnerInDb);

            _context.SaveChanges();
        }

        // DELETE /api/dinners/1
        [HttpDelete]
        public void DeleteDinner(int id)
        {
            var dinnerInDb = _context.Dinners.SingleOrDefault(d => d.Id == id);

            if (dinnerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Dinners.Remove(dinnerInDb);
            _context.SaveChanges();
        }
    }
}
