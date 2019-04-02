using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var data = dbContext.UserMasters.Where(x => x.username == txtUsername.Text).SingleOrDefault();
                if (data == null)
                {
                    data = new UserMaster
                    {
                        username = txtUsername.Text,
                        password = txtPassword.Text,
                        name = txtName.Text,
                        email = txtEmail.Text,
                        contact = txtContact.Text,
                        address = txtAddress.Text,
                        //score = 2.0,
                        //status = true
                    };
                    dbContext.UserMasters.Add(data);
                    dbContext.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Account created successfully');window.location='Login.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Username already exists')", true);
                }
            }
        }
    }
}