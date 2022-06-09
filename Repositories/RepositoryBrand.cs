using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryBrand : IRepositoryBrand
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryBrand(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public int Create(Brand obj)
    {
        try
        {
            _dbContext.Brands.Add(obj);
           return  _dbContext.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Delete(Brand obj)
    {
        try
        {
            _dbContext.Brands.Remove(obj);
           return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Brand> GetAll()
    {
        try
        {
            var brands = _dbContext.Brands.ToList();

            return brands;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Update(Brand obj)
    {
        try
        {
            _dbContext.Brands.Update(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Brand GetById(int id)
    {
        try
        {
            var brand = (from i in _dbContext.Brands.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return brand;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Brand GetByName(string name)
    {
        try
        {
            var brand = (from b in _dbContext.Brands.ToList()
                        where b.Name == name select b).FirstOrDefault();

            return brand;   
        }
        catch (Exception)
        {   
            throw;
        }
    }

}