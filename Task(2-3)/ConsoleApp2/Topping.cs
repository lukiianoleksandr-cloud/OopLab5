using System;
using System.Collections.Generic;

public class Topping
{
    private const int BaseCaloriesPerGram = 2;
    private const double MinWeight = 1;
    private const double MaxWeight = 50;

    private string toppingType;
    private double weight;

    public Topping(string toppingType, double weight)
    {
        this.ToppingType = toppingType;
        this.Weight = weight;
    }

    public string ToppingType
    {
        get => this.toppingType;
        private set
        {
            List<string> validTypes = new List<string> { "meat", "veggies", "cheese", "sauce" };
            if (!validTypes.Contains(value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.toppingType = value;
        }
    }

    private double Weight
    {
        get => this.weight;
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"{this.ToppingType} weight should be in the range [{MinWeight}..{MaxWeight}].");
            }
            this.weight = value;
        }
    }

    private double GetTypeModifier()
    {
        return this.ToppingType.ToLower() switch
        {
            "meat" => 1.2,
            "veggies" => 0.8,
            "cheese" => 1.1,
            "sauce" => 0.9,
            _ => 0,
        };
    }

    public double CalculateCalories()
    {
        return (BaseCaloriesPerGram * this.Weight) * this.GetTypeModifier();
    }
}