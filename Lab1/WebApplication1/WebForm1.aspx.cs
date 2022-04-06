using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> list = new Dictionary<string, string>();
            list.Add("aidar", "123");

            if (list.ContainsKey(TextBox1.Text))
            {
                if (list[TextBox1.Text] == TextBox2.Text)
                {
                    Response.Redirect("WebForm2.aspx");
                }
                else Label1.Text = "Неверный пороль";
            }
            else Label1.Text = "Неверный логин";
        }
    }
}