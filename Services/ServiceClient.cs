using backendShopApp.Repositories;
using backendShopApp.Models;
using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace backendShopApp.Services;

public class ServiceClient : IServiceClient
{   
    private readonly IConfiguration _config;
    private readonly IRepositoryClient _repositoryClient;
    private readonly IRepositoryAddress _repositoryAddress;
    private readonly IRepositoryPhone _repositoryPhone;
    private readonly IRepositoryAppearance _repositoryAppearance;
    private readonly IRepositoryLanguage _repositoryLanguage;
    private readonly IRepositoryCurrancy _repositoryCurrancy;
    private readonly IRepositoryState _repositoryState;
    private readonly IRepositoryType _repositoryType;
    private readonly IMapper _mapper;

    public ServiceClient(
        IRepositoryClient repositoryClient, IRepositoryAddress repositoryAddress, 
        IRepositoryPhone repositoryPhone, IRepositoryAppearance repositoryAppearance, 
        IRepositoryLanguage repositoryLanguage, IRepositoryCurrancy repositoryCurrancy,
        IRepositoryType repositoryType, IRepositoryState repositoryState,
        IConfiguration config, IMapper mapper)
    {
        _repositoryClient = repositoryClient;
        _repositoryAddress = repositoryAddress;
        _repositoryPhone = repositoryPhone;
        _repositoryAppearance = repositoryAppearance;
        _repositoryLanguage = repositoryLanguage;
        _repositoryCurrancy = repositoryCurrancy;
        _repositoryType= repositoryType;
        _repositoryState= repositoryState;
        _config = config;
        _mapper = mapper;
    }

    // DONE
    public object Login(string email, string password)
    {
        if(email.IsNullOrEmpty() || password.IsNullOrEmpty())
            return "No empty allow!";

        try
        {
            var client = _repositoryClient.GetByEmail(email);

            if(client is null)
                return "No exist!";

            if(!VerifyPasswordHash(password, client.PasswordHash, client.PasswordSalt))
                return "No password!";

            client.StateId = 1;

            int affectedRows =  _repositoryClient.Update(client);
            
            if(affectedRows < 1)
                return "No inserted"!;


            var token= CreateToken(client);
            
            var addresses = _repositoryAddress.GetByClientId(client.Id);
            var phones = _repositoryPhone.GetByClientId(client.Id);
            var appea = _repositoryAppearance.GetById(client.AppearanceId);
            var lang = _repositoryLanguage.GetById(client.LanguageId);
            var curr = _repositoryCurrancy.GetById(client.CurrancyId);
            var type = _repositoryType.GetById(client.TypeId);
            var state = _repositoryState.GetById(client.StateId);

            var cdto = _mapper.Map<ClientDto>(client);
            cdto.Appearance= appea.Name;
            cdto.Language= lang.Name;
            cdto.Currancy= curr.Name;
            cdto.Type= type.Name;
            cdto.State= state.Name;
            cdto.AddressDtos = _mapper.Map<List<AddressDto>>(addresses).ToArray();
            cdto.PhoneDtos = _mapper.Map<List<PhoneDto>>(phones).ToArray();

            return new { Token=token, Client=cdto };

        }
        catch (Exception)
        {
            return "Database error!";
        }
    }

    // DONE
    public string Signup(ClientDto clientdto)
    {

        if(clientdto.FirstName.IsNullOrEmpty() || clientdto.LastName.IsNullOrEmpty() || 
            clientdto.Email.IsNullOrEmpty() || clientdto.Password.IsNullOrEmpty() || 
            clientdto.Genre.IsNullOrEmpty())
        {
            return "No empty allow!";
        }

        try
        {

            // checking if email exist already
            if(_repositoryClient.GetByEmail(clientdto.Email) is not null)
                return "Already exist!";

            CreatePasswordHash(clientdto.Password, out byte[] hash, out byte[] salt);

            // creating an id to new client
            var randomId = "CLT-" + new Random().Next(1000, 9999);
            while (true)
            {
                if (_repositoryClient.GetById(randomId) is null)
                    break;

                randomId = "CLT-" + new Random().Next(1000, 9999);
            }

            var client = _mapper.Map<Client>(clientdto);
            client.Id = randomId;
            client.PasswordHash= hash;
            client.PasswordSalt= salt;
            client.ImagePath= clientdto.ImagePath.IsNullOrEmpty()? 
                                "placeholder-man.png":clientdto.ImagePath;
            client.AppearanceId = 1;
            client.LanguageId = 1;
            client.CurrancyId = 1;
            client.StateId = 2;
            client.TypeId = 1;

            int affectedRows = _repositoryClient.Create(client);

            if(affectedRows > 0)
                return "Success!";

            return "No inserted!";

        }
        catch (Exception)
        {   
            return "Database error!";
        }

    }

