using Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LincolnHammed.Models
{
   
    public class CategoryListAPIModel : APIModel
    {
        //iqueryable no lugar da ilist
        public IList<Category> Result { get; set; }
    }

    public class CategoryAPIModel : APIModel
    {
        public Category Result { get; set; }
    }
}