using System.Text.Json;
using ShoppingCartAPI.Models;

namespace ShoppingCartAPI.Services;

public class ShoppingCartService
{
    private readonly List<Items> cart;
    private const string CartSessionKey = "ShoppingCart";
    
    public void AddItem(ISession session, Items item)
    {
        var cart = Getcart(session);
        cart.Add(item);
        Savecart(session, cart);
    }

    public List<Items> ViewCart(ISession session)
    {
        return Getcart(session);
        // return new List<Items>(cart);
    }

    private List<Items> Getcart(ISession session)
    {
        var cartjson = session.GetString(CartSessionKey);
        return cartjson == null ? new List<Items>() : JsonSerializer.Deserialize<List<Items>>(cartjson);
    }

    private void Savecart(ISession session, List<Items> cart)
    {
        var cartjson = JsonSerializer.Serialize(cart);
        session.SetString(CartSessionKey,cartjson);
    }


}