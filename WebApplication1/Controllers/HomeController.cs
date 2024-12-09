using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConnectionMultiplexer _redisConnection;
        public HomeController(IConnectionMultiplexer redisConnection)
        {
            _redisConnection = redisConnection;
        }
        public IActionResult Index()
        {
            var db = _redisConnection.GetDatabase();

            var redisList = db.ListRange("images");
            List<string> imageUrls = redisList.Select(r => r.ToString()).ToList();

            return View(imageUrls);
        }
    }
}
