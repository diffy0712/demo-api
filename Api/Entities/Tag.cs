using System.ComponentModel.DataAnnotations;

namespace Api.Entities;

public class Tag
{
    [Key]
    public Guid Id { get; init; }
    
    [Required]
    public string Content { get; init; }

    public List<Product> Notes { get; set; } = new List<Product>();
}