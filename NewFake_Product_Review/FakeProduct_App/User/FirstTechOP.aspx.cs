using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var pos = "";
            var neg = "";
            if (!IsPostBack)
            {

                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    //int productid = Convert.ToInt32(Session["productId"]);
                    int productid = Convert.ToInt32(Session["pid"]);
                    List<ReviewHelper> ReviewData = (from rm in dbContext.ReviewMasters
                                                     where (rm.productId == productid)
                                                     join um in dbContext.UserMasters on rm.userId equals um.userId
                                                     select new ReviewHelper { ReviewId = rm.reviewId, UserId = rm.userId, UserName = um.name, Review = rm.review, Date = rm.addedDate, Rating = rm.rating, Score = rm.score }).ToList();
                    if (ReviewData != null)
                    {
                        int index = 0;
                        foreach (var item in ReviewData)
                        {
                            if (item.Rating > 2 && item.Score > 0)
                            {
                                ReviewData[index].Prediction = "Positive Review";
                            }
                            if (item.Score > 0 && item.Rating <= 2)
                            {
                                ReviewData[index].Prediction = "Fake Review";
                            }
                            if (item.Rating > 2 && item.Score < 0)
                            {
                                ReviewData[index].Prediction = "Fake Review";
                            }
                            if (item.Rating <= 2 && item.Score <= 0)
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

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
    }
}