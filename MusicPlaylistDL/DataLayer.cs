using System.Collections.Generic;
using Model;

namespace DataLayer
{
    public class PlaylistDataLayer
    {
        SqlDbData dbData = new SqlDbData();

        public List<Song> ReturnPlaylistInformation()
        {
            return dbData.GetSongs();
        }

        public Song GetSong(string artist, string title)
        {
            return dbData.GetSong(artist, title);
        }

        public List<Song> DeleteSong(string artist, string title)
        {
            dbData.DeleteSong(artist, title);
            return dbData.GetSongs();
        }

        public List<Song> AddSong(string userTitle, string userArtist, string userAlbum, string userDuration)
        {
            Song newSong = new Song
            {
                title = userTitle,
                artist = userArtist,
                album = userAlbum,
                duration = userDuration
            };

            dbData.AddSong(newSong);
            return dbData.GetSongs();
        }

        public List<Song> UpdateSong(string originalArtist, string originalTitle, string newArtist, string newTitle, string newAlbum, string newDuration)
        {
            dbData.UpdateSong(originalArtist, originalTitle, newArtist, newTitle, newAlbum, newDuration);
            return dbData.GetSongs();
        }
    }
}
