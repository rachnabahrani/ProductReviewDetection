using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public static int rowIndex = 0;
        public static List<ReviewMaster> objReview = new List<ReviewMaster>();
        public static double objUserScore = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
                int userId = Convert.ToInt32(Session["userid"]);
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    objReview = dbContext.ReviewMasters.OrderBy(x => Guid.NewGuid()).Where(x => x.productId == productId).Take(5).ToList();
                    objUserScore = (double)dbContext.UserMasters.Where(x => x.userId == userId).Select(x => x.score).SingleOrDefault();
                }
                lblReview.Text = objReview[rowIndex].review;
            }
            if (rowIndex == 5)
            {
                btnLike.Text = "Finish";
            }
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {

            if (rowIndex <= 4)
            {
                if ((0 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 1.5) || (-1.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 0))
                {
                    objUserScore += 0.25;
                }
                else if ((1.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 2.5) || (-2.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= -1.5))
                {
                    objUserScore += 0.5;
                }
                else if ((2.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 3.5) || (-3.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= -2.5))
                {
                    objUserScore += 0.75;
                }
                else if ((3.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 5) || (-5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= -3.5))
                {
                    objUserScore += 1;
                }
                rowIndex++;
                if (rowIndex <= 4)
                    lblReview.Text = objReview[rowIndex].review;
            }
            else
            {
                if (objUserScore > 0)
                {
                    UpdateScore();
                }
                else
                {
                    BlockUser();
                }
            }
        }

        protected void btnDislike_Click(object sender, EventArgs e)
        {
            if (rowIndex <= 4)
            {
                if ((0 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 1.5) || (-1.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 0))
                {
                    objUserScore -= 0.25;
                }
                else if ((1.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 2.5) || (-2.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= -1.5))
                {
                    objUserScore -= 0.5;
                }
                else if ((2.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 3.5) || (-3.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= -2.5))
                {
                    objUserScore -= 0.75;
                }
                else if ((3.5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= 5) || (-5 > Convert.ToDouble(objReview[rowIndex].score) && Convert.ToDouble(objReview[rowIndex].score) <= -3.5))
                {
                    objUserScore -= 1;
                }
                rowIndex++;
                if (rowIndex <= 4)
                    lblReview.Text = objReview[rowIndex].review;
            }
            else
            {
                if (objUserScore > 0)
                {
                    UpdateScore();
                }
                else
                {
                    BlockUser();
                }
            }
        }

        private void UpdateScore()
        {
            int userId = Convert.ToInt32(Session["userid"]);
            int productId = Convert.ToInt32(Request.QueryString["ProductId"]);
            double score = Convert.ToDouble(Session["score"]);
            int rating = Convert.ToInt32(Session["Rating"]);
            string Proreview = Session["Review"].ToString();
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var user = dbContext.UserMasters.Where(x => x.userId == userId).SingleOrDefault();
                if (user != null)
                {
                    user.score = objUserScore;
                    dbContext.SaveChanges();
                }

                ReviewMaster review = new ReviewMaster
                {
                    productId = productId,
                    reviewTypeId = 2,
                    userId = userId,
                    rating = rating,
                    review = Proreview,
                    score = score
                };
                dbContext.ReviewMasters.Add(review);
                dbContext.SaveChanges();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Your review submit successfully');window.location='index.aspx';", true);
            }
        }

        private void BlockUser()
        {
            int userId = Convert.ToInt32(Session["userid"]);

            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var user = dbContext.UserMasters.Where(x => x.userId == userId).SingleOrDefault();
                if (user != null)
                {
                    user.status = false;
                    user.score = objUserScore;
                    dbContext.SaveChanges();
                    Session.Abandon();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Your Review is not trustwordhy. Your acoount is Block.');window.location='index.aspx';", true);
                }
            }
        }
    }
}