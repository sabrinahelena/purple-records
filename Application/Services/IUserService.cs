using Application.Requests;

namespace Application.Services
{
    public interface IUserService
    {
        int CreateArtist(ArtistRequest artist);
        int CreateProducer(ProducerRequest producer);
        UserRequest GetUserById(int id);
        void UpdateArtist(ArtistRequest artist, int id);
        void UpdateProducer(ProducerRequest producer, int id);
        List<UserRequest> GetAllUsers();
        List<ArtistRequest> GetAllArtists();
        List<ProducerRequest> GetAllProducers(); 
        void DeleteArtist(int id);  
        void DeleteProducer(int id);
    }
}
