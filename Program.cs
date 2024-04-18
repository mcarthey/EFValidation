using System.ComponentModel.DataAnnotations;

namespace EFValidation;

public class Program
{
    public static void Main()
    {
        var product = new Product();

        Console.Write("Enter product name: ");
        product.Name = Console.ReadLine();

        Console.Write("Enter product description: ");
        product.Description = Console.ReadLine();

        Console.Write("Enter product price: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            Console.WriteLine("Invalid price format. Please enter a valid number.");
            return;
        }

        product.Price = price;

        // Display validation errors if any
        product.DisplayValidationErrors();

        // If there are validation errors, prompt the user to resubmit
        while (!Validator.TryValidateObject(product, new ValidationContext(product), null, true))
        {
            Console.WriteLine("Please correct the errors above and try again.");

            Console.Write("Enter product name: ");
            product.Name = Console.ReadLine();

            Console.Write("Enter product description: ");
            product.Description = Console.ReadLine();

            Console.Write("Enter product price: ");
            if (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid price format. Please enter a valid number.");
                return;
            }

            product.Price = price;

            product.DisplayValidationErrors();
        }

        Console.WriteLine("All data is valid. Continuing with the application...");
    }
}