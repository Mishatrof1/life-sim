using System;

[Serializable]
public class Address
{
    public string Country;
    public string State;
    public string City;

    public Address()
    {
    }

    public Address(string country, string state, string city)
    {
        Country = country;
        State = state;
        City = city;
    }
}