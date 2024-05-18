using System;
using AirFlightsDashboard.States;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Ticket
{
    public partial class AddFlight: ComponentBase, IDisposable
    {

        [Inject]
        private SnackbarState SnackbarState { get; set; }

        [Inject]
        private LoadingState LoadingState { get; set; }



        private Form form;

        public void Dispose()
        {
            SnackbarState.OnStateChange -= StateHasChanged;
            LoadingState.OnStateChange += StateHasChanged;
        }

        protected override void OnInitialized()
        {
            SnackbarState.OnStateChange += StateHasChanged;
            LoadingState.OnStateChange += StateHasChanged;
        }

    }
}
