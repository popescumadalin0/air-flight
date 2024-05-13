using System;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Booking;

public partial class Booking : BaseComponent
{
    [Inject]
    private NavigationManager Nav1 { get; set; }

    private int selectedValue { get; set; }
    bool accordionItem1Visible = true;
    bool accordionItem2Visible = false;
    bool accordionItem3Visible = false;
   

DatePicker<DateTime?> datePickerDestination;

    DateTime? valueDestination;

    DatePicker<DateTime?> datePickerReturn;

    DateTime? valueReturn;

}
