using System.ComponentModel.DataAnnotations;

namespace ShoppingCartAPI.Models;

public class Items
{
    [Required]
    public string Name { get; set; }
    
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
    public double Price { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int Quantity { get; set; }
}