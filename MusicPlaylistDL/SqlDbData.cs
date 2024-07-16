using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;

namespace DataLayer
{
    public class SqlDbData
    {
        private string connectionString = "Server = tcp:20.189.123.66,1433; Database = MusicPlaylist; User Id = sa; Password = bsit12345*";

        public List<Song> GetSongs()
        {
            List<Song> songs = new List<Song>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            { 
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT title, artist, album, duration FROM songs", conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Song song = new Song
                        {
                            title = reader["title"].ToString(),
                            artist = reader["artist"].ToString(),
                            album = reader["album"].ToString(),
                            duration = reader["duration"].ToString()
                        };

                        songs.Add(song);
                    }
                }
            }

            return songs;
        }

        public Song GetSong(string artist, string title)
        {
            Song song = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT title, artist, album, duration FROM songs WHERE artist = @artist AND title = @title", conn);
                cmd.Parameters.AddWithValue("@artist", artist);
                cmd.Parameters.AddWithValue("@title", title);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        song = new Song
                        {
                            title = reader["title"].ToString(),
                            artist = reader["artist"].ToString(),
                            album = reader["album"].ToString(),
                            duration = reader["duration"].ToString()
                        };
                    }
                }
            }

            return song;
        }

        public void DeleteSong(string artist, string title)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM songs WHERE artist = @artist AND title = @title", conn);
                cmd.Parameters.AddWithValue("@artist", artist);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.ExecuteNonQuery();
            }
        }

        public void AddSong(Song newSong)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO songs (title, artist, album, duration) VALUES (@title, @artist, @album, @duration)", conn);
                cmd.Parameters.AddWithValue("@title", newSong.title);
                cmd.Parameters.AddWithValue("@artist", newSong.artist);
                cmd.Parameters.AddWithValue("@album", newSong.album);
                cmd.Parameters.AddWithValue("@duration", newSong.duration);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSong(string originalArtist, string originalTitle, string newArtist, string newTitle, string newAlbum, string newDuration)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE songs SET title = @newTitle, artist = @newArtist, album = @newAlbum, duration = @newDuration WHERE artist = @originalArtist AND title = @originalTitle", conn);
                cmd.Parameters.AddWithValue("@newTitle", newTitle);
                cmd.Parameters.AddWithValue("@newArtist", newArtist);
                cmd.Parameters.AddWithValue("@newAlbum", newAlbum);
                cmd.Parameters.AddWithValue("@newDuration", newDuration);
                cmd.Parameters.AddWithValue("@originalArtist", originalArtist);
                cmd.Parameters.AddWithValue("@originalTitle", originalTitle);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
