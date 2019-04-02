using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["msg"] == "logout")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Logout Successfully')", true);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var data = dbContext.AdminLogins.Where(x => x.username == txtUsername.Text && x.password == txtPassword.Text).SingleOrDefault();
                if (data != null)
                {
                    Session["adminid"] = data.aId;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Invalid username and password')", true);
                }
            }
        }
    }
}