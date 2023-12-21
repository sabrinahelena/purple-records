using Application.Requests;

namespace Application.Services
{
    public interface IPurpleRecordsService
    {
        int CreateArtist(ArtistRequest artist);
        int CreateProducer(ProducerRequest producer);
        UserRequest GetUserById(int id);
        
    }
}
