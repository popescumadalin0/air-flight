using System;
using AirFlightsDashboard.Models;
using AirFlightsDashboard.States;
using Blazorise;
using Microsoft.AspNetCore.Components;

namespace AirFlightsDashboard.Pages.Booking
{
    public partial class BookingHistory:ComponentBase, IDisposable
    {
        [Inject]
        private SnackbarState SnackbarState { get; set; }

        [Inject]
        private LoadingState LoadingState { get; set; }

        private TicketModel TicketInfo = new();


        public void Dispose()
        {
            SnackbarState.OnStateChange -= StateHasChanged;
            LoadingState.OnStateChange -= StateHasChanged;
        }

        protected override void OnInitialized()
        {
            SnackbarState.OnStateChange += StateHasChanged;
            LoadingState.OnStateChange += StateHasChanged;
        }
    }
}
