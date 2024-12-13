using EventCalendar.Data;
using Microsoft.EntityFrameworkCore;

public class EventDbContext : DbContext
{
    public EventDbContext(DbContextOptions<EventDbContext> options) : base(options) { }
    public DbSet<Event> Events { get; set; }
}
