using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillddlProduct();
                //fillddlSite();
                if (Request.QueryString["action"] == "edit")
                {
                    int reviewId = Convert.ToInt32(Request.QueryString["reviewId"]);
                    using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                    {
                        var data = dbContext.ReviewMasters.Where(x => x.reviewId == reviewId).SingleOrDefault();
                        if (data != null)
                        {
                            ddlProduct.SelectedValue = data.productId.ToString();
                            //ddlSite.SelectedValue = data.siteId.ToString();
                            txtReview.Text = data.review;
                            Rating1.CurrentRating = Convert.ToInt32(data.rating);
                        }
                    }
                }
            }
        }

        //private void fillddlSite()
        //{
        //    using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
        //    {
        //        var data = dbContext.SiteMasters.ToList();
        //        ddlSite.DataSource = data;
        //        ddlSite.DataBind();
        //        ddlSite.Items.Insert(0, new ListItem("<-Select Site->", ""));
        //    }
        //}

        private void fillddlProduct()
        {
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var data = dbContext.ProductMasters.ToList();
                ddlProduct.DataSource = data;
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("<-Select Product->", ""));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["action"] == "edit")
            {
                int reviewId = Convert.ToInt32(Request.QueryString["reviewId"]);
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    var data = dbContext.ReviewMasters.Where(x => x.reviewId == reviewId).SingleOrDefault();
                    if (data != null)
                    {
                        data.productId = Convert.ToInt32(ddlProduct.SelectedValue);
                        //data.siteId = Convert.ToInt32(ddlSite.SelectedValue);
                        data.review = txtReview.Text;
                        data.rating = Rating1.CurrentRating;
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Update successfully');window.location='ManageReview.aspx';", true);
                    }
                }
            }
            else
            {
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    double score = PosFile.postagger(PosFile.TraggerMain(txtReview.Text));
                    ReviewMaster review = new ReviewMaster
                    {
                        productId = Convert.ToInt32(ddlProduct.SelectedValue),
                        //siteId = Convert.ToInt32(ddlSite.SelectedValue),
                        review = txtReview.Text,
                        rating = Rating1.CurrentRating,
                        score = score,
                        reviewTypeId = 1
                    };
                    dbContext.ReviewMasters.Add(review);
                    dbContext.SaveChanges();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Insert Successfully');window.location='ManageReview.aspx';", true);
                }
            }
        }
    }
}