using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;

namespace Lab17.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CacheDemoController : ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    private readonly IDistributedCache _distributedCache;

    public CacheDemoController(IMemoryCache memoryCache, IDistributedCache distributedCache)
    {
        _memoryCache = memoryCache;
        _distributedCache = distributedCache;
    }

    // Пример 1 — внутренний кэш (MemoryCache)
    [HttpGet("memory")]
    public IActionResult GetMemoryCache()
    {
        const string cacheKey = "current_time";
        if (!_memoryCache.TryGetValue(cacheKey, out string? currentTime))
        {
            currentTime = DateTime.Now.ToString("HH:mm:ss");
            _memoryCache.Set(cacheKey, currentTime, TimeSpan.FromSeconds(15)); // истекает через 15 секунд
        }

        return Ok(new
        {
            Source = "MemoryCache",
            Value = currentTime,
            Expiration = "15 секунд"
        });
    }

    // Пример 2 — распределённый кэш (DistributedCache)
    [HttpGet("distributed")]
    public async Task<IActionResult> GetDistributedCache()
    {
        const string cacheKey = "distributed_time";
        var cachedData = await _distributedCache.GetAsync(cacheKey);
        string? timeString;

        if (cachedData == null)
        {
            timeString = DateTime.Now.ToString("HH:mm:ss");
            var bytes = Encoding.UTF8.GetBytes(timeString);
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(30)); // обновляется при каждом обращении
            await _distributedCache.SetAsync(cacheKey, bytes, options);
        }
        else
        {
            timeString = Encoding.UTF8.GetString(cachedData);
        }

        return Ok(new
        {
            Source = "DistributedCache",
            Value = timeString,
            Expiration = "30 секунд (скользящее)"
        });
    }

    // Пример 3 — очистка кеша
    [HttpDelete("clear")]
    public async Task<IActionResult> ClearCache()
    {
        _memoryCache.Remove("current_time");
        await _distributedCache.RemoveAsync("distributed_time");

        return Ok(new
        {
            Message = "Кэш успешно очищен"
        });
    }
}
