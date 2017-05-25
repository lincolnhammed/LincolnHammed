using LincolnHammed.Models;
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
        private ProductService productService = new ProductService();

        // GET: api/Categories
        public CategoryListAPIModel Get()
        {
            var apiModel = new CategoryListAPIModel();
            try
            {
                apiModel.Result = service.Get().ToList();
            }
            catch (Exception)
            {
                apiModel.Message = "!OK";
            }
            return apiModel;
        }

        public CategoryAPIModel Get(long id)
        {
            var apiModel = new CategoryAPIModel();

            try
            {
                apiModel.Result = service.ById(id);
                if (apiModel.Result != null)
                    apiModel.Result.Products = productService.GetProductsByCategory(id).ToList();
            }
            catch (Exception)
            {
                apiModel.Message = "!OK";
            }
            return apiModel;
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