    // DONE
    public string Create(ClientDto clientdto)
    {

        if(clientdto.FirstName.IsNullOrEmpty() || clientdto.LastName.IsNullOrEmpty() || 
            clientdto.Email.IsNullOrEmpty() || clientdto.Password.IsNullOrEmpty() || 
            clientdto.Genre.IsNullOrEmpty() || clientdto.ImagePath.IsNullOrEmpty() || 
            clientdto.Type.IsNullOrEmpty())
        {
            return "No empty allow!";
        }

        try
        {
            // checking if email exist already
            if(_repositoryClient.GetByEmail(clientdto.Email) is not null)
                return "Already exist!";

            CreatePasswordHash(clientdto.Password, out byte[] hash, out byte[] salt);

            // creating an id to new client
            var randomId = "CLT-" + new Random().Next(1000, 9999);
            while (true)
            {
                if (_repositoryClient.GetById(randomId) is null)
                    break;

                randomId = "CLT-" + new Random().Next(1000, 9999);
            }

            var client = _mapper.Map<Client>(clientdto);
            client.Id= randomId;
            client.PasswordHash= hash;
            client.PasswordSalt= salt;
            client.DateOfBirth= new DateTime(clientdto.YearOfBirth, clientdto.MonthOfBirth, clientdto.DayOfBirth);

            if(!clientdto.AddressDtos.IsNullOrEmpty())
                client.Addresses= _mapper.Map<List<Address>>(clientdto.AddressDtos);

            if(!clientdto.PhoneDtos.IsNullOrEmpty())
                client.Phones= _mapper.Map<List<Phone>>(clientdto.PhoneDtos);

            client.TypeId= (clientdto.Type== "normal")? 1: (clientdto.Type=="express")? 2:1;
            client.AppearanceId = 1;
            client.LanguageId = 1;
            client.CurrancyId = 1;
            client.StateId = 2;

           int affectedRows =  _repositoryClient.Create(client);

            if(affectedRows > 0)
                return "Success!";

            return "No inserted!";

        }
        catch (Exception)
        {
            return "Database error!";
        }

    }

    // DONE
    public string Delete(string email, string password)
    {

        if(email.IsNullOrEmpty() || password.IsNullOrEmpty())
            return "No empty allow!";

        try
        {
            var client = _repositoryClient.GetByEmail(email);

            if(client is null)
                return "No exist!";

            if(!VerifyPasswordHash(password, client.PasswordHash, client.PasswordSalt))
                return "No password!";


            int affectedRows=  _repositoryClient.Delete(client);

            if(affectedRows > 0)
                return "Success!";

            return "No inserted!";

        }
        catch (Exception)
        {
            return "Database error!";
        }

    }

    // DONE
    public string Logout(string email)
    {
        if(email.IsNullOrEmpty())
            return "No empty allow!";

        try
        {
            var client = _repositoryClient.GetByEmail(email);

            if(client is null)
                return "No exist!";


            client.StateId = 2;

            int affectedRows =  _repositoryClient.Update(client);
            
            if(affectedRows > 0)
                return "Success!";

            return "No inserted!";

        }
        catch (Exception)
        {
            return "Database error!";
        }

    }

