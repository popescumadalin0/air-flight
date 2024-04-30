using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DataBaseLayout.Models;
[PrimaryKey(nameof(Id))]
public class PlaneSeat
{
    public Guid Id { get; set; }
    public bool IsOcuppied { get; set; }
    [Required]
    public Layover Layover { get; set; }

    public virtual ICollection<Booking> Reservation { get; set; }
}