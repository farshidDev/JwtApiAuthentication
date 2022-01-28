using JwtApiAuthenticationApp.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JwtApiAuthenticationApp.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IJwtAuthenticationManager _jwtAuthenticationManager;
        public DataController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            _jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [HttpGet("GetData")]
        public string GetData()
        {
            return "here is data ...";
        }

        [HttpPost("SignIn")]
        [AllowAnonymous]
        public IActionResult SignIn(string username, string password)
        {
            var token = _jwtAuthenticationManager.Authenticate(username, password);

            if (string.IsNullOrEmpty(token))
                return Unauthorized();

            return Ok(token);
        }
    }
}
