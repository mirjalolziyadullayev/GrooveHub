using SyncWave.Interfaces;
using SyncWave.Models;

namespace SyncWave.Services;

public class UserService : IUserService
{
    private LibraryService libraryService;

    private List<User> users;
    public UserService(LibraryService libraryService)
    {
        this.libraryService = libraryService;

        users = new List<User>();
    }
    public User Create(User user)
    {
        user.Id = users.Count + 1;
        users.Add(user);
        return user;
    }
    public User Update(User user)
    {
        User found = null;
        foreach (User item in users)
        {
            if (item.Id == user.Id)
            {
                item.FirstName = user.FirstName;
                item.LastName = user.LastName;
                found = item;
                break;
            }
        }
        return found;
    }
    public bool Delete(int id)
    {
        bool found = false;
        foreach (User user in users)
        {
            if (user.Id == id)
            {
                found = true;
                users.Remove(user);
                break;
            }
        }
        return found;
    }
    public User Get(int id)
    {
        User found = null;
        foreach (User user in users)
        {
            if (user.Id == id)
            {
                found = user;
                break;
            }
        }
        return found;
    }
    public List<User> GetAll()
    {
        return users;
    }
    public (bool foundUser, bool foundLibrary) AddLibrary(int userId, int libraryId)
    {
        bool foundUser = false;
        bool foundLibrary = false;
        foreach (var user in users)
        {
            if (user.Id == userId)
            {
                foundUser = true;
                Library library = libraryService.GetLibrary(libraryId);
                if (library != null)
                {
                    foundLibrary = true;
                    if (user.SavedLibraries == null)
                    {
                        user.SavedLibraries = new List<Library>();
                    }
                    user.SavedLibraries.Add(library);
                }
                break;
            }
        }

        return (foundUser, foundLibrary);

    }
    public (bool foundUser, bool foundLibrary) RemoveUserLibrary(int userId, int libraryId)
    {
        bool foundUser = false;
        bool foundLibrary = false;
        foreach (var user in users)
        {
            if (user.Id == userId)
            {
                if (user.SavedLibraries == null)
                {
                    user.SavedLibraries = new List<Library>();
                }
                foreach (Library library in user.SavedLibraries)
                {
                    if (library.Id == libraryId)
                    {
                        user.SavedLibraries.Remove(library);
                        foundLibrary = true;
                        break;
                    }
                }
                foundUser = true;
                break;
            }
        }

        return (foundUser, foundLibrary);
    }
}
