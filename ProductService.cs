
using Product.Models;
namespace Product.Services;

//Servicio para simular el crud en memoria 
public class ProductService
{
    
   private readonly ILogger _logger;
   private readonly ProductDbContext  _context;
    //Constructor
    static ProductService(ProductDbContext context , ILogger logger)
    {
        //Initialize product service with dataAccess and logger interface
        _context = context
       _logger = logger
    }

    //get all products from ENtityFramework
    public  async Task<List<Product>> GetAllProducts()
    {
         _logger.LogDebug("in GetProducts service");
        var products = await _context.Products.ToListAsync();
        return products;
    }


    //obtain product by id
    public async Task<Product> GetById(int id)
    {
         _logger.LogDebug("in GetProductById service");
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        return product;
    } 

  // get Product Attributes by id
   public async Task<List<ProductAttribute>> GetById(int productID)
    {
        _logger.LogDebug("in GetProductAttributes service");
        var productAttributes = _context.Products.ProductAttribute.(p => p.ProductId == productID);
        return productAttributes;
    } 
  

}