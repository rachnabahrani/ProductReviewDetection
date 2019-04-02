using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["action"] == "edit")
                {
                    int userId = Convert.ToInt32(Request.QueryString["userId"]);
                    using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                    {
                        var data = dbContext.UserMasters.Where(x => x.userId == userId).SingleOrDefault();
                        if (data != null)
                        {
                            txtUsername.Text = data.username;
                            txtPassword.Text = data.password;
                            txtName.Text = data.name;
                            txtEmail.Text = data.email;
                            txtContact.Text = data.contact;
                            txtAddress.Text = data.address;
                            //ddlStatus.SelectedValue = Convert.ToInt32(data.status).ToString();
                        }
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "edit")
            {
                int userId = Convert.ToInt32(Request.QueryString["userId"]);
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    var data = dbContext.UserMasters.Where(x => x.userId == userId).SingleOrDefault();
                    if (data != null)
                    {
                        data.username = txtUsername.Text;
                        data.password = txtPassword.Text;
                        data.name = txtName.Text;
                        data.email = txtEmail.Text;
                        data.contact = txtContact.Text;
                        data.address = txtAddress.Text;
                        //data.status = Convert.ToBoolean(Convert.ToInt32(ddlStatus.SelectedValue));
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Update successfully');window.location='ManageUser.aspx';", true);
                    }
                }
            }
        }
    }
}