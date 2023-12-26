using Application.Requests;
using Application.Requests.Enums;
using Application.Requests.ValueObjects;
using Domain.AggregatesModel;
using Domain.Interfaces;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IPurpleRecordsRepository _repository;
        public UserService(IPurpleRecordsRepository repository)
        {
            _repository = repository;
        }

        public int CreateArtist(ArtistRequest artist)
        {
            var userModel = new UserModel
            {
                Email = artist.Email.EmailAddress,
                LastName = artist.LastName,
                Name = artist.Name,
                Password = artist.Password.Password,
                Type = (int)UserType.Artist
            };

            int artistId = _repository.CreateUser(userModel);
            return artistId;
        }

        public int CreateProducer(ProducerRequest producer)
        {
            var userModel = new UserModel
            {
                Email = producer.Email.EmailAddress,
                LastName = producer.LastName,
                Name = producer.Name,
                Password = producer.Password.Password,
                Type = (int)UserType.Producer
            };

            int producerId = _repository.CreateUser(userModel);
            return producerId;
        }

        public List<ArtistRequest> GetAllArtists()
        {
            var artists = _repository.GettAllUsers();

            return artists
                .Where(artist => artist.Type == 1)
                .Select(artist => new ArtistRequest
                {
                    ArtistName = artist.Name,
                    Email = new EmailValue(artist.Email),
                    LastName = artist.LastName,
                    Name = artist.Name,
                    Password = new PasswordValue(artist.Password),
                    Type = (UserType)artist.Type
                })
                .ToList();
        }

        public List<ProducerRequest> GetAllProducers()
        {
            var producers = _repository.GettAllUsers();

            return producers
                .Where(producer => producer.Type == 2)
                .Select(producer => new ProducerRequest
                {
                    Email = new EmailValue(producer.Email),
                    LastName = producer.LastName,
                    Name = producer.Name,
                    Password = new PasswordValue(producer.Password),
                    Type = (UserType)producer.Type
                })
                .ToList();
        }

        public List<UserRequest> GetAllUsers()
        {
            var users = _repository.GettAllUsers();
            return users
                .Select(user => new UserRequest
                {
                    Email = new EmailValue(user.Email),
                    LastName = user.LastName,
                    Name = user.Name,
                    Password = new PasswordValue(user.Password),
                    Type = (UserType)user.Type
                })
                .ToList();
        }

        public UserRequest GetUserById(int id)
        {
            var user = _repository.GetUserById(id);
            return new UserRequest
            {
                Email = new EmailValue(user.Email),
                LastName = user.LastName,
                Name = user.Name,
                Password = new PasswordValue(user.Password),
                Type = (UserType)user.Type
            };
        }

        public void UpdateArtist(ArtistRequest artist, int id)
        {
            var userModel = new UserModel
            {
                Id = id,
                Email = artist.Email.EmailAddress,
                LastName = artist.LastName,
                Name = artist.Name,
                Password = artist.Password.Password,
                Type = (int)UserType.Artist
            };

            _repository.UpdateUser(userModel);
        }

        public void UpdateProducer(ProducerRequest producer, int id)
        {
            var userModel = new UserModel
            {
                Id = id,
                Email = producer.Email.EmailAddress,
                LastName = producer.LastName,
                Name = producer.Name,
                Password = producer.Password.Password,
                Type = (int)UserType.Artist
            };

            _repository.UpdateUser(userModel);
        }
    }
}
