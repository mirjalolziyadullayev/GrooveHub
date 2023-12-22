using SyncWave.Interfaces;
using SyncWave.Models;

namespace SyncWave.Services;

public class LibraryService : ILibraryService
{
    private IMusicService musicService;
    private List<Library> libraries;
    public LibraryService(MusicService musicService)
    {
        this.musicService = musicService;
        libraries = new List<Library>();
    }

    public Library Create(Library library)
    {
        library.Id = libraries.Count + 1;
        libraries.Add(library);
        return library;
    }
    public Library Update(Library library)
    {
        Library found = null;
        foreach (Library item in libraries)
        {
            if (item.Id == library.Id)
            {
                item.Name = library.Name;
                item.Genre = library.Genre;
                found = item;
                break;
            }
        }
        return found;
    }
    public bool Delete(int id)
    {
        bool found = false;
        foreach (Library library in libraries)
        {
            if (library.Id == id)
            {
                found = true;
                libraries.Remove(library);
                break;
            }
        }
        return found;
    }
    public Library GetLibrary(int id)
    {
        Library found = null;
        foreach (Library library in libraries)
        {
            if (library.Id == id)
            {
                found = library;
                break;
            }
        }
        return found;
    }
    public (bool foundLibrary, bool foundMusic) AddMusic(int libraryID, int musicID)
    {
        bool foundLibrary = false;
        bool foundMusic = false;
        foreach (Library library in libraries)
        {
            if (library.Id == libraryID)
            {
                Music music = musicService.GetMusic(musicID);
                if (music != null)
                {
                    foundMusic = true;
                    library.Musics.Add(music);
                }
                foundLibrary = true;
                break;
            }
        }
        return (foundLibrary, foundMusic);
    }
    public List<Library> GetAll()
    {
        return libraries;
    }
    public (bool foundLibrary, bool foundMusic) RemoveMusic(int libraryID, int musicID)
    {
        bool foundLibrary = false;
        bool foundMusic = false;
        foreach (Library library in libraries)
        {
            if (library.Id == libraryID)
            {
                foreach (Music music in library.Musics)
                {
                    if (music.Id == musicID)
                    {
                        foundMusic = true;
                        library.Musics.Remove(music);
                    }
                }
                foundLibrary = true;
                break;
            }
        }
        return (foundLibrary, foundMusic);
    }
}
