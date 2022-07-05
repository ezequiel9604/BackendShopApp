﻿
using System.Text;
using System.Security.Cryptography;

namespace backendShopApp.Microservices.Clienting.ClientInfrastructure.Helpers;

public class Passwords
{

    public static void CreatePassword(string password, out byte[] hash, out byte[] salt)
    {
        var hmac = new HMACSHA512();

        salt = hmac.Key;
        hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
    }

    public static bool VerifyPassword(string password, byte[] hash, byte[] salt)
    {
        var hmac = new HMACSHA512(salt);
        var computedPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return hash.SequenceEqual(computedPass);
    }

}

