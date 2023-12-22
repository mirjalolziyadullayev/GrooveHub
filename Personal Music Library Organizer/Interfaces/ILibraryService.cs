using GrooveHub.Models;

namespace GrooveHub.Interfaces;

internal interface ILibraryService
{
    Library Create(Library library);
    Library Update(Library library);
    bool Delete(int id);
    Library GetLibrary(int id);
    (bool foundLibrary, bool foundMusic) AddMusic(int libraryID, int musicID);
    //(string libraryGenre, bool found) AddMusicToLibraryByGenre(string musicGenre);
}
