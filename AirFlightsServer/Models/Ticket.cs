using System;

namespace Models;

public class Ticket
{
    public Guid Id { get; set; }
    public int Price { get; set; }
    public string Currency { get; set; }
}