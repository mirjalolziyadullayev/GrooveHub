using SyncWave.Models;

namespace SyncWave.Interfaces;

internal interface ILibraryService
{
    Library Create(Library library);
    Library Update(Library library);
    bool Delete(int id);
    Library GetLibrary(int id);
    List<Library> GetAll();
    (bool foundLibrary, bool foundMusic) AddMusic(int libraryID, int musicID);
    (bool foundLibrary, bool foundMusic) RemoveMusic(int libraryID, int musicID);
}
