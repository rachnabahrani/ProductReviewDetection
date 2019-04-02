using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillGridview();
            }
        }

        private void fillGridview()
        {
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var data = (from p in dbContext.ProductMasters
                            join c in dbContext.CategoryMasters on p.categoryId equals c.categoryId
                            select new { productId = p.productId, categoryName = c.category, name = p.name, img = p.img }).ToList();
                GridView1.DataSource = data;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    var data = dbContext.ProductMasters.Where(x => x.productId == id).SingleOrDefault();
                    if (data != null)
                    {
                        dbContext.ProductMasters.Remove(data);
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Delete successfully');window.location='ManageProduct.aspx';", true);
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}