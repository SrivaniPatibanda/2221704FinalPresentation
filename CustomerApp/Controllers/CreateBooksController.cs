using CustomerApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CustomerAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateBooksController : ControllerBase
    {
        CustomerDBContext db = new CustomerDBContext();
        [HttpGet]

        //public IEnumerable<TblSearch> Get()
        //{
        //    return db.TblSearches;//
        //}

        [HttpPost]

        [Route("createbooks")]// this is for create books (Author) so we are using post method
      
        public IActionResult Post([FromForm] CreateBook createbook)
        {
            var file = Request.Form.Files[0];
            var foldername = "Images";
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), foldername);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(foldername, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                TblBook createBook = new TblBook();
                createBook.Title = createbook.Title.ToString();
                createBook.Image = dbPath;
                createBook.Active = createbook.Active.ToString();
                createBook.Category = createbook.Category.ToString();
                createBook.Content = createbook.Content.ToString();
                createBook.Price = createbook.Price.ToString();
                createBook.Publisher = createbook.Publisher.ToString();

                db.TblBooks.Add(createBook);
               // db.Entry(TblBook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                var response = new { Status = "Success" };
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }



        //[HttpDelete]
        //public IActionResult Delete(int

        //    var data = db.TblSearches.Where(x => x.Id == id).FirstOrDefault();
        //    db.TblSearches.Remove(data);
        //    db.SaveChanges();
        //    var response = new { Status = "Success" };
        //    return Ok(response);
        //}

       // [HttpPut]
        //public IActionResult Put(TblSearch abc)
        //{
        //    db.Customers.Add(customer);
        //    db.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    db.SaveChanges();
        //    var response = new { Status = "Success" };
        //    return Ok(response);

        //}

    }
}