using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUQW.Core.interfaces;
using RepositoryPatternWithUQW.Core.Models;

namespace RepositoryPatternWithUQW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBaseRepository<Book> _bookRepository;


        public BooksController(IBaseRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_bookRepository.GetById(1));
        }
        [HttpGet("GetALl")]
        public IActionResult GetAll()
        {
            return Ok(_bookRepository.GetAll());
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_bookRepository.Find(b=>b.Title == "NEW Books ", new[] {"Author"}));
        }

        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_bookRepository.Find(b => b.Title.Contains("NEW Books "), new[] { "Author" }));
        }







    }
}
