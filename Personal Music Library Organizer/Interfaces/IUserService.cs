using SyncWave.Models;

namespace SyncWave.Interfaces;

internal interface IUserService
{
    User Create(User user);
    User Update(User user);
    bool Delete(int id);
    User Get(int id);
    List<User> GetAll();
    (bool foundUser, bool foundLibrary) AddLibrary(int userId, int libraryId);
    (bool foundUser, bool foundLibrary) RemoveUserLibrary(int userId, int libraryId);
}
