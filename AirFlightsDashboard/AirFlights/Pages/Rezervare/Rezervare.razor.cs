using Blazorise;
using Microsoft.AspNetCore.Components;

namespace AirFlightsClient.Pages.Rezervare
{
    public partial class Rezervare : BaseComponent
    {
        [Inject]
        private NavigationManager Nav1 { get; set; }

        private int selectedValue { get; set; }
    }
}
