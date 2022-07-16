using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using signalr_poc.Domain;

namespace signalr_poc.Controllers;

public class SimpleHub : Hub
{
    private readonly PocDbContext _dbContext;
    public SimpleHub(PocDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async IAsyncEnumerable<object> Streaming()
    {
        var data = _dbContext.Dummies
            .AsNoTracking();
        
        foreach (var i in data)
        {
            yield return JsonConvert.SerializeObject(i);
        }
    }
}