using Domain.AggregatesModel;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public class PurpleRecordsRepository : IPurpleRecordsRepository
{
    protected readonly PurpleRecordsContext _context;

    public PurpleRecordsRepository(PurpleRecordsContext context)
    {
        _context = context;
    }
    public int CreateAlbum(AlbumModel album)
    {
        _context.Albums.Add(album);
        _context.SaveChanges();
        return album.Id;
    }

    public int CreateMusic(MusicModel music)
    {
        _context.Musics.Add(music);
        _context.SaveChanges();
        return music.Id;
    }

    public int CreateUser(UserModel user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.Id;
    }

    public void DeleteAlbum(AlbumModel album)
    {
        _context.Albums.Remove(album);
    }

    public void DeleteMusic(MusicModel music)
    {
        _context.Musics.Remove(music); 
    }

    public void DeleteUser(UserModel user)
    {
        _context.Users.Remove(user);
    }

    public AlbumModel GetAlbumById(int id)
    {
        return _context.Albums.FirstOrDefault(x => x.Id == id);
    }

    public List<AlbumModel> GetAllAlbums()
    {
        return _context.Albums.ToList();
    }

    public List<MusicModel> GetAllMusic()
    {
        return _context.Musics.ToList();
    }

    public MusicModel GetMusicById(int id)
    {
        return _context.Musics.FirstOrDefault(x => x.Id == id);
    }

    public List<UserModel> GettAllUsers()
    {
        return _context.Users.ToList();
    }

    public UserModel GetUserById(int id)
    {
        return _context.Users.FirstOrDefault(x => x.Id == id);
    }

    public void UpdateAlbum(AlbumModel album)
    {
        _context.Albums.Update(album);
    }

    public void UpdateMusic(MusicModel music)
    {
        _context.Musics.Update(music);
    }

    public void UpdateUser(UserModel user)
    {
        _context.Users.Update(user);
    }
}
