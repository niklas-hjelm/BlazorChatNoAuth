using BlazorChatNoAuth.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;

namespace BlazorChatNoAuth.Client.Pages;

public partial class Chat : ComponentBase
{
    public List<ChatMessage>? Messages = new();
    public HubConnection hubConnection;
    public ChatMessage newChatMessage = new();

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(_navigationManager.BaseUri + "hubs/ChatHub")
            .Build();

        hubConnection.On<ChatMessage>("SendMessage", (message) =>
        {
            Messages?.Add(message);
            StateHasChanged();
        });

        await hubConnection.StartAsync();

        Messages = await _httpClient.GetFromJsonAsync<List<ChatMessage>>(_httpClient.BaseAddress + "messages");


    }

    private async Task SendMessage()
    {
        await hubConnection.SendAsync("SendMessage", newChatMessage);
        newChatMessage.Message = string.Empty;
    }

}