using MassTransit;
using SharedData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Author.Consumers
{
    public class AuthorConsumer : IConsumer<TblBook>
    {
        CustomerDBContext db;
        public AuthorConsumer(CustomerDBContext _db)
        {
            db = _db;
        }
        public Task Consume(ConsumeContext<TblBook> context)
        {
            var data = context.Message;
            var productdata = db.TblBooks.Where(x => x.Id == data.Id).FirstOrDefault();
            productdata.Title = productdata.Title;
            db.TblBooks.Update(productdata);
            db.SaveChanges();
            return Task.CompletedTask;
        }

    }




}

