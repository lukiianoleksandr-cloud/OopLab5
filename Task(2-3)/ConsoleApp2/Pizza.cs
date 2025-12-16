using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int MinNameLength = 1;
    private const int MaxNameLength = 15;
    private const int MinToppings = 0;
    private const int MaxToppings = 10;

    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.dough = dough;
        this.toppings = new List<Topping>();
    }

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrEmpty(value) || value.Length > MaxNameLength)
            {
                throw new ArgumentException($"Назва піци повинна містити від {MinNameLength} до {MaxNameLength} символів");
            }
            this.name = value;
        }
    }

    public Dough Dough => this.dough;

    public IReadOnlyCollection<Topping> Toppings => this.toppings.AsReadOnly();

    public void AddTopping(Topping topping)
    {
        if (this.toppings.Count >= MaxToppings)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MinToppings}..{MaxToppings}].");
        }
        this.toppings.Add(topping);
    }

    public double TotalCalories()
    {
        double total = this.Dough.CalculateCalories();
        total += this.Toppings.Sum(t => t.CalculateCalories());
        return total;
    }
}