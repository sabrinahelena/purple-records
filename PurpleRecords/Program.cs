using Application.Requests;
using Application.Requests.Enums;
using Application.Requests.ValueObjects;
using Application.Services;
using Infrastructure;
using Infrastructure.Repositories;

namespace PurpleRecords;

public class Program
{
    private static IUserService _service;

    static Program()
    {
        var dbContext = new PurpleRecordsContext();
        var repository = new PurpleRecordsRepository(dbContext);
        _service = new UserService(repository);
    }

    static void Main(string[] args)
    {
        bool exit = false;

        do
        {
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1. Adicionar artista");
            Console.WriteLine("2. Adicionar produtor");
            Console.WriteLine("3. Buscar artista por ID");
            Console.WriteLine("4. Atualizar artista por ID");
            Console.WriteLine("5. Atualizar produtor por ID");
            Console.WriteLine("6. Listar todos os usuários");
            Console.WriteLine("7. Listar todos os artistas");
            Console.WriteLine("8. Listar todos os produtores");
            Console.WriteLine("9. Deletar um artista");
            Console.WriteLine("10. Deletar um produtor");
            Console.WriteLine("11. Sair");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddArtist();
                    break;
                case "2":
                    AddProducer();
                    break;
                case "3":
                    GetUserById();
                    break;
                case "4":
                    UpdateArtist();
                    break;
                case "5":
                    UpdateProducer();
                    break;
                case "6":
                    ListAllUsers();
                    break;
                case "7":
                    ListAllArtists();
                    break;
                case "8":
                    ListAllProducers();
                    break;
                case "9":
                    DeleteArtist();
                    break;
                case "10":
                    DeleteProducer();
                    break;
                case "11":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine("******************************");

        } while (!exit);
    }

    private static void AddArtist()
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

        Console.Write("Nome artístico se tiver: ");
        string artistName = Console.ReadLine();

        var artist = new ArtistRequest
        {
            ArtistName = artistName,
            Name = name,
            LastName = lastName,
            Email = new EmailValue(email),
            Password = new PasswordValue(password)
        };

        int id = _service.CreateArtist(artist);

        Console.WriteLine("O id criado foi: " + id);
    }

    private static void AddProducer()
    {
        Console.WriteLine("Vamos adicionar um produtor. Por favor, forneça as seguintes informações:");

        Console.Write("Nome do produtor: ");
        string name = Console.ReadLine();

        Console.Write("Sobrenome do produtor: ");
        string lastName = Console.ReadLine();

        Console.Write("Email do produtor: ");
        string email = Console.ReadLine();

        Console.Write("Senha do produtor: ");
        string password = Console.ReadLine();


        var producer = new ProducerRequest
        {
            Name = name,
            LastName = lastName,
            Email = new EmailValue(email),
            Password = new PasswordValue(password)
        };

        int id = _service.CreateProducer(producer);

        Console.WriteLine("O id criado foi: " + id);
    }

    private static void GetUserById()
    {
        Console.WriteLine("Vamos buscar um usuário");
        Console.Write("Digite o id: ");
        int.TryParse(Console.ReadLine(), out int idToSearch);

        var user = _service.GetUserById(idToSearch);

        if (user != null)
        {
            if (user.Type == UserType.Artist)
            {
                Console.WriteLine("Informações do Artista:");
                Console.WriteLine($"Nome: {user.Name}");
                Console.WriteLine($"Sobrenome: {user.LastName}");
                Console.WriteLine($"Email: {user.Email.EmailAddress}");
                Console.WriteLine($"Senha: {user.Password.Password}");
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

    private static void UpdateArtist()
    {
        Console.WriteLine("Vamos atualizar um artista. Por favor, forneça as seguintes informações:");

        Console.Write("Id do artista: ");
        int.TryParse(Console.ReadLine(), out int idArtist);

        Console.Write("Nome do artista: ");
        string name = Console.ReadLine();

        Console.Write("Sobrenome do artista: ");
        string lastName = Console.ReadLine();

        Console.Write("Email do artista: ");
        string email = Console.ReadLine();

        Console.Write("Senha do artista: ");
        string password = Console.ReadLine();

        Console.Write("Nome artístico se tiver: ");
        string artistName = Console.ReadLine();

        var artist = new ArtistRequest();
        artist.UpdateArtist(email, password, name, lastName, artistName);

        _service.UpdateArtist(artist, idArtist);

    }

    private static void UpdateProducer()
    {
        Console.WriteLine("Vamos atualizar um produtor. Por favor, forneça as seguintes informações:");

        Console.Write("Id do produtor: ");
        int.TryParse(Console.ReadLine(), out int idArtist);

        Console.Write("Nome do produtor: ");
        string name = Console.ReadLine();

        Console.Write("Sobrenome do produtor: ");
        string lastName = Console.ReadLine();

        Console.Write("Email do produtor: ");
        string email = Console.ReadLine();

        Console.Write("Senha do produtor: ");
        string password = Console.ReadLine();


        var producer = new ProducerRequest();
        producer.UpdateProducer(email, password, name, lastName);

        _service.UpdateProducer(producer, idArtist);
    }

    private static void DeleteArtist()
    {
        Console.WriteLine("Vamos deletar um artista. Por favor, forneça as seguintes informações:");

        Console.Write("Id do produtor: ");
        int.TryParse(Console.ReadLine(), out int idArtist);

        _service.DeleteArtist(idArtist);
    }

    private static void DeleteProducer()
    {
        Console.WriteLine("Vamos deletar um produtor. Por favor, forneça as seguintes informações:");

        Console.Write("Id do produtor: ");
        int.TryParse(Console.ReadLine(), out int idProducer);

        _service.DeleteProducer(idProducer);
    }

    private static void ListAllUsers()
    {
        // codigo
    }

    private static void ListAllArtists()
    {
        // Código para listar todos os artistas
    }

    private static void ListAllProducers()
    {
        // Código para listar todos os produtores
    }
}