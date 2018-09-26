using Arbetsprov.Models;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Xml.Linq;

namespace Arbetsprov.Controllers
{
    [EnableCors("*", "*", "*")]
    public class BooksController : ApiController
    {
        private string filepath = HttpRuntime.AppDomainAppPath + "//Resources//books.xml";

        // GET: api/Books
        public IEnumerable<XElement> Get()
        {
            var xelement = XElement.Load(filepath);
            var books = xelement.Elements("book");
            return books;
        }

        // GET: api/Books/title
        public IEnumerable<XElement> Get(string id)
        {
            System.Diagnostics.Debug.WriteLine("API POOOOOST" +id);
            var xelement = XElement.Load(filepath);
            var books = xelement.Elements("book").Where(x => x.Element("title").Value.ToString().ToLower().Contains(id.ToLower()));
            return books;
        }
  
        public HttpResponseMessage Post(Book book)
        {
            var xDoc = XElement.Load(filepath);
            var count = xDoc.Descendants("book").Count();
            var newBook = new XElement("book");
            count++;
            newBook.Add(new XAttribute("id", "B" + count));
            newBook.Add(new XElement("author", book.author));
            newBook.Add(new XElement("title", book.title));
            newBook.Add(new XElement("genre", book.genre));
            newBook.Add(new XElement("price", book.price));
            newBook.Add(new XElement("publish_date", book.publish_date));
            newBook.Add(new XElement("description", book.description));
            xDoc.Add(newBook);
            xDoc.Save(filepath);
            //return new HttpResponseMessage(HttpStatusCode.Created);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
        
        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
