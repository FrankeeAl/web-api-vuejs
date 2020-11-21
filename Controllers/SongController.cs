using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using SharpDevelopWebApi.Models;

namespace SharpDevelopWebApi.Controllers
{
    public class SongController : ApiController
    {
        SDWebApiDbContext _db = new SDWebApiDbContext();
        
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Song> songs = _db.Songs.ToList();
            return Ok(songs);
        }
        [HttpPost]
        public IHttpActionResult Create([FromBody]Song song)
        {
            _db.Songs.Add(song);
            _db.SaveChanges();
            return Ok("Successfully Added " + "Song Id" + song.Id);
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Song updateSong)
        {
            var song = _db.Songs.Find(updateSong.Id);
            if (song != null)
            {
                song.Id = updateSong.Id;
                song.Title = updateSong.Title;
                song.Artist = updateSong.Artist;
                song.Genre = updateSong.Genre;
                _db.Entry(song).State = EntityState.Modified;
                _db.SaveChanges();
                return Ok(song);
            }
            else
                return BadRequest("Song not found.");
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            var songToDelete = _db.Songs.Find(Id);
            if (songToDelete != null)
            {
                _db.Songs.Remove(songToDelete);
                _db.SaveChanges();
                return Ok("Successfully Deleted.");
            }
            else
                return BadRequest("Song not found.");
        }

        [HttpGet]
        public IHttpActionResult Get(int Id)
        {
            var song = _db.Songs.Find(Id);
            if (song != null)
                return Ok(song);
            else
                return BadRequest("Song not found.");
        }
    }
}
