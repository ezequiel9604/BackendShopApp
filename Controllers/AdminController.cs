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
public class AdminController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly  BackendShopAppDbContext _db;

    public AdminController(BackendShopAppDbContext db, IConfiguration config)
    {
        _config = config;
        _db = db;
    }

    [AllowAnonymous]
    [HttpPost("Signup")]
    public IActionResult Signup(AdministratorDto req)
    {
        if(VerifyRequestEmptyValues(req))
            return BadRequest("No empty values allowed!");


        CreatePasswordHash(req.Password, out byte[] passHash, out byte[] passSalt);

        var admin = new Administrator
        {
            FirstName = req.FirstName,
            LastName = req.LastName,
            Email = req.Email,
            PasswordHash = passHash,
            PasswordSalt = passSalt,
            PhoneNumber = req.PhoneNumber,
            ImagePath = "placeholder-man.png"
        };

        _db.Administrators.Add(admin);
        _db.SaveChanges();

        return Ok("admin signed up!");
    }

    private void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
    {
        var hmac = new HMACSHA512();

        passSalt = hmac.Key;
        passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public IActionResult Login(AdministratorDto req)
    {
        if(req.Email == "" || req.Password == "")
            return BadRequest("No empty values allowed!");

        var admin = (from a in _db.Administrators.ToList()
                    where a.Email == req.Email select a).FirstOrDefault();

        if(admin is null)
            return BadRequest("Wrong email!");
        

        if(!VerifyPasswordHash(req.Password, admin.PasswordHash, admin.PasswordSalt))
            return BadRequest("Wrong password!");


        var token = CreateToken(admin);

        var adminDto = new AdministratorDto
        {
            Id= admin.Id,
            FirstName= admin.FirstName,
            LastName= admin.LastName,
            Email= admin.Email,
            Password= "dummypassword",
            ImagePath= admin.ImagePath,
            PhoneNumber= admin.PhoneNumber
        };

        return Ok(new { Token= token, Admin= adminDto });
    }
    
    private bool VerifyPasswordHash(string password, byte[] passHash, byte[] passSalt)
    {
        var hmac = new HMACSHA512(passSalt);
        var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return passHash.SequenceEqual(computedPass);
    }

    private string CreateToken(Administrator admin)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, admin.FirstName),
            new Claim(ClaimTypes.Surname, admin.LastName),
            new Claim(ClaimTypes.Email, admin.Email),
            new Claim(ClaimTypes.Role, "Admin"),   
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
    [HttpDelete("Signout")]
    public IActionResult Signout(AdministratorDto req)
    {
        if(req.Email == "" || req.Password == "")
            return BadRequest("No empty values allowed!");
        
        var admin = (from a in _db.Administrators.ToList()
                    where a.Email == req.Email select a).FirstOrDefault();
        
        if(admin is null)
            return BadRequest("Wrong email!");
        
        if(!VerifyPasswordHash(req.Password, admin.PasswordHash, admin.PasswordSalt))
            return BadRequest("Wrong password!");

        _db.Administrators.Remove(admin);
        _db.SaveChanges();

        return Ok("admin signed out!");
    }

    //[Authorize(Roles = "Admin")]
    [HttpPut("Edit")]
    public IActionResult EditOneAdmin(AdministratorDto req)
    {
        var admin = (from a in _db.Administrators.ToList()
                    where a.Id == req.Id select a).FirstOrDefault();
        
        if(admin is null)
            return BadRequest("Admin not exist!");
        

        admin.FirstName= req.FirstName==""?admin.FirstName:req.FirstName;
        admin.LastName= req.LastName==""?admin.LastName:req.LastName;
        admin.Email= req.Email==""?admin.Email:req.Email;
        admin.ImagePath= req.ImagePath==""?admin.ImagePath:req.ImagePath;
        admin.PhoneNumber= req.PhoneNumber==""?admin.PhoneNumber:req.PhoneNumber;
        
        if(req.Password.Length >= 6 && req.Password.Length <= 15 && req.Password != "dummypassword")
        {
            CreatePasswordHash(req.Password, out byte[] passHash, out byte[] passSalt);

            admin.PasswordHash = passHash;
            admin.PasswordSalt = passSalt;
        }

        _db.Administrators.Update(admin);

        _db.SaveChanges();

        return Ok("admin updated!");
    }

    private bool VerifyRequestEmptyValues(AdministratorDto req)
    {
        bool areAnyoneEmpty = false;
        if(req.Id == "" || req.FirstName == "" || req.LastName == "" || req.Email == "" ||
            req.PhoneNumber == "" || req.ImagePath == "" || req.Password == "")
        {
            areAnyoneEmpty = true;
        }
        return areAnyoneEmpty;
    }

}