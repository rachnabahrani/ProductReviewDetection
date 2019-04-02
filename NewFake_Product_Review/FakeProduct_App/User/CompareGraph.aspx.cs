using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.User
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                fillchart();
            }
        }

        private void fillchart()
        {
            int FirstOp;
            int SecondOp;
            int productid = Convert.ToInt32(Session["pid"]);
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                List<FinalGraphModel> objData = new List<FinalGraphModel>();
                var FirstOpdata = (from rm in dbContext.ReviewMasters
                                   join um in dbContext.UserMasters on rm.userId equals um.userId
                                   where ((rm.productId == productid) && (rm.score > 0 && rm.rating < 2 || rm.rating > 2 && rm.score < 0))
                                   select new { ReviewId = rm.reviewId, UserId = rm.userId, UserName = um.name, Review = rm.review, Date = rm.addedDate, Rating = rm.rating, Score = rm.score }).Count();

                FirstOp = FirstOpdata;

                objData.Add(new FinalGraphModel { Name = "First Technique", Count = FirstOp });

                //lbl1st.Text = FirstOp.ToString();
                var SecondOpData = (from rm in dbContext.ReviewMasters
                                    join um in dbContext.UserMasters on rm.userId equals um.userId
                                    where (rm.productId == productid)
                                    select new { ReviewId = rm.reviewId, UserId = rm.userId, UserName = um.name, Review = rm.review, Date = rm.addedDate, Rating = rm.rating, Score = rm.score }).Average(a => a.Score);


                if (SecondOpData > 0)
                {
                    var ReviewData = (from rm in dbContext.ReviewMasters
                                      join um in dbContext.UserMasters on rm.userId equals um.userId
                                      where ((rm.productId == productid) && rm.score < 0)
                                      select new { ReviewId = rm.reviewId, UserId = rm.userId, UserName = um.name, Review = rm.review, Date = rm.addedDate, Rating = rm.rating, Score = rm.score }).Count();
                    SecondOp = ReviewData;
                    objData.Add(new FinalGraphModel { Name = "Second Technique", Count = SecondOp });
                    //lbl2nd.Text = ReviewData.ToString();
                }
                if (SecondOpData < 0)
                {
                    var ReviewData2 = (from rm in dbContext.ReviewMasters
                                       join um in dbContext.UserMasters on rm.userId equals um.userId
                                       where ((rm.productId == productid) && rm.score > 0)
                                       select new { ReviewId = rm.reviewId, UserId = rm.userId, UserName = um.name, Review = rm.review, Date = rm.addedDate, Rating = rm.rating, Score = rm.score }).Count();

                    SecondOp = ReviewData2;
                    objData.Add(new FinalGraphModel { Name = "Second Technique", Count = SecondOp });
                    //lbl2nd.Text = SecondOp.ToString();
                }

                Chart1.DataSource = objData;
                Chart1.Series[0].XValueMember = "Name";
                Chart1.Series[0].YValueMembers = "Count";
                Chart1.DataBind();

            }
        }
    }
}



