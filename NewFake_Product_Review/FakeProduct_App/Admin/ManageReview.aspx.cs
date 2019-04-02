using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class WebForm4 : System.Web.UI.Page
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
            using (FakeProductReviewDbEntities dbContex = new FakeProductReviewDbEntities())
            {
                var data = (from r in dbContex.ReviewMasters
                            join p in dbContex.ProductMasters on r.productId equals p.productId
                            join u in dbContex.UserMasters on r.userId equals u.userId into us
                            from u in us.DefaultIfEmpty()
                            join s in dbContex.SiteMasters on r.siteId equals s.siteId into sm
                            from s in sm.DefaultIfEmpty()
                            select new { reviewId = r.reviewId, productId = r.productId, productName = p.name, userId = r.userId, Username = u.name, siteId = r.siteId, siteName = s.siteName, rating = r.rating, review = r.review, addedDate = r.addedDate, score = r.score }).ToList();
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
                    var data = dbContext.ReviewMasters.Where(x => x.reviewId == id).SingleOrDefault();
                    if (data != null)
                    {
                        dbContext.ReviewMasters.Remove(data);
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Delete successfully');window.location='ManageReview.aspx';", true);
                    }
                }
            }
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}