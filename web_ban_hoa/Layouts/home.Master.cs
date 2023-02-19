using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_ban_hoa.layouts
{
    public partial class home : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
        }

        protected void ibtnCart_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("/Pages/cart_page.aspx");
        }
    }
}