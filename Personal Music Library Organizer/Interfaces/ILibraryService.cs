using GrooveHub.Models;

namespace GrooveHub.Interfaces;

internal interface ILibraryService
{
    Library Create(Library library);
    Library Update(Library library);
    bool Delete(Library library);
    Library GetLibrary(int id);
    Library GetLibraryByMusicGenre(string genre);
    (string libraryName, string musicName) AddMusic(int libraryID, Music music);
    (string libraryGenre, string musicName) AddMusicByLibraryGenre(string genre, Library music);
}
