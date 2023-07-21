using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace WebApplicationRedisCacheAzure.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CacheController : ControllerBase
  {
    private static RedisConnection _redisConnection;

    // Initialize
    public const string stringConnection = "<NameYourRedisCache>.redis.cache.windows.net,abortConnect=false,ssl=true,allowAdmin=true,password=wDAQoCHTvHdhQf2AhrmmICJuCek1JRM7TAzCaEDIOfU=";


    public CacheController()
    {

    }
    [HttpPost]
    [Route("cache-status")]
    public IActionResult CacheStatus()
    {
      try
      {
        //conexion online
        _redisConnection = RedisConnection.InitializeAsync(connectionString: stringConnection).Result;

        RedisResult pingResult = _redisConnection.BasicRetryAsync(async (db) => await db.ExecuteAsync("PING")).Result;
        return this.Ok(pingResult.ToString());
      }
      catch (Exception exc)
      {
        return this.BadRequest(exc.Message);
      }
    }
    [HttpPost]
    [Route("cache-set")]
    public IActionResult CacheSet(string key, string value)
    {
      try
      {
        //conexion online
        _redisConnection = RedisConnection.InitializeAsync(connectionString: stringConnection).Result;
        bool stringSetResult = _redisConnection.BasicRetryAsync(async (db) => await db.StringSetAsync(key, value)).Result;

        return this.Ok();
      }
      catch (Exception exc)
      {
        return this.BadRequest(exc.Message);
      }
    }
    [HttpGet]
    [Route("cache-get")]
    public IActionResult CacheGet(string key)
    {
      try
      {
        //conexion online
        _redisConnection = RedisConnection.InitializeAsync(connectionString: stringConnection).Result;
        RedisValue getMessageResult;
        getMessageResult = _redisConnection.BasicRetryAsync(async (db) => await db.StringGetAsync(key)).Result;
        Console.WriteLine($"key: {key}: Cache response value: {getMessageResult}");

        return this.Ok(getMessageResult.ToString());
      }
      catch (Exception exc)
      {
        return this.BadRequest(exc.Message);
      }
    }
  }
}
