using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GPLib.DAL;

namespace GPPlatform.Core
{
    public class BasePage : System.Web.UI.Page
    {
        protected GPEntities dbContext = DB.DBContext.GetContext();
        public BasePage()
        {
            Js = new MessageBox(this);
        }
        protected MessageBox Js;

        public GPLib.DAL.UserInfoSet UserInfo
        {
            get
            {
                string sessionName = "UserInfo";
                if (Session[sessionName] == null)
                {
                   // Response.Clear();
                   // Server.Transfer("Login.aspx");
                    //Response.Redirect("Login.aspx");
                    return null;
                }
                else
                {
                    return Session[sessionName] as GPLib.DAL.UserInfoSet;
                }
            }
        }
    }
}