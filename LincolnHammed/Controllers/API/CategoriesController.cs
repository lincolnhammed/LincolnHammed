using Models.Register;
using Models.Tables;
using Service.Registration;
using Service.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace LincolnHammed.Controllers.API
{
    public class CategoriesController : ApiController
    {
        // GET: api/Categories
        private CategoryService service = new CategoryService();

        // GET: api/Categories
        public IEnumerable<Category> Get()
        {
            Category category = new Category();

            return service.Get();
        }

        // GET: api/Categories/5
        public Category Get(long id)
        {
            return service.GetCategoryById(id);
        }

        // POST: api/Categories
        public void Post([FromBody]Category value)
        {
            service.SaveCategory(value);

        }

        // PUT: api/Categories/5
        public void Put(long? id, [FromBody]Category value)
        {
            service.SaveCategory(value);
        }

        // DELETE: api/Categories/5
        public void Delete(long id)
        {
            service.DeleteCategoryForId(id);
        }
    }
}

