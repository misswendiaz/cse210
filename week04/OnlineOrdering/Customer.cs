using System;

public class Customer
{
    // attributes (member variables)
    private string _name;
    private Address _address;

    // constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // getters
    public string GetCustomerName()
    {
        return _name;
    }

    public string GetAddress()
    {
        return _address.GetAddress();
    }

    // behaviors (methods)
    public bool LivesInUSA()
    {
        return _address.InUSA();
    }
}