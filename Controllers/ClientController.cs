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
            ImagePath= req.Genre == "female"? "placeholder-woman.png":"placeholder-man.png", 

            AppearanceId = 1,
            LanguageId = 1,
            CurrancyId = 1,
            TypeId = 1,
            StateId = 2,
        };

        _db.Clients.Add(client);
        _db.SaveChanges();

        return Ok("client signed up!");
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

        var clientDto = new ClientDto
        {
            Id= client.Id,
            FirstName= client.FirstName,
            LastName= client.LastName,
            Email= client.Email,
            ImagePath= client.ImagePath,
            Password= "dummypassword",
            YearOfBirth= client.DateOfBirth.Year,
            MonthOfBirth= client.DateOfBirth.Month,
            DayOfBirth= client.DateOfBirth.Day,
            Genre= client.Genre,
            // State= client.StateId,
            // TypeId= client.TypeId
        };

        var state = (from s in _db.States.ToList()
                    where s.Id == client.StateId select s).FirstOrDefault().Name;

        var type = (from t in _db.Types.ToList()
                    where t.Id == client.StateId select t).FirstOrDefault().Name;

        clientDto.State= state;
        clientDto.Type= type;

        return Ok(new { Token= token, Client= clientDto });
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

    //[Authorize(Roles = "Client")]
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


        // changing between 'connected' and 'offline'
        client.StateId = 2;

        _db.Clients.Update(client);
        _db.SaveChanges();

        return Ok("client logged out!");

    }

    //[Authorize(Roles = "Client")]
    [HttpDelete("Signout")]
    public IActionResult Signout(ClientDto req)
    {
        if (req.Email == "" || req.Password == "")
            return BadRequest("No empty values allowed!");

        var client = (from c in _db.Clients.ToList()
                      where c.Email == req.Email select c).FirstOrDefault();

        if (client is null)
            return BadRequest("Wrong email!");

        if (!VerifyPasswordHash(req.Password, client.PasswordHash, client.PasswordSalt))
            return BadRequest("Wrong password!");

        _db.Clients.Remove(client);
        _db.SaveChanges();

        return Ok("client signed out!");
    }

    //[Authorize(Roles = "Admin")]
    [HttpDelete("Remove")]
    public IActionResult Remove(ClientDto req)
    {
        var client = (from c in _db.Clients.ToList()
                      where c.Id == req.Id  select c).FirstOrDefault();

        if (client is null)
            return BadRequest("client does not exist!");

        _db.Clients.Remove(client);
        _db.SaveChanges();

        return Ok("client removed!");
    }

    //[Authorize(Roles = "Admin")]
    [HttpGet("GetAllClients")]
    public ActionResult<List<ClientDto>> GetAll()
    {
        List<ClientDto> allClients = new List<ClientDto>();

        foreach (var item in _db.Clients.ToList())
        {
            string type = (from t in _db.Types.ToList()
                           where t.Id == item.TypeId select t).FirstOrDefault().Name;

            string state = (from s in _db.States.ToList()
                            where s.Id == item.StateId select s).FirstOrDefault().Name;

            
            // getting phone numbers and creating a PhoneDto list for this specific client
            var phones = (from p in _db.Phones.ToList()
                        where p.ClientId == item.Id select p).ToList();

            var phoneDtos = new List<PhoneDto>();
            if(phones is not null){
                foreach (var p in phones)
                {
                    phoneDtos.Add(new PhoneDto
                    {
                        Id= p.Id,
                        PhoneNumber= p.PhoneNumber,
                    });
                }
            }

            // getting addresses and creating a AddressDto list for this specific client
            var address = (from a in _db.Addresses.ToList()
                            where a.ClientId == item.Id select a).ToList();

            var addressDtos = new List<AddressDto>();
            if(address is not null){
                foreach (var a in address)
                {
                    addressDtos.Add(new AddressDto
                    {
                        Id= a.Id,
                        StreetName= a.StreetName,
                        City= a.City,
                        State= a.State,
                        Department= a.Department,
                        ZipCode= a.ZipCode,
                    });
                }
            }

            // filling the clientDto list that will be sending to the front-end
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
                Password= "dummypassword",

                PhoneDtos = phoneDtos.ToArray(),
                AddressDtos = addressDtos.ToArray(),
                Type = type,
                State = state
            });
        }

        return allClients;
    }

    //[Authorize(Roles = "Client, Admin")]
    [HttpPut("Edit")]
    public IActionResult EditClient(ClientDto req)
    {
        var client = (from c in _db.Clients.ToList()
                    where c.Id == req.Id select c).FirstOrDefault();
        
        if(client is null)
            return BadRequest("client does not exist!");


        client.FirstName= req.FirstName==""?client.FirstName:req.FirstName;
        client.LastName= req.LastName==""?client.LastName:req.LastName;
        client.Email= req.Email==""?client.Email:req.Email;
        client.ImagePath= req.ImagePath==""?client.ImagePath:req.ImagePath;
        client.Genre= req.Genre==""?client.Genre:req.Genre;
        client.TypeId= req.Type==""?client.TypeId:(req.Type=="normal")? 1: 2;
        
        if(req.YearOfBirth != 0 && req.MonthOfBirth != 0 && req.DayOfBirth != 0)
        {
            client.DateOfBirth= new DateTime(req.YearOfBirth, req.MonthOfBirth, req.DayOfBirth);
        }

        // TODO: add addresses to client
        // updating and creating the address for this specific client
        foreach (var addr in req.AddressDtos)
        {
            var address = (from d in _db.Addresses.ToList()
                            where d.Id == addr.Id select d).FirstOrDefault();
            
            if(address is not null)
            {
                address.StreetName= addr.StreetName;
                address.City= addr.City;
                address.State= addr.State;
                address.Department= addr.Department;
                address.ZipCode= addr.ZipCode;

                _db.Addresses.Update(address);
            }
            else{

                var newAddress = new Address
                {
                    StreetName= addr.StreetName,
                    City= addr.City,
                    State= addr.State,
                    Department= addr.Department,
                    ZipCode= addr.ZipCode,
                    ClientId= req.Id
                };

                _db.Addresses.Add(newAddress);
            }
        }

        client.StateId = req.State==""?client.StateId: (req.State=="connected")? 1:
                        (req.State=="retired")? 4: (req.State=="suspended")? 3: 2; 

        // updating password if it fullfills the following rules
        if(req.Password.Length >= 6 && req.Password.Length <= 15 && req.Password != "dummypassword")
        {
            CreatePasswordHash(req.Password, out byte[] passHash, out byte[] passSalt);

            client.PasswordHash = passHash;
            client.PasswordSalt = passSalt;
        }

        _db.Clients.Update(client);

        _db.SaveChanges();

        return Ok("client updated!");
    }


}