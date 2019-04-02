using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class WebForm6 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //var posdata = "";
            //var negdata = "";
            //string name = "";
            //string review = "";
            if (!IsPostBack)
            {
                int productid = Convert.ToInt32(Session["pid"]);
                //int productId = Convert.ToInt32(Request.QueryString["productId"]);
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {


                    var Data = (from rm in dbContext.ReviewMasters
                                join um in dbContext.UserMasters on rm.userId equals um.userId
                                where (rm.productId == productid)
                                select new ReviewHelper { ReviewId = rm.reviewId, UserId = rm.userId, UserName = um.name, Review = rm.review, Date = rm.addedDate, Rating = rm.rating, Score = rm.score }).Average(a => a.Score);

                    List<ReviewHelper> ReviewData = (from rm in dbContext.ReviewMasters
                                                     join um in dbContext.UserMasters on rm.userId equals um.userId
                                                     where (rm.productId == productid)
                                                     select new ReviewHelper { ReviewId = rm.reviewId, UserId = rm.userId, UserName = um.name, Review = rm.review, Date = rm.addedDate, Rating = rm.rating, Score = rm.score }).ToList();

                    int index = 0;
                    if (Data > 0)
                    {
                        foreach (var item in ReviewData)
                        {
                            if (item.Score > 0)
                            {
                                ReviewData[index].Prediction = "Positive Review";
                            }
                            if (item.Score < 0)
                            {
                                ReviewData[index].Prediction = "Fake Review";
                            }
                            index++;
                        }
                    }
                    if (Data < 0)
                    {
                        foreach (var item in ReviewData)
                        {
                            if (item.Score > 0)
                            {
                                ReviewData[index].Prediction = "Fake Review";
                            }
                            if (item.Score < 0)
                            {
                                ReviewData[index].Prediction = "Positive Review";
                            }
                            index++;
                        }
                    }

                    Repeater1.DataSource = ReviewData;
                    Repeater1.DataBind();

                }
            }
        }
    }
}