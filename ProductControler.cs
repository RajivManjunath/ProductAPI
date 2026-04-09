//Api
using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Product.Services;

namespace Product.Controllers;

//Api controller implements product related endpoints
[ApiController]
[Authorize]
//route to get product by id
[Route("api/[controller]")]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;
    private readonly ILogger _logger;

    //Constructor - resolves the dependency injection for IProductService and ILogger
    public ProductController(IProductService productService, ILogger logger)
    {
        _productService= productService;
        _logger = logger;

    }

    //endpoint to get all products     
    [HttpGet("GetProducts")]
    public async Task<ActionResult> GetProducts()
    {
        // log debug, also levels can be configures.
        //also we can log correlation id if microservice structure
        //also we can log timestamp
        _logger.LogDebug("in GetProducts endpoint");
        var products = await _productService.GetAllProducts();
        return OK(products);
    }

    //endpoint to get  single product by id     
    [HttpGet("{id}")]
    public async Task<ActionResult> GetProduct(int id)
    {
        _logger.LogDebug("in GetProductById endpoint");
        var product = await _productService.GetProduct(id);
        
        if (product is null)
        {
            return NotFound();
        }
        else
        {
            return OK(product);
        }
    }

//endpoint to get  single product attributes if any by id     
    [HttpGet("{productID}")]
    public async Task<ActionResult> GetProductAttributes(int productID)
    {
        _logger.LogDebug("in GetProductAttributes endpoint");
        List<ProductAttributes> productAttributes = await _productService.GetProductAttributes(id);
        
        if (productAttributes.Any())
        {
             return OK(productAttributes);            
        }
        else
        {
           return NotFound();
        }
    }

}