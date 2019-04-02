using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class WebForm5 : System.Web.UI.Page
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
                var data = dbContext.UserMasters.ToList();
                GridView1.DataSource = data;
                GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "delete")
            {
                int userId = Convert.ToInt32(e.CommandArgument);
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    var data = dbContext.UserMasters.Where(x => x.userId == userId).SingleOrDefault();
                    if (data != null)
                    {
                        dbContext.UserMasters.Remove(data);
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Delete successfully');window.location='ManageUser.aspx';", true);
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (Convert.ToBoolean(e.Row.Cells[5].Text))
        //        {
        //            e.Row.Cells[5].Text = "UnBlock";
        //            e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
        //        }
        //        else
        //        {
        //            e.Row.Cells[5].Text = "Block";
        //            e.Row.Cells[5].BackColor = System.Drawing.Color.Red;
        //        }
        //    }
        //}
    }
}