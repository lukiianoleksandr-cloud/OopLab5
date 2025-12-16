using System;

public class Product
{
    private string name;
    private decimal cost;

    public Product(string name, decimal cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Ім'я не може бути порожнім.");
            }
            this.name = value;
        }
    }

    public decimal Cost
    {
        get => this.cost;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Гроші не можуть бути від'ємними"); 
            }
            this.cost = value;
        }
    }
}