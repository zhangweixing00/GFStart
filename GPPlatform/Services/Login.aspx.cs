using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPLib.DAL;
using GPPlatform.DB;
using GPPlatform.FGService;

namespace GPPlatform.Services
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = DBContext.GetContext();
            var info = new UserInfoSet()
            {
                CreateTime = DateTime.Now,
                WId = "111",
                Name = "222",
                NickName = "333",
               // Id = "123",
                 LastLoginTime=DateTime.Now
            };
            context.UserInfoSet.Add(info);
            context.SaveChanges();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int index = 0; index < 10; index++)
            {
                string wid = Guid.NewGuid().ToString();
                string name = GetRandomName();
                UserManager.Resigster(wid, name);
                UserManager.LoginIn(wid);
                Thread.Sleep(1000);
                //Response.Write(name+"<br/>");
            }
        }
        Random rand = new Random(DateTime.Now.Millisecond);
        private string GetRandomName()
        {
            int nameLength = rand.Next(4, 8);
            char[] nameArray = new char[nameLength];
            for (int i = 0; i < nameLength; i++)
            {
                nameArray[i] = (char)rand.Next((int)'a', (int)'z');
            }
            return new string(nameArray);
        }
    }
}