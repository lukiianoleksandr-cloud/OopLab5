using System;
using System.Collections.Generic;
using System.Linq;

public class Person
{
    private string name;
    private decimal money;
    private List<Product> bagOfProducts;

    public Person(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
        this.bagOfProducts = new List<Product>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ім'я не може бути порожнім");
            }
            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Гроші не можуть бути від'ємними");
            }
            this.money = value;
        }
    }

    public IReadOnlyCollection<Product> BagOfProducts => this.bagOfProducts.AsReadOnly();

    public void BuyProduct(Product product)
    {
        if (this.Money >= product.Cost)
        {
            this.Money -= product.Cost;
            this.bagOfProducts.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
        }
        else
        {
            Console.WriteLine($"{this.Name} не може дозволити собі {product.Name}");
        }
    }

    public override string ToString()
    {
        if (this.bagOfProducts.Count == 0)
        {
            return $"{this.Name} - Nothing bought";
        }
        return $"{this.Name} - {string.Join(", ", this.bagOfProducts.Select(p => p.Name))}";
    }
}