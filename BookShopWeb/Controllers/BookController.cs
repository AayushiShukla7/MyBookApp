﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookShopWeb.Models;

namespace BookShopWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase    //Use 'ControllerBase' instead of 'Controller' --> Makes it easier to control and use
    {
        public IActionResult Get()
        {
            //Good Idea - To use some mock sample data/JSON file/Data file --> until your DB is ready
            //Makes it easier to focus on static data with no NOISE, get everything in order at the front end. And then, move to developing the backend. Make sure all your connections and actions work as expected first!
            var bookList = new List<Book>();
            bookList.Add(new Book
            {
                Name = "The Subtle Art Of Not Giving A Fuck!",
                PublishYear = 2016,
                Price = 499
            });
            bookList.Add(new Book
            {
                Name = "Learn C#",
                PublishYear = 2019,
                Price = 123.45M
            });
            bookList.Add(new Book
            {
                Name = "Learn VueJS",
                PublishYear = 2018,
                Price = 45.99M
            });
            bookList.Add(new Book
            {
                Name = "Learn MongoDb",
                PublishYear = 2019,
                Price = 70.01M
            });

            return Ok(bookList);
        }
    }
}