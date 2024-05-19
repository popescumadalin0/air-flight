using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AirFlightsDashboard.States;
using Blazorise;
using Microsoft.AspNetCore.Components;
using Models;

namespace AirFlightsDashboard.Pages.Account;

public partial class Users : ComponentBase, IDisposable
{
    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

    private List<User> _users = new();

    private User _selectedUser = new();
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