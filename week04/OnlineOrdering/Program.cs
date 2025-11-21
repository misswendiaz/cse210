using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        Console.WriteLine();


        List<Order> orders = new List<Order>();

        // First Order
        Address address1 = new Address(
            "742 Evergreen Terrace",

            "Springfield",

            "Illinois",

            "62704",

            "USA"
        );

        Customer customer1 = new Customer("Homer Simpson", address1);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product(12, "Donut", "F001", 1.25));
        order1.AddProduct(new Product(6, "Cola Drink", "D777", 3.99));
        order1.AddProduct(new Product(1, "Remote Control", "E222", 15.50));

        // Second Order
        Address address2 = new Address(
            "15 Gangnam-daero",

            "Seoul",

            "Gangnam-gu",

            "06000",

            "South Korea"
        );

        Customer customer2 = new Customer("Kim Seon-ho", address2);

        Order order2 = new(customer2);

        order2.AddProduct(new Product(1, "K-BBQ Grill", "K101", 45));
        order2.AddProduct(new Product(5, "Soju", "S555", 2.00));
        order2.AddProduct(new Product(3, "Rice Cakes (Tteok)", "T909", 4.50));


        // Third Order
        Address address3 = new Address(
            "23 Sampaguita Street",

            "Quezon City",

            "Metro Manila",

            "1100",

            "Philippines"
        );

        Customer customer3 = new Customer("Maria Santos", address3);

        Order order3 = new Order(customer3);

        order3.AddProduct(new Product(2, "Mango Jam", "P321", 3.75));
        order3.AddProduct(new Product(3, "Banana Chips", "B008", 2.50));
        order3.AddProduct(new Product(1, "Barong Tagalog", "F777", 35.00));



        orders.Add(order1);
        orders.Add(order2);
        orders.Add(order3);

        foreach(Order order in orders)
        {
            Console.WriteLine("====================================================");
            order.PrintShippingLabel();
            Console.WriteLine();
            order.PrintPackingLabel();
            Console.WriteLine();
            Console.WriteLine($"Total Bill: ${order.ComputeTotalBill()}");
            Console.WriteLine("====================================================");
        }
    }
}