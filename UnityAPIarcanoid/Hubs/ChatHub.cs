using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using UnityAPIarcanoid.DB;
using UnityAPIarcanoid.Model;

namespace UnityAPIarcanoid.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ContextDB _context;

        public ChatHub(ContextDB context)
        {
            _context = context;
        }
        public async Task SendMessage(string message, int senderId)
        {
            var user = await _context.User.FindAsync(senderId);

            await Clients.Others.SendAsync("ReceiveMessage",
                message,
                senderId,
                user.Username);
            _context.Messages.Add(new Messages
            {
                SenderId = senderId,
                Message = message,
                Username = user.Username
            });
            await _context.SaveChangesAsync();
        }
    }
}
