using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using web_ban_hoa.Models;

namespace web_ban_hoa.pages
{
    public partial class home : System.Web.UI.Page
    {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        private void DeleteCacheBrowser()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetNoStore();
        }

        private void LoadCategoryData()
        {
            List<Category> categories = new List<Category>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string categoryQuery = "SELECT Categories.*, Thumbnails.path AS thumbnail_path " +
                                       "FROM Categories " +
                                       "LEFT JOIN Thumbnails ON Categories.id = Thumbnails.category_id ";

                MySqlCommand categoryCommand = new MySqlCommand(categoryQuery, connection);
                connection.Open();
                using (MySqlDataReader categoryReader = categoryCommand.ExecuteReader())
                {
                    while (categoryReader.Read())
                    {
                        Category category = new Category();
                        category.ID = Convert.ToInt32(categoryReader["id"]);
                        category.Name = categoryReader["name"].ToString();
                        category.ThumbnailPath = categoryReader["thumbnail_path"].ToString();
                        categories.Add(category);
                    }
                }

            }

            rptCategories.DataSource = categories;
            rptCategories.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            DeleteCacheBrowser();

            if (!IsPostBack)
            {
                LoadCategoryData();
                LoadProductData();
            }

        }

        private void LoadProductData()
        {
            List<Product> products = new List<Product>();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                string productQuery = "SELECT Products.*, Thumbnails.path AS thumbnail_path " +
                                       "FROM Products " +
                                       "LEFT JOIN Thumbnails ON Products.id = Thumbnails.product_id ";

                MySqlCommand productCommand = new MySqlCommand(productQuery, connection);
                connection.Open();
                using (MySqlDataReader productReader = productCommand.ExecuteReader())
                {
                    while (productReader.Read())
                    {
                        Product product = new Product();
                        product.ID = Convert.ToInt32(productReader["id"]);
                        product.Name = productReader["name"].ToString();
                        product.Description = productReader["description"].ToString();
                        product.OldPrice = Convert.ToDouble(productReader["old_price"]);
                        product.CurrentPrice = Convert.ToDouble(productReader["current_price"]);
                        product.ViewCount = Convert.ToInt32(productReader["view_count"]);
                        product.Quantity = Convert.ToInt32(productReader["quantity"]);
                        product.Sold = Convert.ToInt32(productReader["sold"]);
                        product.CategoryId = Convert.ToInt32(productReader["category_id"]);
                        product.ThumbnailPath = productReader["thumbnail_path"].ToString();

                        if (product.OldPrice == 0)
                        {
                            product.Sale = false;
                        }
                        else
                        {
                            product.Sale = true;
                        }

                        products.Add(product);
                    }
                }

            }

            rptProduct.DataSource = products;
            rptProduct.DataBind();
        }
    }
}