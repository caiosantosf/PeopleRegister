namespace PeopleRegister.Application.DTOs;

public class PersonDTO
{
    public Guid Id { get; set; }
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string CPF { get; private set; }
    public string Nacionality { get; private set; }
    public string CEP { get; private set; }
    public string State { get; private set; }
    public string City { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }

    public PersonDTO(Guid id, string name, string lastName, string cpf, string nacionality, string cep, string state, string city, string address, string email, string phone)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        CPF = cpf;
        Nacionality = nacionality;
        CEP = cep;
        State = state;
        City = city;
        Address = address;
        Email = email;
        Phone = phone;
    }
}
