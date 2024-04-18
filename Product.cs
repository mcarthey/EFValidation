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

    public bool ValidateName(out List<string> errors)
    {
        var context = new ValidationContext(this) { MemberName = nameof(Name) };
        errors = new List<string>();
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateProperty(Name, context, results);
        if (!isValid)
        {
            errors.AddRange(results.Select(r => r.ErrorMessage));
        }
        return isValid;
    }

    public bool ValidateDescription(out List<string> errors)
    {
        var context = new ValidationContext(this) { MemberName = nameof(Description) };
        errors = new List<string>();
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateProperty(Description, context, results);
        if (!isValid)
        {
            errors.AddRange(results.Select(r => r.ErrorMessage));
        }
        return isValid;
    }

    public bool ValidatePrice(out List<string> errors)
    {
        var context = new ValidationContext(this) { MemberName = nameof(Price) };
        errors = new List<string>();
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateProperty(Price, context, results);
        if (!isValid)
        {
            errors.AddRange(results.Select(r => r.ErrorMessage));
        }
        return isValid;
    }
}

