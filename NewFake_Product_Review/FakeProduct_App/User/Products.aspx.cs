using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                fillProducts();
            }
        }

        private void fillProducts()
        {
            int cId = Convert.ToInt32(Request.QueryString["cId"]);
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var data = dbContext.ProductMasters.Where(x => x.categoryId == cId).ToList();
                Repeater1.DataSource = data;
                Repeater1.DataBind();
            }
        }
    }
}