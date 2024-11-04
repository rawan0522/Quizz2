using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Rawan_Reda.DTO;
using Rawan_Reda.Models;
using Rawan_Reda.Repo;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Rawan_Reda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookInterface _repo;
        private readonly IConfiguration _configuration;
        public BookController(IBookInterface repo , IConfiguration configuration) 
        { 
         _repo = repo;
            _configuration = configuration;
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var s = _repo.GetById(id);
                return Ok(s);
            }

            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var s = _repo.GetAll();
                return Ok(s);
            }

            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDTO dto)
        {
            _repo.ADD(dto);
            return Ok(dto);

        }
          [HttpPut("{id}")]
        public IActionResult Put(BookDTO dto, int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Update(dto, id);
                    return Ok(dto);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _repo.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }





        [HttpPost("Login")]
        public IActionResult ValidateStudent([FromBody] BookDTO dto)
        {
            var b = _repo.ValidateBook(dto.Title);
            if (b == null)
            {
                return Unauthorized();
            }
            var token = GenerateJwtToken(b);
            return Ok(new { token });
        }

        private string GenerateJwtToken(Book book)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, book.Title),
                new Claim(ClaimTypes.NameIdentifier , book.Id.ToString())
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issure"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
