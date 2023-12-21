using GrooveHub.Models;

namespace GrooveHub.Interfaces;

internal interface IMusicService
{
    Music Create(Music music);
    Music GetMusic(int id);
    Music Update(Music music);
    bool Delete(int id);
    Music GetByGenre(string genre);
    List<Music> GetAll();
}
