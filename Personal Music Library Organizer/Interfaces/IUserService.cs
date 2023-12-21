using GrooveHub.Models;

namespace GrooveHub.Interfaces;

internal interface IUserService
{
    User Create(User user);
    User Update(User user);
    bool Delete(int id);
    User Get(int id);
    List<User> GetAll();
    bool AddLibrary(int userId, int libraryId);
    bool AddLibraryByGenre(int userID, string genre);
    bool RemoveLibrary(int userId, int libraryId);
}
