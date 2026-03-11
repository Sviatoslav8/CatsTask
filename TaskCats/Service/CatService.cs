using TaskCats.Models;
using TaskCats.Storage;

namespace TaskCats.Service;

public class CatService
{
    private readonly DataContext _context;
    public CatService(DataContext context)
    {
        _context = context;
    }
    public Cat GetById(int id)
    {
        return _context.Cats.Where(x => x.Id == id).FirstOrDefault();
    }

    public void AddCat(Cat newCat)
    {
        _context.Cats.Add(newCat);
        _context.SaveChanges();
    }

    public List<Cat> GetCats(int? limit, int? offset, string? name)
    {
        var query = _context.Cats.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(x => x.Breed.Contains(name));
        }

        if (offset.HasValue)
        {
            query = query.Skip(offset.Value);
        }

        if (limit.HasValue)
        {
            query = query.Take(limit.Value);
        }

        return query.ToList();
    }

    public void Update(int id, Cat newCat)
    {
        var findCat = _context.Cats.Where(x => x.Id == id).FirstOrDefault();
    
        if (findCat == null)
            throw new Exception("Error");

        findCat.Breed = newCat.Breed;
        findCat.Color = newCat.Color;
        findCat.Price = newCat.Price;

        _context.SaveChanges();
        
    }

    public void DeleteCat(int id)
    {
        var findCat = _context.Cats.Where(x => x.Id == id).FirstOrDefault();
        if (findCat == null)
            throw new Exception("Error");
        _context.Cats.Remove(findCat);
    }
    
}