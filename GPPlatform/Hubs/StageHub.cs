﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GPPlatform.FGService;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace GPPlatform.Hubs
{
    /// <summary>
    /// 用户sessionID即为connectionID
    /// </summary>
    [HubName("stageHub")]
    public class StageHub : Hub
    {
        public string Wid { get; set; }
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            UserManager.LoginOutBySessionId(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            UserManager.LoginOut(Context.ConnectionId);
            UserManager.LoginIn(Wid, Context.ConnectionId);
            return base.OnReconnected();
        }
        [HubMethodName("GetStageListByUser")]
        public void GetStageListByUser(string wid)
        {
            Wid = wid;
            UserManager.LoginIn(wid, Context.ConnectionId);
            var userDatas = UserManager.GetUserList(wid);
            Clients.All.loadUserList(userDatas);
        }
    }
}