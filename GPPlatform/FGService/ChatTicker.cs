using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace GPPlatform.FGService
{
    /// <summary>
    /// 暂没有实现
    /// </summary>
    public class ChatTicker
    {
        #region 实现一个单例  

        private static readonly ChatTicker _instance =
            new ChatTicker(GlobalHost.ConnectionManager.GetHubContext<Hubs.GPHub>());

        private readonly IHubContext m_context;

        private ChatTicker(IHubContext context)
        {
            m_context = context;
            //这里不能直接调用Sender，因为Sender是一个不退出的“死循环”，否则这个构造函数将不会退出。  
            //其他的流程也将不会再执行下去了。所以要采用异步的方式。  
            Task.Run(() => Sender());
        }

        public IHubContext GlobalContext
        {
            get { return m_context; }
        }

        public static ChatTicker Instance
        {
            get { return _instance; }
        }

        #endregion

        public void Sender()
        {
            int count = 0;
            while (true)
            {
                Thread.Sleep(5000);
                var userDatas = UserManager.GetUserList();
                m_context.Clients.All.loadUserList(userDatas);
            }
        }
    }
}