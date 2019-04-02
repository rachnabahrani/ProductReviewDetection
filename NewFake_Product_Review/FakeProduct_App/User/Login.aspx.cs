using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["msg"] == "logout")
                {
                    Session.Abandon();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Logout Successfully')", true);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var data = dbContext.UserMasters.Where(x => x.username == txtUsername.Text && x.password == txtPassword.Text).SingleOrDefault();
                if (data != null)
                {
                    if (data.status == true)
                    {
                        Session["userid"] = data.userId;
                        if (Session["pid"] != null)
                        {
                            Response.Redirect("ViewProduct.aspx?productId=" + Session["pid"].ToString() + "");
                        }
                        else
                        {
                            Response.Redirect("index.aspx");
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Your account is Blocked.....')", true);
                    }

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Invalid username and password')", true);
                }
            }
        }
    }
}