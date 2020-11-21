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
    public class SubjectController : ApiController
    {
        SDWebApiDbContext _db = new SDWebApiDbContext();
        [HttpGet]
        public IHttpActionResult GetAllSubject()
        {
            List<Subject> subjects = _db.Subjects.ToList();
            return Ok(subjects);
        }
        [HttpPost]
        public IHttpActionResult CreateSubject([FromBody] Subject subject)
        {
            _db.Subjects.Add(subject);
            _db.SaveChanges();
            return Ok("Successfully Added.");
        }

        [HttpPut]
        public IHttpActionResult UpdateSubject([FromBody] Subject updateSubject)
        {
            var subject = _db.Subjects.Find(updateSubject.Id);
            if (subject != null)
            {
                subject.Id = updateSubject.Id;
                subject.Code = updateSubject.Code;
                subject.DescriptiveTitle = updateSubject.DescriptiveTitle;
                _db.Entry(subject).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(subject);
            }
            else
                return BadRequest("Subject not found.");
        }

        [HttpDelete]
        public IHttpActionResult DeleteSubject(string Id)
        {
            var subjectToDelete = _db.Subjects.Find(Id);
            if (subjectToDelete != null)
            {
                _db.Subjects.Remove(subjectToDelete);
                _db.SaveChanges();
                return Ok("Successfully Deleted.");
            }
            else
                return BadRequest("Subject not found.");
        }

        [Route("api/get/subject/Id")]
        [HttpGet]
        public IHttpActionResult GetSubject(string Id)
        {
            var subject = _db.Subjects.Find(Id);
            if (subject != null)
                return Ok(subject);
            else
                return BadRequest("Subject not found.");
        }
    }
}
