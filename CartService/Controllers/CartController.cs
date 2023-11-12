using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Text.Json;

[Route("api/cart")]
public class CartController : Controller
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public CartController(IConnectionMultiplexer connectionMultiplexer)
    {
        _redis = connectionMultiplexer;
        _database = _redis.GetDatabase();
    }

    [HttpPost]
    public IActionResult AddToCart([FromQuery] string userId, string productId, int quantity)
    {
        try
        {
            // Use userId as the key and a Redis Hash to store cart items
            _database.HashSet(userId, new HashEntry[] { new HashEntry(productId, quantity) });

            return Ok("Product added to cart.");
        }
        catch (Exception ex)
        {
            return BadRequest("Error: " + ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetCart([FromQuery] string userId)
    {
        try
        {
            // Retrieve the cart from Redis as a Hash
            var cartItems = _database.HashGetAll(userId);

            // Serialize the cartItems to JSON
            var cartJson = JsonSerializer.Serialize(cartItems);

            return Ok(cartJson);
        }
        catch (Exception ex)
        {
            return BadRequest("Error: " + ex.Message);
        }
    }

    [HttpPost]
    public IActionResult RemoveFromCart(string userId, string productId)
    {
        try
        {
            // Remove a product from the cart in Redis
            _database.HashDelete(userId, productId);

            return Ok("Product removed from cart.");
        }
        catch (Exception ex)
        {
            return BadRequest("Error: " + ex.Message);
        }
    }
}
