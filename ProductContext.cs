public class ProductDbContext : DbContext, IProductContext
{
    public DbSet<Products> Products { get; set; }
}