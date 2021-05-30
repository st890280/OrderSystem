using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OrderSystem
{
    public partial class Login : System.Web.UI.Page
    {
        private string _goToStudent = "Students/StudentMainPage.aspx";

        private const string _sessionKey = "IsLogined";
        private const string _sessionKey_Account = "Account";
        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                Session.RemoveAll();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (LoginHelper.HasLogined())
            {
                this.PlaceHolder1.Visible = false;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string acc = this.txtAccount.Text;
            string pwd = this.txtPassword.Text;
            bool isSuccess = LoginHelper.TryLogin(acc, pwd);
            if (isSuccess)
            {
                this.lbMessage.Text = "Success";
                this.PlaceHolder1.Visible = false;

                //將帳號存入Session
                Session["Account"] = txtAccount.Text;
                Session["IsLogined"] = true;
                Session["AccSid"] = DBHelper.GetUserAccount(txtAccount.Text).Rows[0]["AccSid"];
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                this.lbMessage.Text = "帳號或密碼錯誤，請重新輸入!";
                this.PlaceHolder1.Visible = true;
            }
        }
    }
}