using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUQW.Core.interfaces;
using RepositoryPatternWithUQW.Core.Models;

namespace RepositoryPatternWithUQW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IBaseRepository<Author> _authorRepository;


        public AuthorsController(IBaseRepository<Author> authorRepository)
        {
            _authorRepository= authorRepository;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_authorRepository.GetById(1));
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _authorRepository.GetByIdAsync(1));
        }


        





    }
}
