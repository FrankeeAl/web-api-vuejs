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
    public class StudentController : ApiController
    {
        SDWebApiDbContext _db = new SDWebApiDbContext();
        [HttpGet]
        public IHttpActionResult GetAllStudent()
        {
            List<Student> students = _db.Students.ToList();
            return Ok(students);
        }
        [HttpPost]
        public IHttpActionResult CreateStudent([FromBody] Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return Ok("Successfully Added.");
        }

        [HttpPut]
        public IHttpActionResult UpdateStudent([FromBody] Student updateStudent)
        {
            var student = _db.Students.Find(updateStudent.CourseId);
            if (student != null)
            {
                student.CourseId = updateStudent.CourseId;
                student.SchoolLastAttended = updateStudent.SchoolLastAttended;
                _db.Entry(student).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(student);
            }
            else
                return BadRequest("Student not found.");
        }

        [HttpDelete]
        public IHttpActionResult DeleteStudent(int courseId)
        {
            var studentToDelete = _db.Students.Find(courseId);
            if (studentToDelete != null)
            {
                _db.Students.Remove(studentToDelete);
                _db.SaveChanges();
                return Ok("Successfully Deleted.");
            }
            else
                return BadRequest("Student not found.");
        }
        [Route("api/get/student/Id")]
        [HttpGet]
        public IHttpActionResult GetStudent(int courseId)
        {
            var student = _db.Students.Find(courseId);
            if (student != null)
                return Ok(student);
            else
                return BadRequest("Student not found.");
        }
    }
}
