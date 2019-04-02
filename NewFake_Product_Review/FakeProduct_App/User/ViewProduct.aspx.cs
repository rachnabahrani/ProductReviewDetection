using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        public ProductMaster product = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            int productId = Convert.ToInt32(Request.QueryString["productId"]);
            Session["pid"] = productId;
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                product = dbContext.ProductMasters.Where(x => x.productId == productId).SingleOrDefault();
            }
            FillReview();
        }

        public void FillReview()
        {
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                int productid = Convert.ToInt32(Request.QueryString["productId"]);
                List<ReviewHelper> ReviewData = (from rm in dbContext.ReviewMasters
                                                 where (rm.productId == productid)
                                                 join um in dbContext.UserMasters on rm.userId equals um.userId
                                                 select new ReviewHelper { ReviewId = rm.reviewId, UserId = rm.userId, UserName = um.name, Review = rm.review, Date = rm.addedDate, Rating = rm.rating, Score = rm.score }).ToList();
                Repeater1.DataSource = ReviewData;
                Repeater1.DataBind();
            }
        }



        protected void btnSumbit_Click(object sender, EventArgs e)
        {
            if (Rating2.CurrentRating == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Please Give rating')", true);
                return;
            }
            Session["pid"] = Convert.ToInt32(Request.QueryString["productId"]);
            int productid = Convert.ToInt32(Session["pid"]);
            int UserId = Convert.ToInt32(Session["userid"]);
            if (Session["userid"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                double score = PosFile.postagger(PosFile.TraggerMain(txtReview.Value));
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    //if (Rating2.CurrentRating <= 2 && score < 0 || Rating2.CurrentRating >= 2 && score >= 0 || Rating2.CurrentRating >= 2 && score <= 0 || Rating2.CurrentRating <= 2 && score >= 0)
                    //{
                    Session["Review"] = txtReview.Value;
                    Session["Rating"] = Rating2.CurrentRating.ToString();
                    Session["score"] = score;

                    ReviewMaster review = new ReviewMaster
                    {
                        productId = productid,
                        reviewTypeId = 2,
                        userId = UserId,
                        rating = Rating2.CurrentRating,
                        review = txtReview.Value,
                        score = score,
                        addedDate = DateTime.Now
                    };
                    dbContext.ReviewMasters.Add(review);
                    dbContext.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Your review submit successfully');window.location='index.aspx';", true);


                    //Response.Redirect("DefaultReviews.aspx?ProductId=" + Session["pid"].ToString());
                    // }

                    //else
                    //{
                    //    int userId = Convert.ToInt32(Session["userid"]);
                    //    UserMaster user = dbContext.UserMasters.Where(x => x.userId == userId).SingleOrDefault();
                    //    if (user != null)
                    //    {
                    //        user.status = false;
                    //        dbContext.SaveChanges();
                    //        Session.Abandon();
                    //        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Your Review is not trustwordhy. Your acoount is Block.');", true);
                    //    }

                    //}
                }
            }
        }

        protected void btnSecondTechnique_Click(object sender, EventArgs e)
        {

        }

        protected void btnFirstTechnique_Click1(object sender, EventArgs e)
        {
            Response.Redirect("FirstTechOP.aspx");
            int productid = Convert.ToInt32(Session["pid"]);
        }

        protected void btnSecondTechnique_Click1(object sender, EventArgs e)
        {
            int productid = Convert.ToInt32(Session["pid"]);
            Response.Redirect("SecondTechOP.aspx");
        }

        protected void btnCompare_Click(object sender, EventArgs e)
        {
            int productid = Convert.ToInt32(Session["pid"]);
            Response.Redirect("CompareGraph.aspx");
        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

    }
}