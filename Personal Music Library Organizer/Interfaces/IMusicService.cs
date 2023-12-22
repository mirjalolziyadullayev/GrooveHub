using SyncWave.Models;

namespace SyncWave.Interfaces;

internal interface IMusicService
{
    Music Create(Music music);
    Music Update(Music music);
    bool Delete(int id);
    Music GetMusic(int id);
    List<Music> GetAll();
    List<Music> GetAllByGenre(string genre);
}
