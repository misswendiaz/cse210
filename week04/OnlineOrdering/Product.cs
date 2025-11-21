using System;

public class Product
{
    // attributes (member variables)
    private string _productName;
    private string _productID;
    private double _price;
    private int _quantity;

    // constructor
    public Product(int quantity, string productName, string productID, double price)
    {
        _quantity = quantity; 
        _productName = productName;
        _productID = productID;
        _price = price;
    }

    // getters
    public string GetProductDetails()
    {
        string productDetails = $"{_quantity} x {_productName} (ID: {_productID}) - ${_price} each";
        return productDetails;
    }

    // behaviors (methods)
    public double ComputeProductCost()
    {
        double productCost = _quantity * _price;
        return productCost;
    }
}