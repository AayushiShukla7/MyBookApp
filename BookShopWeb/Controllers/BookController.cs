using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookShopWeb.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BookShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase    //Use 'ControllerBase' instead of 'Controller' --> Makes it easier to control and use
    {
        [HttpGet]
        public IActionResult Get()
        {
            //Good Idea - To use some mock sample data/JSON file/Data file --> until your DB is ready
            //Makes it easier to focus on static data with no NOISE, get everything in order at the front end. And then, move to developing the backend. Make sure all your connections and actions work as expected first!
            //var bookList = new List<Book>();
            //bookList.Add(new Book
            //{
            //    Name = "The Subtle Art Of Not Giving A Fuck!",
            //    Year = 2016,
            //    Price = 499
            //});
            //bookList.Add(new Book
            //{
            //    Name = "Learn C#",
            //    Year = 2019,
            //    Price = 123.45M
            //});
            //bookList.Add(new Book
            //{
            //    Name = "Learn VueJS",
            //    Year = 2018,
            //    Price = 45.99M
            //});
            //bookList.Add(new Book
            //{
            //    Name = "Learn MongoDb",
            //    Year = 2019,
            //    Price = 70.01M
            //});

            //return Ok(bookList);

            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("VirtualLibraryDb");
            var books = db.GetCollection<Book>("Books");

            var bookList = books.Find(FilterDefinition<Book>.Empty).ToList();

            //This shows the whole database if DB is not queried
            //return Ok(books);

            return Ok(bookList);
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            //Save data to database
            var client = new MongoDB.Driver.MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("VirtualLibraryDb");
            var books = db.GetCollection<Book>("Books");
            var bookList = books.Find(FilterDefinition<Book>.Empty).ToList();

            books.InsertOneAsync(new Book { Name = model.Name, Year = model.Year, Price = model.Price });
            //What's a better way to refresh collection (apart from using async-await)
            bookList = books.Find(FilterDefinition<Book>.Empty).ToList();

            //var filter = Builders<Book>.Filter.Empty;
            //books.ReplaceOne(filter, new Book { Name = model.Name, Year = model.Year, Price = model.Price });

            return Ok(bookList);
        }
    }
}