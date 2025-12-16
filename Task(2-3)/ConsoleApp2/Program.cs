using System;

class Program
{
    static void Main()
    {
        try
        {
            string[] pizzaData = Console.ReadLine().Split();
            string pizzaName = pizzaData[1];

            string[] doughData = Console.ReadLine().Split();
            string doughType = doughData[1];
            string bakingTechnique = doughData[2];
            double doughWeight = double.Parse(doughData[3]);

            Dough dough = new Dough(doughType, bakingTechnique, doughWeight);
            Pizza pizza = new Pizza(pizzaName, dough);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] toppingData = command.Split();
                string toppingType = toppingData[1];
                double toppingWeight = double.Parse(toppingData[2]);

                Topping topping = new Topping(toppingType, toppingWeight);
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name}\n{pizza.TotalCalories():F2} Calories.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}