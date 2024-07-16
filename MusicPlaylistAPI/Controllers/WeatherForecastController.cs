using BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/Song")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly PlaylistBusinessLogic _businessLogic;

        public PlaylistsController()
        {
            _businessLogic = new PlaylistBusinessLogic();
        }

        [HttpGet]
        public ActionResult<List<Song>> GetPlaylist()
        {
            var playlist = _businessLogic.DisplayPlaylistInfo();
            return Ok(playlist);
        }

        [HttpGet("{artist}/{title}")]
        public ActionResult<Song> GetSong(string artist, string title)
        {
            var song = _businessLogic.GetSongDetails(artist, title);
            if (song == null)
            {
                return NotFound();
            }
            return Ok(song);
        }

        [HttpPost]
        public ActionResult<List<Song>> AddSong([FromBody] Song song)
        {
            var updatedPlaylist = _businessLogic.AddedSongInList(song.title, song.artist, song.album, song.duration);
            return Ok(updatedPlaylist);
        }

        [HttpPatch("{artist}/{title}")]
        public ActionResult<List<Song>> UpdateSong(string artist, string title, [FromBody] Song updatedSong)
        {
            var updatedPlaylist = _businessLogic.UpdateSongInList(artist, title, updatedSong.artist, updatedSong.title, updatedSong.album, updatedSong.duration);
            return Ok(updatedPlaylist);
        }

        [HttpDelete("{artist}/{title}")]
        public ActionResult<List<Song>> DeleteSong(string artist, string title)
        {
            var updatedPlaylist = _businessLogic.RemovedSongInList(artist, title);
            return Ok(updatedPlaylist);
        }
    }
}