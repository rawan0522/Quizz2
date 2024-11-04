using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rawan_Reda.DTO;
using Rawan_Reda.Repo;

namespace Rawan_Reda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutherController : ControllerBase
    {
        private readonly IAutherInterface _repo;
        private readonly IConfiguration _configuration;
        public AutherController(IAutherInterface repo, IConfiguration configuration)
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
        public IActionResult Post([FromBody] AutherDTO dto)
        {
            _repo.ADD(dto);
            return Ok(dto);

        }
        [HttpPut("{id}")]
        public IActionResult Put(AutherDTO dto, int id)
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
    }
}
