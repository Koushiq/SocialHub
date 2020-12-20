using SocialHub.Models;
//using Inventory_with_Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SocialHub.Repositories
{
    public class ProductRepository:Repository<Post>
    {
        /*public List<Post> GetTopProducts(int top)
        {
            return this.GetAll().OrderByDescending(x => x.Price).Take(top).ToList();
        }
        */
    }
}