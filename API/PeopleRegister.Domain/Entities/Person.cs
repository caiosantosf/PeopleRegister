using Flunt.Notifications;
using Flunt.Br;
using Flunt.Br.Extensions;
using PeopleRegister.Domain.Notifications;

namespace PeopleRegister.Domain.Entities;

public class Person : BaseEntity
{
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

    public Person(string name, string lastName, string cpf, string nacionality, string cep, string state, string city, string address, string email, string phone) : base()
    {
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

        AddNotifications(new Contract()
            .IsCep(CEP, nameof(CEP), Messages.InvalidCEP)
            .IsCpf(CPF, nameof(CPF), Messages.InvalidCEP)
            .IsPhone(Phone, nameof(Phone), Messages.InvalidPhone)
            .AreEquals(Name, 50, Messages.InvalidName)
            .AreEquals(LastName, 50, Messages.InvalidLastName)
            .AreEquals(Nacionality, 50, Messages.InvalidNacionality)
            .AreEquals(Address, 100, Messages.InvalidAddress)
            .AreEquals(State, 2, Messages.InvalidState)
            .AreEquals(City, 50, Messages.InvalidCity)
        );
    }
}