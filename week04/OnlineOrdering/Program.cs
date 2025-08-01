using System;
using System.Collections.Generic;

// Address class
public class Address
{
    private string street;
    private string city;
    private string stateOrProvince;
    private string country;

    public Address(string street, string city, string stateOrProvince, string country)
    {
        this.street = street;
        this.city = city;
        this.stateOrProvince = stateOrProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Trim().ToUpper() == "USA";
    }

    public string GetFullAddress()
    {
        return $"{street}\n{city}, {stateOrProvince}\n{country}";
    }
}

// Customer class
public class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public string GetName()
    {
        return name;
    }

    public Address GetAddress()
    {
        return address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }
}

// Product class
public class Product
{
    private string name;
    private string productId;
    private decimal price;
    private int quantity;

    public Product(string name, string productId, decimal price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public string GetName()
    {
        return name;
    }

    public string GetProductId()
    {
        return productId;
    }

    public decimal GetTotalCost()
    {
        return price * quantity;
    }
}

// Order class
public class Order
{
    private List<Product> products = new List<Product>();
    private Customer customer;

    public Order(Customer customer)
    {
        this.customer = customer;
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var product in products)
        {
            total += product.GetTotalCost();
        }
        total += customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in products)
        {
            label += $"- {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{customer.GetName()}\n{customer.GetAddress().GetFullAddress()}";
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");

        // First order (USA)
        var address1 = new Address("123 Main St", "Springfield", "IL", "USA");
        var customer1 = new Customer("John Doe", address1);
        var order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "A100", 999.99m, 1));
        order1.AddProduct(new Product("Mouse", "B200", 25.50m, 2));

        // Second order (International)
        var address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        var customer2 = new Customer("Jane Smith", address2);
        var order2 = new Order(customer2);
        order2.AddProduct(new Product("Tablet", "C300", 350.00m, 1));
        order2.AddProduct(new Product("Stylus Pen", "D400", 19.99m, 3));

        // Display order 1
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice():0.00}");
        Console.WriteLine(new string('-', 40));

        // Display order 2
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice():0.00}");
        Console.WriteLine(new string('-', 40));
    }
}