using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kajal_8972108_A2_Task2
{
    // 1. Interface declaration: Contains all required methods and properties.
    public interface ICustomer
    {
        string Name { get; set; }  // Customer's name property
        string BuildingType { get; set; }  // Building type (house, barn, garage) property
        int BuildingSize { get; set; }  // Size of the building in sq. ft.
        int NumberOfLightBulbs { get; set; }  // Number of light bulbs in the building
        int NumberOfOutlets { get; set; }  // Number of outlets in the building
        string CreditCard { get; set; }  // Credit card number 

        // Method to perform tasks based on building type
        void PerformSpecificTasks();

        // Method to display customer information
        void DisplayInfo();

        // Method to process payment and validate credit card
        bool Payment();
    }

    // 2. Base class implementation with abstract methods
    public abstract class CustomerBase : ICustomer, IComparable<CustomerBase>
    {
        // Properties declaration
        public string Name { get; set; }  // Customer's name
        public string BuildingType { get; set; }  // Type of building (house, barn, or garage)
        public int BuildingSize { get; set; }  // Size of building in square feet
        public int NumberOfLightBulbs { get; set; }  // Number of light bulbs
        public int NumberOfOutlets { get; set; }  // Number of outlets
        public string CreditCard { get; set; }  // Credit card number

        // Abstract method for supplementary tasks based on building type
        public abstract void PerformSpecificTasks();

        // Method to display customer info with masked credit card
        public void DisplayInfo()
        {
            // Mask the credit card number before displaying
            string maskedCard = MaskCreditCard(CreditCard);

            // Print customer details in one line
            Console.WriteLine($"Customer Name: {Name}, Building Type: {BuildingType}, Size: {BuildingSize} sq.ft, " +
                $"Light Bulbs: {NumberOfLightBulbs}, Outlets: {NumberOfOutlets}, Credit Card: {maskedCard}");
        }

        // Method to process payment by validating credit card format
        public bool Payment()
        {
            string creditCard;
            while (true)
            {
                // Prompt user to enter a 16-digit credit card number
                Console.Write("Enter credit card (XXXX XXXX XXXX XXXX): ");
                creditCard = Console.ReadLine().Trim();  // Trim spaces around input

                // Regex to validate 16-digit credit card format
                if (Regex.IsMatch(creditCard, @"^\d{4} \d{4} \d{4} \d{4}$"))
                {
                    Console.WriteLine("Payment accepted. Valid credit card.");  // If valid
                    CreditCard = creditCard; // Store the credit card in the property
                    return true;  // Return true, payment accepted
                }
                else
                {
                    Console.WriteLine("Payment declined. Invalid credit card format.");  // If invalid

                }
            }
        }

        // Method to mask the credit card number, showing only the last four digits
        private string MaskCreditCard(string cardNumber)
        {
            if (cardNumber.Length >= 4)
            {
                return "XXXX XXXX XXXX " + cardNumber.Substring(cardNumber.Length - 4);
            }
            return "Invalid Card Number";
        }

        // 3. Implementing the IComparable interface to allow sorting by BuildingSize
        public int CompareTo(CustomerBase other)
        {
            // Sort customers by building size in ascending order
            if (other == null)
                return 1;  // If the other customer is null, return 1 to move the current customer to the front

            return this.BuildingSize.CompareTo(other.BuildingSize);  // Compare by building size
        }
    }

    // A derived class for specific customer implementations
    public class Customer : CustomerBase
    {
        // Implementing PerformSpecificTasks method for this subclass
        public override void PerformSpecificTasks()
        {
            // Check the building type and perform the corresponding task
            if (BuildingType.ToLower() == "house")
            {
                // If building type is house
                Console.WriteLine($"- Installing fire alarms for {Name}'s House...");
            }
            else if (BuildingType.ToLower() == "barn")
            {
                // If building type is barn
                Console.WriteLine($"- Wiring milking equipment for {Name}'s Barn...");
            }
            else if (BuildingType.ToLower() == "garage")
            {
                // If building type is garage
                Console.WriteLine($"- Installing automatic doors for {Name}'s Garage...");
            }
            else
            {
                // If invalid building type is entered
                Console.WriteLine("Invalid building type entered.");
            }
        }
    }

    // Main class to execute the program
    public class Kajal_A2_Task2
    {
        public static void Main(string[] args)
        {
            // Create a list to store customers
            List<CustomerBase> customers = new List<CustomerBase>();
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
                // Validate building type input (house, barn, or garage)
                string buildingType;
                while (true)
                {
                    Console.Write("Enter the building type (House/Barn/Garage): ");
                    buildingType = Console.ReadLine().Trim().ToLower();  // Convert input to lowercase
                    if (buildingType == "house" || buildingType == "barn" || buildingType == "garage")
                    {
                        break;  // If valid input, break out of loop
                    }
                    else
                    {
                        // If invalid input, prompt the user again
                        Console.WriteLine("Invalid input. Please enter 'House', 'Barn', or 'Garage'.");
                    }
                }

                // Validate building size input (between 1000 and 50000 sq. ft.)
                int buildingSize;
                while (true)
                {
                    Console.Write("Enter the size of the building (1000 to 50000 sq. ft.): ");
                    if (int.TryParse(Console.ReadLine(), out buildingSize) && buildingSize >= 1000 && buildingSize <= 50000)
                    {
                        break;  // If valid size, break out of loop
                    }
                    else
                    {
                        // If invalid size, prompt the user again
                        Console.WriteLine("Invalid input. Please enter a size between 1000 and 50000 sq. ft.");
                    }
                }

                // Validate number of light bulbs (1 to 20)
                int lightBulbs;
                while (true)
                {
                    Console.Write("Enter the number of light bulbs (1 to 20): ");
                    if (int.TryParse(Console.ReadLine(), out lightBulbs) && lightBulbs >= 1 && lightBulbs <= 20)
                    {
                        break;  // If valid number, break out of loop
                    }
                    else
                    {
                        // If invalid number, prompt the user again
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 20 for light bulbs.");
                    }
                }

                // Validate number of outlets (1 to 50)
                int outlets;
                while (true)
                {
                    Console.Write("Enter the number of outlets (1 to 50): ");
                    if (int.TryParse(Console.ReadLine(), out outlets) && outlets >= 1 && outlets <= 50)
                    {
                        break;  // If valid number, break out of loop
                    }
                    else
                    {
                        // If invalid number, prompt the user again
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 50 for outlets.");
                    }
                }

                // Create a new Customer object and set its properties
                Customer customer = new Customer()
                {
                    Name = name,
                    BuildingType = buildingType,
                    BuildingSize = buildingSize,
                    NumberOfLightBulbs = lightBulbs,
                    NumberOfOutlets = outlets
                };

                // Process payment and only add valid customers to the list
                if (customer.Payment())  // Only add if payment is accepted
                {
                    customers.Add(customer);

                    // Perform tasks based on the building type
                    Console.WriteLine($"\nExecuting Tasks for {customer.Name}:");
                    customer.PerformSpecificTasks();
                }

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

            // Sort customers by building size (using IComparable implementation)
            Console.WriteLine("\nSorting customers by building size:");
            customers.Sort();  // Sort the list of customers

            // Display the customer summary after sorting
            Console.WriteLine("\nCustomer Appointment Summary:");
            foreach (var customer in customers)
            {
                customer.DisplayInfo();  // Display each customer's details
            }

        }
    }
}
