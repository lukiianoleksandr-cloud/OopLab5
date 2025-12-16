using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            Dictionary<string, Person> people = new Dictionary<string, Person>();
            string[] peopleInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string p in peopleInput)
            {
                string[] parts = p.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = parts[0];
                decimal money = decimal.Parse(parts[1]);
                people.Add(name, new Person(name, money));
            }

            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string[] productInput = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string p in productInput)
            {
                string[] parts = p.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                string name = parts[0];
                decimal cost = decimal.Parse(parts[1]);
                products.Add(name, new Product(name, cost));
            }

            string command;
            while (true)
            {
                command = Console.ReadLine();

                if (command.ToUpper() == "END")
                {
                    break;
                }

                string[] parts = command.Split();

                if (parts.Length != 2)
                {
                    continue;
                }

                string personName = parts[0];
                string productName = parts[1];

                if (people.ContainsKey(personName) && products.ContainsKey(productName))
                {
                    people[personName].BuyProduct(products[productName]);
                }
            }

            foreach (Person person in people.Values)
            {
                Console.WriteLine(person.ToString());
            }
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