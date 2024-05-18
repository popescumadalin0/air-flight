using AirFlightsDashboard.Models;
using AirFlightsDashboard.States;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Models.Request;
using Models;
using SDK.Clients;
using System;
using System.Threading.Tasks;
using AirFlightsDashboard.Pages.Ticket;

namespace AirFlightsDashboard.Pages.Flights
{
    public partial class AddFlight: ComponentBase, IDisposable
    {

        [Inject]
        private SnackbarState SnackbarState { get; set; }

        [Inject]
        private LoadingState LoadingState { get; set; }

        private FlightModel _flightModel = new FlightModel();


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

        private async Task AddFlightAsync()
        {
            await LoadingState.ShowAsync();
            var result = await AirFlightsApiClient.CreateTicketAsync(
                new global::Models.Ticket()
                {
                    
                }
               );

            await LoadingState.HideAsync();

            await SnackbarState.PushAsync(
                result.Success ? "User created!" : result.ResponseMessage,
                !result.Success);

            if (result.Success)
            {
                NavigationManager.NavigateTo("/login");
            }
        }
    }
}
