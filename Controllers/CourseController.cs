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
    public class CourseController : ApiController
    {
        SDWebApiDbContext _db = new SDWebApiDbContext();
        [HttpGet]
        public IHttpActionResult GetAllCourse()
        {
            List<Course> courses = _db.Courses.ToList();
            return Ok(courses);
        }
        [HttpPost]
        public IHttpActionResult CreateCourse([FromBody] Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return Ok("Successfully Added.");
        }

        [HttpPut]
        public IHttpActionResult UpdateCourse([FromBody] Course updateCourse)
        {
            var course = _db.Courses.Find(updateCourse.Id);
            if (course != null)
            {
                course.Id = updateCourse.Id;
                course.Name = updateCourse.Name;
                _db.Entry(course).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(course);
            }
            else
                return BadRequest("Course not found.");
        }

        [HttpDelete]
        public IHttpActionResult DeleteCourse(string Id)
        {
            var courseToDelete = _db.Courses.Find(Id);
            if (courseToDelete != null)
            {
                _db.Courses.Remove(courseToDelete);
                _db.SaveChanges();
                return Ok("Successfully Deleted.");
            }
            else
                return BadRequest("Course not found.");
        }

        [Route("api/get/course/Id")]
        [HttpGet]
        public IHttpActionResult GetCourse(string Id)
        {
            var course = _db.Courses.Find(Id);
            if (course != null)
                return Ok(course);
            else
                return BadRequest("Course not found.");
        }
    }
}
