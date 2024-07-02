using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Models;
using ShoppingCartAPI.Services;

namespace ShoppingCartAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ShoppingController: ControllerBase
{
    private readonly ShoppingCartService shoppingCartService;

    public ShoppingController(ShoppingCartService shoppingCartService)
    {
        this.shoppingCartService = shoppingCartService;
    }

    [HttpPost("add")]
    public ActionResult AddItem([FromBody] Items item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        shoppingCartService.AddItem(HttpContext.Session, item);

        return CreatedAtAction(nameof(ViewCart), null, item);
    }

    [HttpGet("items")]
    public ActionResult<List<Items>> ViewCart()
    {
        var items = shoppingCartService.ViewCart(HttpContext.Session);
        return Ok(items);
        
    }
    
}