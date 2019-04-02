using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
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
                var data = dbContext.CategoryMasters.ToList();
                GridView1.DataSource = data;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    var data = dbContext.CategoryMasters.Where(x => x.categoryId == id).SingleOrDefault();
                    if (data != null)
                    {
                        dbContext.CategoryMasters.Remove(data);
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Delete successfully');window.location='ManageCategory.aspx';", true);
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}