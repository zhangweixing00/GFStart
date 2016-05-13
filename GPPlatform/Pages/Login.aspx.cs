using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPPlatform.Core;
using GPPlatform.FGService;

namespace GPPlatform.Pages
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserInfo!=null)
            {

            }
        }

        public int CreateUser(string name, string pwd)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                return 1;
            }
            if (dbContext.UserInfoSet.Any(x => x.Name == name))
                return 2;
            UserManager.ResigsterCustom(name, pwd);
            return 3;
        }

        public bool LoginUser(string name, string pwd)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pwd))
            {
                return false;
            }
            var userInfo = dbContext.UserInfoSet.FirstOrDefault(x => x.Name == name && x.Pwd == pwd);
            if (userInfo == null)
            {
                return false;
            }
            string sessionName = "UserInfo";
            Session[sessionName] = userInfo;
            return true;
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            int result = CreateUser(tbName.Value, tbPwd.Value);
            switch (result)
            {
                case 1:
                    Js.Show("请输入完整信息！");
                    break;
                case 2:
                    Js.Show("已存在相同的账号！");
                    break;
                case 3:
                    Js.Show("创建成功！", "/pages/EntryPoint.aspx");
                    LoginUser(tbName.Value, tbPwd.Value);
                    break;
                default:
                    break;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (LoginUser(tbName.Value, tbPwd.Value))
            {
                Js.Show("登录成功！", "/pages/EntryPoint.aspx");
            }
            else
            {
                Js.Show("登录失败！");
            }
        }
    }
}