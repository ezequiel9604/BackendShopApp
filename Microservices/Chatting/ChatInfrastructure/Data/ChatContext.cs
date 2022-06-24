
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Chatting.ChatDomain.Entities;

namespace backendShopApp.Microservices.Chatting.ChatInfrastructure.Data;

public class ChatContext : DbContext
{
    public ChatContext(DbContextOptions<ChatContext> options)
        : base(options)
    {

    }

    public DbSet<Chat>? Chats { get; set; }

}
