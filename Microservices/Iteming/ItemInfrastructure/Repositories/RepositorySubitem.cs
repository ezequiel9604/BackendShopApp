
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Iteming.ItemDomains.Entities;
using backendShopApp.Microservices.Iteming.ItemInfrastructure.Data;

namespace backendShopApp.Microservices.Iteming.ItemInfrastructure.Repositories;

public class RepositorySubitem : IRepositorySubitem
{
    private readonly ItemContext _dbContext;

    public RepositorySubitem(ItemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SubItem> GetById(int id)
    {
        try
        {
            return await _dbContext.SubItems.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<SubItem>> GetByItemId(string id)
    {
        try
        {
            var subitems = await _dbContext.SubItems.Where(x => x.ItemId == id).ToListAsync();

            return subitems;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<SubItem>> GetAll()
    {
        try
        {
            return await _dbContext.SubItems.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(SubItem obj)
    {
        try
        {
            _dbContext.SubItems.Remove(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public void Update(SubItem obj)
    {
        try
        {
            _dbContext.SubItems.Update(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async void Create(SubItem obj)
    {
        try
        {
            await _dbContext.SubItems.AddAsync(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<int> SaveAllChanges()
    {
        try
        {
            return await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

    }
}
