using ToDo.Core.Exceptions;
using ToDo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ToDo.Infra.Context;
using ToDo.Infra.Interfaces; //pesquisar so mais sobre EntityFrameworkCore

// using System.Linq;
// using System.Threading.Tasks;


namespace ToDo.Infra.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T:Base
{
    private readonly ToDoContext _context;

    public BaseRepository(ToDoContext context)
    {
        _context = context;
    }
    
    public virtual async Task<T> Create(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task<T> Update(T obj)
    {
        // _context.Update(obj);
        _context.Entry(obj).State = EntityState.Modified; // pesquisar mais sobre
        await _context.SaveChangesAsync();
        return obj;
    }

    public virtual async Task Remove(long id)
    {
        var obj = await Get(id);
        if (obj != null)
        {
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }
        // else
        // {
        //     throw new DomainException("Usuario não existe");
        // }
    }


    public virtual async Task<T> Get(long id)
    {
        var obj = await _context.Set<T>() // pesquisar mais sobre
            .AsNoTracking() // serve para nao traquear os objetos (obs: o que é traquear?)
            .Where(x => x.Id == id)
            .ToListAsync();
        
        return obj.FirstOrDefault(); 
        
    }
    
    public virtual async Task<List<T>> Get()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }
}