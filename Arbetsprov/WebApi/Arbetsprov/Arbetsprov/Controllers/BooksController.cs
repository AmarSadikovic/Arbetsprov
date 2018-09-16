using System.Collections.Generic;
using System.Linq;
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
            var xelement = XElement.Load(filepath);
            var books = xelement.Elements("book").Where(x => x.Element("title").Value.ToString().ToLower().Contains(id.ToLower()));
            return books;
        }
        // POST: api/Books
        public void Post([FromBody]string value)
        {
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
