using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
     
            private static List<Book> books = new List<Book>()
            {
                new Book()
                {
                    Id = 1,
                    Title ="The World",
                    Author ="Enas Murrar ",
                    Description = "imagination book "

                },
                   new Book()
                {
                    Id = 2,
                    Title ="smile",
                    Author ="lina  ",
                    Description = "funny book "

                },

            };
        //*******************************************************
        [HttpGet]
        [Route("getBooks")]
        public async Task<ActionResult<Book>> GetBooks()
        {
            return Ok(books);
        }
        //********************************************************
        [HttpGet]
        [Route("getBook")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = books.Find(x => x.Id == id);
            if (book == null)
                return BadRequest("No book found !!");
            return Ok(book);
        }
        //*******************************************************
        [HttpPost]
        [Route("addBook")]
        public async Task<ActionResult<Book>> addBook(Book need)
        {
            books.Add(need);
            return Ok(books);
        }
        //******************************************************
        [HttpPut]
        [Route("updateBook")]
        public async Task<ActionResult<Book>> updateBook(Book need)
        {
            var book = books.Find(x => x.Id ==need.Id);
            if (book == null)
                return BadRequest("No book found !!");
            book.Id = need.Id;
            book.Title = need.Title;
            book.Author = need.Author;
            book.Description = need.Description;

            return Ok(books);
        }
        //******************************************************
        [HttpDelete]
        [Route("deleteBook")]
        public async Task<ActionResult<Book>> deleteBook(int id)
        {
            var book = books.Find(x => x.Id == id);
            if (book == null)
                return BadRequest("No book found !!");

            books.Remove(book);
            return Ok(books);
        }
    }
}
