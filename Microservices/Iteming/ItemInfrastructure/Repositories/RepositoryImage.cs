
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Iteming.ItemDomains.Entities;
using backendShopApp.Microservices.Iteming.ItemInfrastructure.Data;

namespace backendShopApp.Microservices.Iteming.ItemInfrastructure.Repositories;

public class RepositoryImage : IRepositoryImage
{
    private readonly ItemContext _dbContext;

    public RepositoryImage(ItemContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Image> GetById(int id)
    {
        try
        {
            return await _dbContext.Images.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<Image>> GetByItemId(string id)
    {
        try
        {
            var images = await _dbContext.Images.Where(x => x.ItemId == id).ToListAsync();

            return images;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Image>> GetAll()
    {
        try
        {
            return await _dbContext.Images.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(Image obj)
    {
        try
        {
            _dbContext.Images.Remove(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public void Update(Image obj)
    {
        try
        {
            _dbContext.Images.Update(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async void Create(Image obj)
    {
        try
        {
            await _dbContext.Images.AddAsync(obj);
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
