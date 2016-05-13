using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GPPlatform.FGService;

namespace GPPlatform.Services
{
    public partial class UserInteface : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public string GetWid()
        {
            string wid = Guid.NewGuid().ToString();
            string name = GetRandomName();
            UserManager.Resigster(wid, name);
            return wid;
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