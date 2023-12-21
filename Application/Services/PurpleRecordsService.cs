using Application.Requests;
using Application.Requests.Enums;
using Domain.AggregatesModel;
using Domain.Interfaces;

namespace Application.Services
{
    public class PurpleRecordsService : IPurpleRecordsService
    {
        private readonly IPurpleRecordsRepository _repository;
        public PurpleRecordsService(IPurpleRecordsRepository repository)
        {
            _repository = repository;
        }

        public int CreateArtist(ArtistRequest artist)
        {
            var userModel = new UserModel
            {
                Email = artist.Email,
                LastName = artist.LastName,
                Name = artist.Name,
                Password = artist.Password,
                Type = (int)UserType.Artist
            };

            int artistId = _repository.CreateUser(userModel);
            return artistId;
        }

        public int CreateProducer(ProducerRequest producer)
        {
            var userModel = new UserModel
            {
                Email = producer.Email,
                LastName = producer.LastName,
                Name = producer.Name,
                Password = producer.Password,
                Type = (int)UserType.Producer
            };

            int producerId = _repository.CreateUser(userModel);
            return producerId;
        }

        public UserRequest GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            return new UserRequest
            {
                Email = user.Email,
                LastName = user.LastName,
                Name = user.Name,
                Password = user.Password,
                Type = (UserType)user.Type
            };
        }
    }
}
