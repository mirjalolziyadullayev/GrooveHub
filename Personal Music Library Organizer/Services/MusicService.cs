using SyncWave.Interfaces;
using SyncWave.Models;

namespace SyncWave.Services;

public class MusicService : IMusicService
{
    private List<Music> musics;

    public MusicService()
    {
        musics = new List<Music>();
    }

    public Music Create(Music music)
    {
        music.Id = musics.Count + 1;
        musics.Add(music);
        return music;
    }
    public bool Delete(int id)
    {
        bool found = false;
        foreach (Music music in musics)
        {
            if (music.Id == id)
            {
                found = true;
                musics.Remove(music);
                break;
            }
        }
        return found;
    }
    public List<Music> GetAll()
    {
        return musics;
    }
    public List<Music> GetAllByGenre(string genre)
    {
        List<Music> found = new List<Music>();
        foreach (Music music in musics)
        {
            if (music.Genre == genre)
            {
                found.Add(music);
            }
        }
        return found;
    }
    public Music GetMusic(int id)
    {
        Music found = null;
        foreach (Music music in musics)
        {
            if (music.Id == id)
            {
                found = music;
                break;
            }
        }
        return found;
    }
    public Music Update(Music music)
    {
        Music found = null;
        foreach (Music item in musics)
        {
            if (item.Id == music.Id)
            {
                item.Name = music.Name;
                item.Author = music.Author;
                item.Genre = music.Genre;
                found = item;
                break;
            }
        }
        return found;
    }
}
