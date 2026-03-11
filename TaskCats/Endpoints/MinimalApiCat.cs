using TaskCats.Models;
using TaskCats.Service;

namespace TaskCats.Endpoints;

public static class MinimalApiCat
{
    private static readonly CatService _service;
    public static IEndpointRouteBuilder MapCat(this IEndpointRouteBuilder app)
    {
        var endpoint = app.MapGroup("api/v1/cats");
        endpoint.MapGet("{id}", (int id) => _service.GetById(id));
        endpoint.MapPost("/", (Cat cat) => _service.AddCat(cat));
        endpoint.MapPut("{id}", (int id,Cat cat) => _service.Update(id,cat));
        endpoint.MapDelete("{id}", (int id) => _service.DeleteCat(id));
        endpoint.MapGet("/",(int? limit, int? offset, string? name)=>_service.GetCats(limit, offset, name));
        return app;
    }
}