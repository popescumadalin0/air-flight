﻿using System;
using System.Threading.Tasks;
using AirFlightsClient.Models;
using AirFlightsClient.States;
using Microsoft.AspNetCore.Components;

namespace AirFlightsClient.Pages.Account;

public partial class Login : ComponentBase, IDisposable
{
    [Inject]
    private SnackbarState SnackbarState { get; set; }

    [Inject]
    private LoadingState LoadingState { get; set; }

    private LoginModel _loginModel = new LoginModel();

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

    private Task SignInAsync()
    {
        //todo: call database
        return Task.CompletedTask;
    }
}