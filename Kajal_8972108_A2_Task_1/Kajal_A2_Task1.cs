using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kajal_8972108_A2_Task1
{
    public class Customer
    {
        // Properties to store customer information
        public string Name { get; set; }
        public string BuildingType { get; set; }
        public int BuildingSize { get; set; }
        public int NumberOfLightBulbs { get; set; }
        public int NumberOfOutlets { get; set; }
        public string CreditCard { get; set; }

        // Method to perform tasks based on the building type
        public void PerformSpecificTasks()
        {
            // Check if the building type is 'house'
            if (BuildingType.ToLower() == "house")
            {
                Console.WriteLine($"- Installing fire alarms for {Name}'s House...");
            }
            // Check if the building type is 'barn'
            else if (BuildingType.ToLower() == "barn")
            {
                Console.WriteLine($"- Wiring milking equipment for {Name}'s Barn...");
            }
            // Check if the building type is 'garage'
            else if (BuildingType.ToLower() == "garage")
            {
                Console.WriteLine($"- Installing automatic doors for {Name}'s Garage...");
            }
            else
            {
                // If an invalid building type is entered
                Console.WriteLine("Invalid building type entered.");
            }
        }

        // Method to display customer info in one line
        public void DisplayInfo()
        {
            // Print customer details in a single line with all relevant details
            Console.WriteLine($"Customer Name: {Name}, Building Type: {BuildingType}, Size: {BuildingSize} sq.ft, Light Bulbs: {NumberOfLightBulbs}," +
                $" Outlets: {NumberOfOutlets}, Credit Card: {CreditCard}");
        }
    }

    public class Kajal_A2_Task1
    {
        public static void Main(string[] args)
        {
            // List to store all customers
            List<Customer> customers = new List<Customer>();
            string input;

            while (true) // Continue loop until user decides to stop adding customers
            {
                Console.WriteLine("Enter Customer Details:");

                // Ask for the customer's name
                string name;
                while (true)
                {
                    Console.Write("Customer Name: ");
                    name = Console.ReadLine();
                    if (Regex.IsMatch(name, @"^[a-zA-Z]+$"))  // Allow only alphabetic characters
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid name. Please enter only alphabetic characters.");
                    }
                }

                // Validate the building type (must be one of house, barn, or garage)
                string buildingType;
                while (true)
                {
                    Console.Write("Enter the building type (House/Barn/Garage): ");
                    buildingType = Console.ReadLine().Trim().ToLower(); // Convert to lowercase for easy comparison
                    if (buildingType == "house" || buildingType == "barn" || buildingType == "garage")
                    {
                        break;  // If the input is valid, exit the loop
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'House', 'Barn', or 'Garage'.");
                    }
                }

                // Validate the building size input (must be between 1000 and 50000 sq. ft.)
                int buildingSize;
                while (true)
                {
                    Console.Write("Enter the size of the building (1000 to 50000 sq. ft.): ");
                    string sizeInput = Console.ReadLine().Trim();
                    if (int.TryParse(sizeInput.Split(' ')[0], out buildingSize) && buildingSize >= 1000 && buildingSize <= 50000)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a size between 1000 and 50000 sq. ft.");
                    }
                }

                // Validate the number of light bulbs input (must be between 1 and 20)
                int lightBulbs;
                while (true)
                {
                    Console.Write("Enter the number of light bulbs (1 to 20): ");
                    if (int.TryParse(Console.ReadLine(), out lightBulbs) && lightBulbs >= 1 && lightBulbs <= 20)
                    {
                        break;  // If the input is valid, exit the loop
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 20 for light bulbs.");
                    }
                }

                // Validate the number of outlets input (must be between 1 and 50)
                int outlets;
                while (true)
                {
                    Console.Write("Enter the number of outlets (1 to 50): ");
                    if (int.TryParse(Console.ReadLine(), out outlets) && outlets >= 1 && outlets <= 50)
                    {
                        break;  // If the input is valid, exit the loop
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 50 for outlets.");
                    }
                }

                // Validate the credit card format (must be a 16-digit number)
                string creditCard;
                while (true)
                {
                    Console.Write("Enter credit card (XXXX XXXX XXXX XXXX): ");
                    creditCard = Console.ReadLine().Trim(); // Remove extra spaces

                    // Ensure the credit card is in the required format (four groups of four digits)
                    if (Regex.IsMatch(creditCard, @"^\d{4} \d{4} \d{4} \d{4}$"))
                    {
                        Console.WriteLine("Valid credit card format!");  // If valid, notify the user
                        break;  // Exit the loop if the format is valid
                    }
                    else
                    {
                        Console.WriteLine("Invalid format. Please enter in XXXX XXXX XXXX XXXX format.");
                    }
                }

                // Create a new Customer object and populate it with the provided details
                Customer customer = new Customer()
                {
                    Name = name,
                    BuildingSize = buildingSize,
                    NumberOfLightBulbs = lightBulbs,
                    NumberOfOutlets = outlets,
                    CreditCard = creditCard,
                    BuildingType = buildingType
                };
                customers.Add(customer);  // Add the new customer to the customers list

                // Display the tasks to be performed for the current customer
                Console.WriteLine($"\nExecuting Tasks for {customer.Name}:");
                customer.PerformSpecificTasks();  // Call the method to perform tasks based on the building type

                // Ask if the user wants to add another customer
                while (true)  // Continue prompting the user until a valid response is given
                {
                    Console.Write("\nDo you want to add another customer? (yes/no): ");
                    input = Console.ReadLine().ToLower();  // Convert the input to lowercase for easy comparison

                    // Check if the input is valid
                    if (input == "yes" || input == "y")
                    {
                        break;  // Continue adding another customer
                    }
                    else if (input == "no" || input == "n")
                    {
                        break;  // Exit the loop
                    }
                    else
                    {
                        // If input is invalid, inform the user and ask again
                        Console.WriteLine("Invalid input. Please enter 'yes' to continue or 'no' to exit.");
                    }
                }

                // If the user enters 'no' or 'n', break out of the loop and exit
                if (input == "no" || input == "n")
                {
                    break;
                }
            }

            // Display the customer appointment summary after all customers have been added
            Console.WriteLine("\nCustomer Appointment Summary:"); // Display summary header
            foreach (var customer in customers)  // Loop through each customer in the list
            {
                customer.DisplayInfo();  // Call the DisplayInfo method to print customer details in one line
            }
        }
    }
}