using Microsoft.EntityFrameworkCore;

namespace DataBaseLayout.Models;

[PrimaryKey(nameof(Id))]
public class AirFlight
{
    public Guid Id { get; set; }
    public int Price { get; set; }
    public string Currency { get; set; }
    public ICollection<Layover> Layovers { get; set; }
}