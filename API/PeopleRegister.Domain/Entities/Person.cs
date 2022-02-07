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

    public Person() { }

    public Person(string name, string lastName, string cPF, string nacionality, string cEP, string state, string city, string address, string email, string phone)
    {
        Name = name;
        LastName = lastName;
        CPF = cPF;
        Nacionality = nacionality;
        CEP = cEP;
        State = state;
        City = city;
        Address = address;
        Email = email;
        Phone = phone;

        AddNotifications(new Contract()
            .IsCep(CEP, nameof(CEP), Messages.InvalidCEP)
            .IsCpf(CPF, nameof(CPF), Messages.InvalidCPF)
            .IsPhone(Phone, nameof(Phone), Messages.InvalidPhone)
            .IsLowerThan(Name, 50, nameof(Name), Messages.InvalidName)
            .IsLowerThan(LastName, 50, nameof(LastName), Messages.InvalidLastName)
            .IsLowerThan(Nacionality, 50, nameof(Nacionality), Messages.InvalidNacionality)
            .IsLowerThan(Address, 100, nameof(Address), Messages.InvalidAddress)
            .AreEquals(State, 2, nameof(State), Messages.InvalidState)
            .IsLowerThan(City, 50, nameof(City), Messages.InvalidCity)
        );
    }
}