
using Microsoft.AspNetCore.SignalR;

namespace API.hub
{
    public class SignalRHub : Hub
    {
        // Gửi thông báo tới client
        // public async Task NewMessage(long username, string message) => await Clients.All.SendAsync("messageReceived", username, message);

        // Gửi Số lượng tin nhắn chưa đọc tới Client

        // Gửi yêu cầu thay đởi data Chart tới clients
        
    }
}