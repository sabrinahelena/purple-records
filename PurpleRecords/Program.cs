using Application.Requests;
using Application.Requests.Enums;
using Application.Services;
using Infrastructure;
using Infrastructure.Repositories;

namespace PurpleRecords
{
    public class Program
    {
        private static IPurpleRecordsService _service;
        static Program()
        {
            var dbContext = new PurpleRecordsContext();
            var repository = new PurpleRecordsRepository(dbContext);
            _service = new PurpleRecordsService(repository);
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Vamos adicionar um artista. Por favor, forneça as seguintes informações:");

            Console.Write("Nome do artista: ");
            string name = Console.ReadLine();

            Console.Write("Sobrenome do artista: ");
            string lastName = Console.ReadLine();

            Console.Write("Email do artista: ");
            string email = Console.ReadLine();

            Console.Write("Senha do artista: ");
            string password = Console.ReadLine();

            Console.Write("Nome artistico se tiver: ");
            string artistName = Console.ReadLine();

            var artista = new ArtistRequest
            {
                ArtistName = artistName,
                Name = name,
                LastName = lastName,
                Email = email,
                Password = password
            };

            int id = _service.CreateArtist(artista);

            Console.WriteLine("o id criado foi: " + id);

            Console.WriteLine("******************************");

            Console.WriteLine("Vamos buscar um artista");
            Console.WriteLine("Digite o id:");
            int.TryParse(Console.ReadLine(), out int idPraBuscar);

          
            var user = _service.GetUserById(idPraBuscar);
            if (user != null)
            {
                if (user.Type == UserType.Artist)
                {
                    Console.WriteLine("Informações do Artista:");
                    Console.WriteLine($"Nome: {user.Name}");
                    Console.WriteLine($"Sobrenome: {user.LastName}");
                    Console.WriteLine($"Email: {user.Email}");
                    Console.WriteLine($"Senha: {user.Password}");
                }
                else
                {
                    Console.WriteLine("Isso não é um artista.");
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }

        }
    }
}