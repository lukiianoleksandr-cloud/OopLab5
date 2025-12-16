using System;
using System.Collections.Generic;

public class Dough
{
    private const int BaseCaloriesPerGram = 2;
    private const double MinWeight = 1;
    private const double MaxWeight = 200;

    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    private string FlourType
    {
        get => this.flourType;
        set
        {
            List<string> validTypes = new List<string> { "white", "wholegrain" };
            if (!validTypes.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }

    private string BakingTechnique
    {
        get => this.bakingTechnique;
        set
        {
            List<string> validTechniques = new List<string> { "crispy", "chewy", "homemade" };
            if (!validTechniques.Contains(value.ToLower()))
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    private double Weight
    {
        get => this.weight;
        set
        {
            if (value < MinWeight || value > MaxWeight)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MinWeight}..{MaxWeight}].");
            }
            this.weight = value;
        }
    }

    private double GetFlourModifier()
    {
        return this.FlourType.ToLower() switch
        {
            "white" => 1.5,
            "wholegrain" => 1.0,
            _ => 1.0,
        };
    }

    private double GetTechniqueModifier()
    {
        return this.BakingTechnique.ToLower() switch
        {
            "crispy" => 0.9,
            "chewy" => 1.1,
            "homemade" => 1.0,
            _ => 1.0,
        };
    }

    public double CalculateCalories()
    {
        return (BaseCaloriesPerGram * this.Weight) * this.GetFlourModifier() * this.GetTechniqueModifier();
    }
}