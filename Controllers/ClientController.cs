using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backendShopApp.Models;
using backendShopApp.DataContext;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace backendShopApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly BackendShopAppDbContext _db;

    public ClientController(BackendShopAppDbContext db, IConfiguration config)
    {
        _config = config;
        _db = db;
    }

    [AllowAnonymous]
    [HttpPost("Signup")]
    public IActionResult Signup(ClientDto req)
    {

        if (req.FirstName == "" || req.LastName == "" || req.Email == "" || req.Password == "" ||
            req.Genre == "" || req.YearOfBirth == 0 || req.MonthOfBirth == 0 || req.DayOfBirth == 0)
        {
            return BadRequest("No empty values allowed!");
        }

        CreatePasswordHash(req.Password, out byte[] passHash, out byte[] passSalt);

        // creating an id to new client
        var randomId = "CLT-" + new Random().Next(1000, 9999); ;
        while (true)
        {
            var existingClient = (from c in _db.Clients.ToList()
                                  where c.Id == randomId
                                  select c).FirstOrDefault();

            if (existingClient is null)
                break;

            randomId = "CLT-" + new Random().Next(1000, 9999);
        }

        var client = new Client
        {
            Id = randomId,
            FirstName = req.FirstName,
            LastName = req.LastName,
            Email = req.Email,
            DateOfBirth = new DateTime(req.YearOfBirth,
                            req.MonthOfBirth, req.DayOfBirth),
            Genre = req.Genre,
            PasswordHash = passHash,
            PasswordSalt = passSalt,
            ImagePath= req.Genre == "female"? 
                        "placeholder-woman.png":"placeholder-man.png", 

            AppearanceId = 1,
            LanguageId = 1,
            CurrancyId = 1,
            TypeId = 1,
            StateId = 2,
        };

        _db.Clients.Add(client);
        _db.SaveChanges();

        return Ok(client);
    }

    private void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
    {
        var hmac = new HMACSHA512();

        passSalt = hmac.Key;
        passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public IActionResult Login(ClientDto req)
    {
        if (req.Email == "" || req.Password == "")
            return BadRequest("No empty values allowed!");

        var client = (from c in _db.Clients.ToList<Client>()
                      where c.Email == req.Email
                      select c).FirstOrDefault();

        if (client is null)
            return BadRequest("Wrong email!");


        if (!VerifyPasswordHash(req.Password, client.PasswordHash, client.PasswordSalt))
            return BadRequest("Wrong password!");

        // creating a token for user logged in
        var token = CreateToken(client);

        // changing between 'offline' and 'connected'
        client.StateId = 1;

        _db.Clients.Update(client);
        _db.SaveChanges();

        return Ok(new { Token= token, Client= client });
    }

    private bool VerifyPasswordHash(string password, byte[] passHash, byte[] passSalt)
    {
        var hmac = new HMACSHA512(passSalt);
        var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return passHash.SequenceEqual(computedPass);
    }

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

    [Authorize(Roles = "Client")]
    [HttpPost("Logout")]
    public IActionResult Logout(ClientDto req)
    {

        if (req.Email == "" || req.Password == "")
            return BadRequest("No empty values allowed!");

        var client = (from c in _db.Clients.ToList<Client>()
                      where c.Email == req.Email
                      select c).FirstOrDefault();

        if (client is null)
            return BadRequest("Wrong email!");


        if (!VerifyPasswordHash(req.Password, client.PasswordHash, client.PasswordSalt))
            return BadRequest("Wrong password!");

        // creating a token for user logged in
        var token = CreateToken(client);

        // changing between 'connected' and 'offline'
        client.StateId = 2;

        _db.Clients.Update(client);
        _db.SaveChanges();

        return Ok(client);

    }

    [Authorize(Roles = "Client")]
    [HttpPost("Signout")]
    public IActionResult Signout(ClientDto req)
    {
        if (req.Email == "" || req.Password == "")
            return BadRequest("No empty values allowed!");

        var client = (from c in _db.Clients.ToList()
                      where c.Email == req.Email
                      select c).FirstOrDefault();

        if (client is null)
            return BadRequest("Wrong email!");

        if (!VerifyPasswordHash(req.Password, client.PasswordHash, client.PasswordSalt))
            return BadRequest("Wrong password!");

        _db.Clients.Remove(client);
        _db.SaveChanges();

        return Ok(client);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("GetAllClients")]
    public ActionResult<List<ClientDto>> GetAll()
    {
        List<ClientDto> allClients = new List<ClientDto>();

        foreach (var item in _db.Clients.ToList())
        {
            string type = (from t in _db.Types.ToList()
                           where t.Id == item.TypeId
                           select t).FirstOrDefault().Name;

            string state = (from s in _db.States.ToList()
                            where s.Id == item.StateId
                            select s).FirstOrDefault().Name;

            List<Phone> phones = (item.Phones is not null) ?
                item.Phones.FindAll(p => p.ClientId == item.Id) : null;

            List<Address> address = (item.Addresses is not null) ?
                item.Addresses.FindAll(a => a.ClientId == item.Id) : null;

            allClients.Add(new ClientDto
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                Genre = item.Genre,
                ImagePath = item.ImagePath,
                YearOfBirth = item.DateOfBirth.Year,
                MonthOfBirth = item.DateOfBirth.Month,
                DayOfBirth = item.DateOfBirth.Day,

                Phones = phones,
                Addresses = address,
                Type = type,
                State = state
            });
        }

        return allClients;
    }

}