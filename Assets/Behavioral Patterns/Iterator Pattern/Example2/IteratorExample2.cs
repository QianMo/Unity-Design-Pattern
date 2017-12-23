//-------------------------------------------------------------------------------------
//	IteratorExample2.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/* Iterator provides uniform way to access different collections of objects
 * If you get an Array, ArrayList, Hashtable of objects, you pop out an iterator for each and treat them the same
 * 
 * This provides a uniform way to cycle through different collections
 * 
 * You can also write polymorphic code because you can refer to each collection of objects
 * because they'll implement the same interface
 * */


public class IteratorExample2 : MonoBehaviour
{
	void Start ( )
	{
        // creating the collections and adding some songs:
        SongsOfThe70s song70s = new SongsOfThe70s();
        song70s.AddSong("song title", "song artist", 1974);
        song70s.AddSong("song title2", "song artist2", 1978);

        SongsOfThe80s song80s = new SongsOfThe80s();
        song80s.AddSong("song title 80s", "song artist 80s", 1985);
        song80s.AddSong("song title2 80s", "song artist2 80s", 1989);

        // because of the iterator pattern we can loop through both types
        // of collections the same simple way and don't have to bother
        // with what type of collection the object stores:

        IEnumerator songsOfThe70sIterator = song70s.GetIterator();
        while (songsOfThe70sIterator.MoveNext())
        {
            SongInfo info = (SongInfo)songsOfThe70sIterator.Current;
            Debug.Log("Song 70s: " + info.ToStringEx());
        }

        IEnumerator songsOfThe80sIterator = song80s.GetIterator();
        while (songsOfThe80sIterator.MoveNext())
        {
            SongInfo info = (SongInfo)songsOfThe80sIterator.Current;
            Debug.Log("Song 80s: " + info.ToStringEx());
        }
    }



    // just a sample object to hold some arbitrary information for demonstration
    public class SongInfo
    {
        public string songName { get; protected set; }

        public string bandName { get; protected set; }

        public int yearReleased { get; protected set; }

        public SongInfo(string songName, string bandName, int yearReleased)
        {
            this.songName = songName;
            this.bandName = bandName;
            this.yearReleased = yearReleased;
        }

        public string ToStringEx()
        {
            return this.songName + " - " + this.bandName + " : " + this.yearReleased.ToString();
        }
    }



    // Iterator Interface
    public interface SongIterator
    {
        IEnumerator GetIterator();
    }



    // These two classes implement the iterator
    public class SongsOfThe70s : SongIterator
    {
        // here it is a list
        protected List<SongInfo> bestSongs;

        public SongsOfThe70s()
        {
            bestSongs = new List<SongInfo>();
        }

        public void AddSong(string name, string artist, int year)
        {
            SongInfo song = new SongInfo(name, artist, year);
            bestSongs.Add(song);
        }

        //about yeild return :http://www.jb51.net/article/54810.htm
        // heart
        public IEnumerator GetIterator()
        {
            foreach (SongInfo song in bestSongs)
                yield return song;
            yield break;
        }
    }

    public class SongsOfThe80s : SongIterator
    {
        // here we have an array
        protected SongInfo[] bestSongs;

        public SongsOfThe80s()
        {
            bestSongs = new SongInfo[0];
        }

        public void AddSong(string name, string artist, int year)
        {
            SongInfo song = new SongInfo(name, artist, year);
            // just for the sake of easyness of appending something we will convert the array to a list
            List<SongInfo> newSongs = new List<SongInfo>(bestSongs);
            // add a new element
            newSongs.Add(song);
            // and convert it back to an array
            bestSongs = newSongs.ToArray();
        }

        // heart
        public IEnumerator GetIterator()
        {
            foreach (SongInfo song in bestSongs)
                yield return song;
            yield break;
        }
    }



}



