using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillRepeterCategory();
            }
        }
        private void fillRepeterCategory()
        {
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var data = dbContext.CategoryMasters.ToList();
                Repeater1.DataSource = data;
                Repeater1.DataBind();
            }
        }
    }
}