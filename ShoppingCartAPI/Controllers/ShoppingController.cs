using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Services;

namespace ShoppingCartAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShoppingController: ControllerBase
{
    private readonly ShoppingCartService shoppingCartService;
    private readonly ILogger<ShoppingController> logger;


    public ShoppingController(ShoppingCartService shoppingCartService)
    {
        this.shoppingCartService = shoppingCartService;
    }
    // HTTP POST endpoint for adding an item to the shopping cart
    [HttpPost("add")]
    public ActionResult AddItem([FromBody] Items item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            shoppingCartService.AddItem(HttpContext.Session, item);
            return CreatedAtAction(nameof(ViewCart), null, item);
        }
        catch (Exception e)
        {
            logger.LogError(e,"Error adding items to cart");
            return StatusCode(500, "Internal server error");
        }
      
    }
    // HTTP GET endpoint for viewing the items in the shopping cart
    [HttpGet("items")]
    public ActionResult<List<Items>> ViewCart()
    {
        try
        {
            var items = shoppingCartService.ViewCart(HttpContext.Session);
            return Ok(items);
        }
        catch (Exception e)
        {
            logger.LogError(e,"Error viewing items from cart");
            return StatusCode(500, "Internal server error");
        }
        
        
    }
    
}