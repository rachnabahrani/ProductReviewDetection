using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["action"] == "edit")
                {
                    int Id = Convert.ToInt32(Request.QueryString["categoryId"]);
                    using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                    {
                        var data = dbContext.CategoryMasters.Where(a => a.categoryId == Id).SingleOrDefault();
                        if (data != null)
                        {
                            txtName.Text = data.category;
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "edit")
            {
                int Id = Convert.ToInt32(Request.QueryString["categoryId"]);
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    CategoryMaster course = dbContext.CategoryMasters.Where(a => a.categoryId == Id).SingleOrDefault();
                    if (course != null)
                    {
                        course.category = txtName.Text;
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Update successfully');window.location='ManageCategory.aspx';", true);
                    }
                }
            }
            else
            {
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    CategoryMaster course = dbContext.CategoryMasters.Where(a => a.category == txtName.Text).SingleOrDefault();
                    if (course == null)
                    {
                        course = new CategoryMaster
                        {
                            category = txtName.Text
                        };
                        dbContext.CategoryMasters.Add(course);
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Add successfully');window.location='ManageCategory.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Message", "alert('Category already exists');", true);
                    }

                }
            }
        }
    }
}