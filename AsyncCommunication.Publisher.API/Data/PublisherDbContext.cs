using AsyncCommunication.Publisher.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AsyncCommunication.Publisher.API.Data;
public class PublisherDbContext : DbContext
{
    public PublisherDbContext(DbContextOptions<PublisherDbContext> options)
        : base(options)
    {

    }

    public DbSet<Message> Messages { get; set; }
}
