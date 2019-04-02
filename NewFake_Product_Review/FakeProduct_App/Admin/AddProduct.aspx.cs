using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FakeProduct_App.Admin
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDdlCategory();
                if (Request.QueryString["action"] == "edit")
                {
                    int Id = Convert.ToInt32(Request.QueryString["productId"]);
                    using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                    {
                        var data = dbContext.ProductMasters.Where(a => a.productId == Id).FirstOrDefault();
                        if (data != null)
                        {
                            ddlCategory.SelectedValue = data.categoryId.ToString();
                            txtName.Text = data.name;
                            txtPrice.Text = data.price;
                            Image1.ImageUrl = data.img;
                            txtDescription.Text = data.description;
                        }
                    }
                }
            }
        }

        private void FillDdlCategory()
        {
            using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
            {
                var data = dbContext.CategoryMasters.ToList();
                ddlCategory.DataSource = data;
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("<-Select Category->", ""));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;

            if (Request.QueryString["action"] == "edit")
            {
                int Id = Convert.ToInt32(Request.QueryString["productId"]);
                using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                {
                    var data = dbContext.ProductMasters.Where(a => a.productId == Id).FirstOrDefault();
                    if (data != null)
                    {
                        if (FileUpload1.HasFile)
                        {
                            string filename = Path.GetFileName(FileUpload1.FileName);
                            string ext = Path.GetExtension(filename);
                            string NewName = Guid.NewGuid().ToString() + ext;
                            FileUpload1.SaveAs(Server.MapPath("~/ProductImages/") + NewName);
                            filePath = "/ProductImages/" + NewName;
                        }
                        else
                        {
                            filePath = data.img;
                        }

                        data.categoryId = Convert.ToInt32(ddlCategory.SelectedValue);
                        data.name = txtName.Text;
                        data.price = txtPrice.Text;
                        data.img = filePath;
                        data.description = txtDescription.Text;
                        dbContext.SaveChanges();
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Update successfully');window.location='ManageProduct.aspx';", true);
                    }
                }
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    string filename = Path.GetFileName(FileUpload1.FileName);
                    string ext = Path.GetExtension(filename);
                    string NewName = Guid.NewGuid().ToString() + ext;
                    FileUpload1.SaveAs(Server.MapPath("~/ProductImages/") + NewName);
                    filePath = "/ProductImages/" + NewName;

                    using (FakeProductReviewDbEntities dbContext = new FakeProductReviewDbEntities())
                    {
                        var data = dbContext.ProductMasters.Where(x => x.name == txtName.Text).FirstOrDefault();
                        if (data == null)
                        {
                            data = new ProductMaster
                            {
                                categoryId = Convert.ToInt32(ddlCategory.SelectedValue),
                                name = txtName.Text,
                                img = filePath,
                                price = txtPrice.Text,
                                description=txtDescription.Text
                            };
                            dbContext.ProductMasters.Add(data);
                            dbContext.SaveChanges();
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Product insert successfully');window.location='ManageProduct.aspx';", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Product name already exists')", true);
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "", "alert('Please upload product image')", true);
                }
            }
        }
    }
}