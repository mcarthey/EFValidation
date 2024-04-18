using System.ComponentModel.DataAnnotations;

namespace EFValidation;

public class Product
{
    [StringLength(100, ErrorMessage = "Description must be 100 characters or less")]
    public string Description { get; set; }

    public int Id { get; set; }

    [Required(ErrorMessage = "Product name is required")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Product price is required")]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
    public decimal Price { get; set; }

    public void DisplayValidationErrors()
    {
        var context = new ValidationContext(this, serviceProvider: null, items: null);
        var results = new System.Collections.Generic.List<ValidationResult>();

        if (!Validator.TryValidateObject(this, context, results, validateAllProperties: true))
        {
            foreach (var validationResult in results)
            {
                Console.WriteLine(validationResult.ErrorMessage);
            }
        }
    }
}
