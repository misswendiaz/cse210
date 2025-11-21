using System;

public class Address
{
    // attributes (member variables)
    private string _street;
    private string _city;
    private string _stateProvince;
    private string _zipCode;
    private string _country;

    // constructor
    public Address(string street, string city, string stateProvince, string zipCode, string country)
    {
        _street = street;
        _city = city;
        _stateProvince = stateProvince;
        _zipCode = zipCode;
        _country = country;
    }

    // getters
    public string GetAddress()
    {
        string address = $"{_street}\n{_city}, {_stateProvince} {_zipCode}\n{_country}";
        return address;
    }

    // behaviors (methods)
    public bool InUSA()
    {
        if (_country.Trim().ToUpper() == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}