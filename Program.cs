namespace EFValidation;

public class Program
{
    public static void Main()
    {
        var product = new Product();

        List<string> nameErrors;
        while (true)
        {
            Console.Write("Enter product name: ");
            product.Name = Console.ReadLine();
            
            if (product.ValidateName(out nameErrors))
            {
                break;
            }
            DisplayErrors(nameErrors);
        }

        List<string> descriptionErrors;
        while (true)
        {
            Console.Write("Enter product description: ");
            product.Description = Console.ReadLine();
            
            if (product.ValidateDescription(out descriptionErrors))
            {
                break;
            }
            DisplayErrors(descriptionErrors);
        }

        List<string> priceErrors;
        while (true)
        {
            Console.Write("Enter product price: ");
            if (!decimal.TryParse(Console.ReadLine(), out var price))
            {
                Console.WriteLine("Invalid price format. Please enter a valid number.");
                continue;
            }

            product.Price = price;

            if (product.ValidatePrice(out priceErrors))
            {
                break;
            }
            DisplayErrors(priceErrors);
        }

        using (var context = new AppDbContext())
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        Console.WriteLine("Product added to the database. Press any key to exit.");
        Console.ReadKey();
    }

    private static void DisplayErrors(List<string> errors)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Invalid input. Please try again.");
        foreach (var error in errors)
        {
            Console.WriteLine(error);
        }

        Console.ResetColor();
    }
}
