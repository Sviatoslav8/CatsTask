using TaskCats.Models;
using TaskCats.Service;

namespace TaskCats.HostedServices;

public class HostedCat : IHostedService
{
    private Timer timer;
    private readonly CatService _service;
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        timer = new Timer(GetRandomCat,null,TimeSpan.Zero,TimeSpan.FromSeconds(5));
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private void GetRandomCat(object? state)
    {
        var cats = _service.GetCats(null,null,null);
        Console.WriteLine(cats[new Random().Next(cats.Count)]);
    }
}