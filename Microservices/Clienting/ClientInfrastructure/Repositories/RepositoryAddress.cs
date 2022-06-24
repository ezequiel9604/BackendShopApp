﻿
using Microsoft.EntityFrameworkCore;
using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Clienting.ClientDomains.Entities;
using backendShopApp.Microservices.Clienting.ClientInfrastructure.Data;

namespace backendShopApp.Microservices.Clienting.ClientInfrastructure.Repositories;

public class RepositoryAddress : IRepositoryAddress
{
    private readonly ClientContext _dbContext;

    public RepositoryAddress(ClientContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Address> GetById(int id)
    {
        try
        {
            return await _dbContext.Addresses.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async Task<List<Address>> GetByClientId(string id)
    {
        try
        {
            var addresses = await _dbContext.Addresses.Where(x => x.ClientId == id).ToListAsync();

            return addresses;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<List<Address>> GetAll()
    {
        try
        {
            return await _dbContext.Addresses.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }


    public void Delete(Address obj)
    {
        try
        {
            _dbContext.Addresses.Remove(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public void Update(Address obj)
    {
        try
        {
            _dbContext.Addresses.Update(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }


    public async void Create(Address obj)
    {
        try
        {
            await _dbContext.Addresses.AddAsync(obj);
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
