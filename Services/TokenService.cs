using ChantemerleApi.Dao;
using ChantemerleApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ChantemerleApi.Services
{
    public class TokenService
    {
        private TokenDao tokenDao = new TokenDao();
        private string cs = DataModel.databaseCredentials.cs;
        public bool getPermissionFromDatabaseByToken(string token)
        {
            return tokenDao.getPermissionFromDatabaseByToken(token);
        }
        }




    }

