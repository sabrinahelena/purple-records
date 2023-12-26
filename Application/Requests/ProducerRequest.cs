namespace Application.Requests;

public class ProducerRequest : UserRequest
{
    public void UpdateProducer(string email, string password, string name, string lastName)
    {
        if (!string.IsNullOrEmpty(email))
            Email = new ValueObjects.EmailValue(email);

        if (!string.IsNullOrEmpty(password))
            Password = new ValueObjects.PasswordValue(password);

        if (!string.IsNullOrEmpty(name))
            Name = name;

        if (!string.IsNullOrEmpty(lastName))
            LastName = lastName;
    }
}
