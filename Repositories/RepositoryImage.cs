using backendShopApp.Models;
using backendShopApp.DataContext;

namespace backendShopApp.Repositories;

public class RepositoryImage : IRepositoryImage
{
    private readonly BackendShopAppDbContext _dbContext;

    public RepositoryImage(BackendShopAppDbContext dbContext)
    {
        _dbContext= dbContext;
    }

    public int Create(Image obj)
    {
        try
        {
            _dbContext.Images.Add(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Delete(Image obj)
    {
        try
        {
            _dbContext.Images.Remove(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public List<Image> GetAll()
    {
        try
        {
            var images = _dbContext.Images.ToList();

            return images;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public int Update(Image obj)
    {
        try
        {
            _dbContext.Images.Update(obj);
            return _dbContext.SaveChanges();

        }
        catch (Exception)
        {
            throw;
        }
    }

    public Image GetById(int id)
    {
        try
        {
            var image = (from i in _dbContext.Images.ToList()
                        where i.Id == id select i).FirstOrDefault();
            
            return image;

        }
        catch (Exception)
        {
            throw;
        }
    }

}