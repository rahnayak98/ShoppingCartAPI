using System.Text.Json;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Services;

public class ShoppingCartService
{
    private readonly List<Items> cart;
    private const string CartSessionKey = "ShoppingCart";
    
    // Method to add an item to the shopping cart.
    public void AddItem(ISession session, Items item)
    {
        var cart = Getcart(session);
        cart.Add(item);
        Savecart(session, cart);
    }
    
    // Method to view the current shopping cart.
    public List<Items> ViewCart(ISession session)
    {
        return Getcart(session);
    }
    
    // Private method to get the cart from the session.
    private List<Items> Getcart(ISession session)
    {
        var cartjson = session.GetString(CartSessionKey);
        return cartjson == null ? new List<Items>() : JsonSerializer.Deserialize<List<Items>>(cartjson);
    }
    
    // Private method to save the cart to the session.
    private void Savecart(ISession session, List<Items> cart)
    {
        var cartjson = JsonSerializer.Serialize(cart);
        session.SetString(CartSessionKey,cartjson);
    }


}