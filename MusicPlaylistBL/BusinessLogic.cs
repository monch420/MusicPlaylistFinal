using DataLayer;
using Model;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class PlaylistBusinessLogic
    {
        private readonly PlaylistDataLayer dataLayer;

        public PlaylistBusinessLogic()
        {
            dataLayer = new PlaylistDataLayer();
        }

        public bool VerifySong(string artist, string title)
        {
            var result = dataLayer.GetSong(artist, title);
            return result != null;
        }

        public List<Song> DisplayPlaylistInfo()
        {
            return dataLayer.ReturnPlaylistInformation();
        }

        public Song GetSongDetails(string artist, string title)
        {
            return dataLayer.GetSong(artist, title);
        }

        public List<Song> RemovedSongInList(string artist, string title)
        {
            return dataLayer.DeleteSong(artist, title);
        }

        public List<Song> AddedSongInList(string userTitle, string userArtist, string userAlbum, string userDuration)
        {
            return dataLayer.AddSong(userTitle, userArtist, userAlbum, userDuration);
        }

        public List<Song> UpdateSongInList(string originalArtist, string originalTitle, string newArtist, string newTitle, string newAlbum, string newDuration)
        {
            return dataLayer.UpdateSong(originalArtist, originalTitle, newArtist, newTitle, newAlbum, newDuration);
        }
    }
}
