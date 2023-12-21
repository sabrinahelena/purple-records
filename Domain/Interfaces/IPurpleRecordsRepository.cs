using Domain.AggregatesModel;

namespace Domain.Interfaces
{
    public interface IPurpleRecordsRepository
    {
        int CreateUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(UserModel user);
        UserModel GetUserById(int id);
        List<UserModel> GettAllUsers();

        //Musicas

        int CreateMusic(MusicModel music);
        void UpdateMusic(MusicModel music);
        void DeleteMusic(MusicModel music);
        MusicModel GetMusicById(int id);
        List<MusicModel> GetAllMusic();


        //Album
        int CreateAlbum(AlbumModel album);
        void UpdateAlbum(AlbumModel album);
        void DeleteAlbum(AlbumModel album);
        AlbumModel GetAlbumById(int id);
        List<AlbumModel> GetAllAlbums();

    }
}
