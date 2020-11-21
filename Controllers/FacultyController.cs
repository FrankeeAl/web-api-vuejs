using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
    public class FacultyController : ApiController
    {
        SDWebApiDbContext _db = new SDWebApiDbContext();

        [HttpGet]
        public IHttpActionResult GetAllFaculty()
        {
            List<Faculty> faculties = _db.Faculties.ToList();
            return Ok(faculties);
        }
        [HttpPost]
        public IHttpActionResult CreateFaculty([FromBody] Faculty faculty)
        {
            _db.Faculties.Add(faculty);
            _db.SaveChanges();
            return Ok("Successfully Added.");
        }

        [HttpPut]
        public IHttpActionResult UpdateFaculty([FromBody] Faculty updateFaculty)
        {
            var faculty = _db.Faculties.Find(updateFaculty.Id);
            if (faculty != null)
            {
                faculty.SSSNumber = updateFaculty.SSSNumber;
                faculty.Supervisor = updateFaculty.Supervisor;
                _db.Entry(faculty).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(faculty);
            }
            else
                return BadRequest("Faculty not found.");
        }

        [HttpDelete]
        public IHttpActionResult DeleteFaculty(string sssNumber)
        {
            var facultyToDelete = _db.Faculties.Find(sssNumber);
            if (facultyToDelete != null)
            {
                _db.Faculties.Remove(facultyToDelete);
                _db.SaveChanges();
                return Ok("Successfully Deleted.");
            }
            else
                return BadRequest("Faculty not found.");
        }
        [Route("api/get/sssNumber")]

        [HttpGet]
        public IHttpActionResult GetFaculty(string sssNumber)
        {
            var faculty = _db.Faculties.Find(sssNumber);
            if (faculty != null)
                return Ok(faculty);
            else
                return BadRequest("Faculty not found.");
        }
    }
}
