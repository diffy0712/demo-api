using System.ComponentModel.DataAnnotations;

namespace Api.Entities;

public class Device
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Content { get; set; }
    
    [Required]
    public List<Tag> Tags { get; set; } = new List<Tag>();
}