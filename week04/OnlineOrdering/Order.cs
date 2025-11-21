using System;
using System.Collections.Generic;

public class Order
{
    // attributes (member variables)
    private Customer _customer;
    private List<Product> _products;

    // constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // behavior (methods)
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double ComputeTotalBill()
    {
        double totalProductCost = 0;
        double totalBill = 0;

        foreach (Product product in _products)
        {
            totalProductCost += product.ComputeProductCost();
        }

        if (_customer.LivesInUSA())
        {

            totalBill = totalProductCost + 5;
        }
        else
        {
            totalBill = totalProductCost + 35;
        }

        return totalBill;
    }

    public void PrintPackingLabel()
    {
        Console.WriteLine("Packing Label:");

        foreach (Product product in _products)
        {
            Console.WriteLine(product.GetProductDetails());
        }
    }

    public void PrintShippingLabel()
    {
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(_customer.GetCustomerName());
        Console.WriteLine(_customer.GetAddress());
    }
}