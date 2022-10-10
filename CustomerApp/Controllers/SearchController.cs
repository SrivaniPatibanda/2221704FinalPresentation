using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.Models;

namespace CustomerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        CustomerDBContext db = new CustomerDBContext();
     [HttpPost]
        [Route("searchbooks")]
        public IEnumerable<TblBook> Post(string title,string author,string publisher,string releasedate, string price, string image)
        {
            List<TblBook> searchbooks = db.TblBooks.Where(x => x.Title == title ||  x.Publisher == publisher || x.Price == price).ToList();

           // List<TblBook> searchbooks = db.TblBooks.Where(x => x.Title == title || x.Author==author||x.Publisher==publisher ||x.ReleaseDate==releasedate||x.Price==price ).ToList();
            return searchbooks;
        }

        [HttpGet]
        [Route("searchdetails")]
        public IActionResult Get()
        {
            TblBookDataModel tblBookDataModel = null;
            List<TblBookDataModel> tblBookDataModels = new List<TblBookDataModel>();
            List<TblBook> searchbooks = db.TblBooks.ToList();
            if (searchbooks.Count>0)
            {
                
                for (int i = 0; i < searchbooks.Count; i++)
                {
                    tblBookDataModel= new TblBookDataModel();
                    if (searchbooks[i].Active.ToLower() == "yes")
                    {
                        tblBookDataModel.activeflag = true;
                    }
                    else
                    {
                        tblBookDataModel.activeflag = false;
                    }
                    tblBookDataModel.Active = searchbooks[i].Active;
                    tblBookDataModel.Author = searchbooks[i].Author;
                    tblBookDataModel.Category = searchbooks[i].Category;
                    tblBookDataModel.Content = searchbooks[i].Content;
                    tblBookDataModel.Id = searchbooks[i].Id;
                    tblBookDataModel.Image = searchbooks[i].Image;
                    tblBookDataModel.Price = searchbooks[i].Price;
                    tblBookDataModel.Publisher = searchbooks[i].Publisher;
                    tblBookDataModel.ReleaseDate = searchbooks[i].ReleaseDate;
                    tblBookDataModel.Title = searchbooks[i].Title;



                    tblBookDataModels.Add(tblBookDataModel);

                }
                
            }
            else
            {
                return BadRequest();
            }
           
            return Ok(tblBookDataModels);
        }
         
        [HttpPut]
        [Route("block")]
        public IActionResult block([FromQuery]int id)
        {
            var book = db.TblBooks.Where(s => s.Id == id).FirstOrDefault();
            book.Active = "no";
            db.TblBooks.Update(book);
            db.SaveChanges();
            string str = "Succesfully update";
            return Ok(str);
        }

        [HttpPut]
        [Route("unblock")]
        public IActionResult unblock([FromQuery]int id)
        {
            var book = db.TblBooks.Where(s => s.Id == id).FirstOrDefault();
            book.Active = "yes";
            db.TblBooks.Update(book);
            db.SaveChanges();
            string str = "Succesfully update";
            return Ok(str);
        }

    }
}
