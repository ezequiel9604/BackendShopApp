﻿
using Microsoft.EntityFrameworkCore;
using backendShopApp.Data;
using backendShopApp.Microservices.Interfaces.Repositories;
using backendShopApp.Microservices.Clienting.ClientDomains.Entities;

namespace backendShopApp.Microservices.Clienting.ClientInfrastructure.Repositories;

public class RepositoryClient : IRepositoryClient
{
    private readonly DatabaseContext _dbContext;

    public RepositoryClient(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Client>> GetAll()
    {
        try
        {
            return await _dbContext.Clients.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<Client> GetById(string id)
    {
        try
        {
            return await _dbContext.Clients.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }
    public async Task<Client> GetByEmail(string email)
    {
        try
        {
            return await _dbContext.Clients.FindAsync(email);
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void Delete(Client obj)
    {
        try
        {
            _dbContext.Clients.Remove(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Update(Client obj)
    {
        try
        {
            _dbContext.Clients.Update(obj);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async void Create(Client obj)
    {
        try
        {
            await _dbContext.Clients.AddAsync(obj);
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