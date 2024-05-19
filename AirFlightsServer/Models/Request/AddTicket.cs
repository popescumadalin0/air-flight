using System.Collections.Generic;

namespace Models.Request;

public class AddTicket
{
    public int Price { get; set; }

    public string Currency { get; set; }

    public string Image { get; set; }

    public List<AddLayover> Layovers { get; set; }
}