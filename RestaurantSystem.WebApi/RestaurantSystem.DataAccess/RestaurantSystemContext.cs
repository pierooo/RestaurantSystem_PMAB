using Microsoft.EntityFrameworkCore;
using RestaurantSystem.DataAccess.Models;

namespace RestaurantSystem.DataAccess;

public class RestaurantSystemContext : DbContext
{
    public RestaurantSystemContext(DbContextOptions<RestaurantSystemContext> opt) : base(opt)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderDetails> OrdersDetails { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    public DbSet<RestaurantTable> RestaurantTables { get; set; }

    public DbSet<Reservation> Reservations { get; set; }
}