    // DONE
    public List<ClientDto> GetAll()
    {
        try
        {
            var clients = _repositoryClient.GetAll();

            if(clients is null)
                return new List<ClientDto>();
            
            
            var clientDtos = new List<ClientDto>();
            foreach (var cli in clients)
            {
                var addresses = _repositoryAddress.GetByClientId(cli.Id);
                var phones = _repositoryPhone.GetByClientId(cli.Id);
                var appea = _repositoryAppearance.GetById(cli.AppearanceId);
                var lang = _repositoryLanguage.GetById(cli.LanguageId);
                var curr = _repositoryCurrancy.GetById(cli.CurrancyId);
                var type = _repositoryType.GetById(cli.TypeId);
                var state = _repositoryState.GetById(cli.StateId);

                var cdto = _mapper.Map<ClientDto>(cli);
                cdto.Appearance= appea.Name;
                cdto.Language= lang.Name;
                cdto.Currancy= curr.Name;
                cdto.Type= type.Name;
                cdto.State= state.Name;
                cdto.AddressDtos = _mapper.Map<List<AddressDto>>(addresses).ToArray();
                cdto.PhoneDtos = _mapper.Map<List<PhoneDto>>(phones).ToArray();

                clientDtos.Add(cdto);

            }

            return clientDtos;

        }
        catch (Exception)
        {
            return new List<ClientDto>();
        }

    }

    public string Update(ClientDto clientdto)
    {

        try
        {
            var client = _repositoryClient.GetById(clientdto.Id);

            if(client is null)
                return "No exist!";

            // whatchout this code
            if(!clientdto.FirstName.IsNullOrEmpty())
                client.FirstName = clientdto.FirstName;
            
            if(!clientdto.LastName.IsNullOrEmpty())
                client.LastName = clientdto.LastName;

            if(!clientdto.Genre.IsNullOrEmpty())
                client.Genre = clientdto.Genre;
            
            if(!clientdto.ImagePath.IsNullOrEmpty())
                client.ImagePath = clientdto.ImagePath;
            
            if(!clientdto.Email.IsNullOrEmpty())
                client.Email = clientdto.Email;

            if(!clientdto.Password.IsNullOrEmpty())
            {
                CreatePasswordHash(clientdto.Password, out byte[] hash, out byte[] salt);
                client.PasswordHash= hash;
                client.PasswordSalt= salt;
            }

            if(clientdto.AddressDtos.IsNullOrEmpty())
                client.Addresses= _mapper.Map<List<Address>>(clientdto.AddressDtos);
            
            if(clientdto.PhoneDtos.IsNullOrEmpty())
                client.Phones= _mapper.Map<List<Phone>>(clientdto.PhoneDtos);

            if(clientdto.YearOfBirth != 0)
                client.DateOfBirth= new DateTime(clientdto.YearOfBirth, clientdto.MonthOfBirth, clientdto.DayOfBirth);

            if(!clientdto.Type.IsNullOrEmpty())
                client.TypeId= (clientdto.Type== "normal")? 1: (clientdto.Type=="express")? 2:1;

            if(!clientdto.Appearance.IsNullOrEmpty())
                client.AppearanceId= (clientdto.Appearance== "light")? 1: (clientdto.Type=="dark")? 2:1;
            
            if(!clientdto.Language.IsNullOrEmpty())
                client.LanguageId= (clientdto.Language== "english")? 1: (clientdto.Language=="spanish")? 2:1;

            _repositoryClient.Update(client);

            return "Success!";
        }
        catch (Exception)
        {
            return "Database error!";
        }

    }

    // DONE
    private bool VerifyPasswordHash(string password, byte[] hash, byte[] salt)
    {
        var hmac = new HMACSHA512(salt);
        var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return hash.SequenceEqual(computedPass);
    }

    // DONE
    private string CreateToken(Client client)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, client.FirstName),
            new Claim(ClaimTypes.Surname, client.LastName),
            new Claim(ClaimTypes.Email, client.Email),
            new Claim(ClaimTypes.Role, "Client"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _config.GetSection("AppSettings:TokenKey").Value
        ));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    // DONE
    private void CreatePasswordHash(string password, out byte[] hash, out byte[] salt)
    {
        var hmac = new HMACSHA512();

        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

}