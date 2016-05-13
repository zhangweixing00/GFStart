using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace GPPlatform.Core
{
    public class MessageBox
    {
        Page page;
        public MessageBox(Page page)
        {
            this.page = page;
        }
        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="page">WebPage对象</param>
        /// <param name="message">提示消息的内容</param>
        public void Show(string message)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(),
                  Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 12),
                string.Format("alert('{0}');", message), true);
        }

        /// <summary>
        /// 弹出提示信息
        /// </summary>
        /// <param name="page">WebPage对象</param>
        /// <param name="message">提示消息的内容</param>
        public void Show(string message, string redirectUrl)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(),
                  Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(0, 12),
                 string.Format("alert('{0}');", message) + string.Format("window.location.href='{0}';</script>", redirectUrl), true);
        }



        public string CreateClientScript(string message)
        {
            return string.Format("alert('{0}');", message);
        }

        public string CreateClientScript(string message, string redirectUrl)
        {
            return  string.Format("alert('{0}');", message) + string.Format("window.location.href='{0}';</script>", redirectUrl);
        }
    }
}