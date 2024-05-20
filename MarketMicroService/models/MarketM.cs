using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketMicroService;

public class MarketM(string name, string description, string city, string address)
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; }
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public string City { get; set; } = city;
    public string Address { get; set; } = address;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
