using System;
using BusinessLogic;
using System.Collections.Generic;
using Model;

namespace UI
{
    internal class UI
    {
        static void Main(string[] args)
        {
            PlaylistBusinessLogic businessLogic = new PlaylistBusinessLogic();

            while (true)
            {
                Console.WriteLine("\r\n  __  __ _   _ ___ ___ ___   ___ _      ___   ___    ___ ___ _____ \r\n |  \\/  | | | / __|_ _/ __| | _ \\ |    /_\\ \\ / / |  |_ _/ __|_   _|\r\n | |\\/| | |_| \\__ \\| | (__  |  _/ |__ / _ \\ V /| |__ | |\\__ \\ | |  \r\n |_|  |_|\\___/|___/___\\___| |_| |____/_/ \\_\\_| |____|___|___/ |_|  \r\n                                                                   \r\n\n------------------------------");

                foreach (Song song in businessLogic.DisplayPlaylistInfo())
                {
                    Console.WriteLine($"{song.artist} - {song.title}\n------------------------------");
                }

                Console.WriteLine("\n[1] ADD SONG \n[2] REMOVE SONG \n[3] EDIT SONG INFORMATION \n[4] EXIT\n \nENTER: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("\nENTER TITLE: ");
                    string userTitle = Console.ReadLine();
                    Console.WriteLine("\nENTER ARTIST: ");
                    string userArtist = Console.ReadLine();
                    Console.WriteLine("\nENTER ALBUM: ");
                    string userAlbum = Console.ReadLine();
                    Console.WriteLine("\nENTER DURATION: ");
                    string userDuration = Console.ReadLine();

                    foreach (Song song in businessLogic.AddedSongInList(userTitle, userArtist, userAlbum, userDuration))
                    {
                        Console.WriteLine($"{song.artist} - {song.title}\n------------------------------");
                    }
                }
                else if (choice == 2)
                {
                    Console.Write("\nENTER 'ARTIST - TITLE': ");
                    string songDetails = Console.ReadLine();
                    string[] details = songDetails.Split(" - ");

                    if (details.Length != 2)
                    {
                        Console.WriteLine("\nINVALID FORMAT");
                        continue;
                    }

                    string artist = details[0].Trim();
                    string title = details[1].Trim();

                    bool found = businessLogic.VerifySong(artist, title);

                    if (found)
                    {
                        businessLogic.RemovedSongInList(artist, title);

                        foreach (Song song in businessLogic.DisplayPlaylistInfo())
                        {
                            Console.WriteLine($"{song.artist} - {song.title}\n------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nSONG NOT FOUND");
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("\nENTER ORIGINAL 'ARTIST - TITLE': ");
                    string originalDetails = Console.ReadLine();
                    string[] details = originalDetails.Split(" - ");

                    if (details.Length != 2)
                    {
                        Console.WriteLine("\nINVALID FORMAT");
                        continue;
                    }

                    string originalArtist = details[0].Trim();
                    string originalTitle = details[1].Trim();

                    bool found = businessLogic.VerifySong(originalArtist, originalTitle);

                    if (found)
                    {
                        Console.WriteLine("\nENTER NEW TITLE: ");
                        string newTitle = Console.ReadLine();
                        Console.WriteLine("\nENTER NEW ARTIST: ");
                        string newArtist = Console.ReadLine();
                        Console.WriteLine("\nENTER NEW ALBUM: ");
                        string newAlbum = Console.ReadLine();
                        Console.WriteLine("\nENTER NEW DURATION: ");
                        string newDuration = Console.ReadLine();

                        foreach (Song song in businessLogic.UpdateSongInList(originalArtist, originalTitle, newArtist, newTitle, newAlbum, newDuration))
                        {
                            Console.WriteLine($"{song.artist} - {song.title}\n------------------------------");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nSONG NOT FOUND");
                    }
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nINVALID CHOICE");
                }
            }
        }
    }
}
