using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GPPlatform.DB;
using GPLib.DAL;

namespace GPPlatform.FGService
{
    public class UserManager
    {
        public static List<dynamic> GetUserList()
        {
            return DBContext.GetContext().UserSessionSet.OrderByDescending(x => x.Status)
                .Select(x => new
                {
                    Id = x.UserInfoSet.Id,
                    Name = x.UserInfoSet.NickName,
                    Status = x.Status
                }).ToList<dynamic>();
        }
        public static List<dynamic> GetUserList(string wid)
        {
            return DBContext.GetContext().UserSessionSet.Where(x => x.UserInfoSet.Id != wid).OrderByDescending(x => x.Status)
                .Select(x => new
                {
                    Id = x.UserInfoSet.Id,
                    Name = x.UserInfoSet.NickName,
                    Status = x.Status
                }).ToList<dynamic>();
        }
        /// <summary>
        /// 根据wid处理
        /// </summary>
        /// <param name="userInfo"></param>
        public static bool LoginIn(string wid)
        {
            var context = DBContext.GetContext();
            var userInfo = context.UserInfoSet.FirstOrDefault(x => x.WId == wid);
            if (userInfo == null)
            {
                return false;
            }
            var userSessionInfo = context.UserSessionSet.FirstOrDefault(x => x.UserInfoSet.WId == wid);
            if (userSessionInfo == null)
            {
                context.UserSessionSet.Add(new UserSessionSet()
                {
                    LoginTime = DateTime.Now,
                    Status = 1,
                    UserInfoSet = userInfo,
                    Id = Guid.NewGuid().ToString()
                });
            }
            else
            {
                userSessionInfo.LoginTime = DateTime.Now;
                userSessionInfo.Status = 1;
            }
            userInfo.LastLoginTime = DateTime.Now;
            context.SaveChanges();
            return true;
        }
        /// <summary>
        /// 根据wid处理
        /// </summary>
        /// <param name="userInfo"></param>
        public static bool LoginIn(string wid, string connectionId)
        {
            var context = DBContext.GetContext();
            var userInfo = context.UserInfoSet.FirstOrDefault(x => x.WId == wid);
            if (userInfo == null)
            {
                return false;
            }
            var userSessionInfo = context.UserSessionSet.FirstOrDefault(x => x.UserInfoSet.WId == wid);
            if (userSessionInfo == null)
            {
                context.UserSessionSet.Add(new UserSessionSet()
                {
                    LoginTime = DateTime.Now,
                    Status = 1,
                    UserInfoSet = userInfo,
                    Id = connectionId
                });
            }
            else
            {
                userSessionInfo.LoginTime = DateTime.Now;
                userSessionInfo.Status = 1;
            }
            userInfo.LastLoginTime = DateTime.Now;
            context.SaveChanges();
            return true;
        }

        public static void LoginOutBySessionId(string id)
        {
            var context = DBContext.GetContext();
            var userSessionInfo = context.UserSessionSet.FirstOrDefault(x => x.Id == id);
            if (userSessionInfo != null)
            {
                context.UserSessionSet.Remove(userSessionInfo);

                context.SaveChanges();
            }
        }
        public static void LoginOut(string wid)
        {
            var context = DBContext.GetContext();
            var userSessionInfo = context.UserSessionSet.FirstOrDefault(x => x.UserInfoSet.WId == wid);
            if (userSessionInfo != null)
            {
                context.UserSessionSet.Remove(userSessionInfo);

                context.SaveChanges();
            }
        }
        public static bool CheckFirstLogin(string wid)
        {
            var contenxt = DBContext.GetContext();
            return !contenxt.UserInfoSet.Any(x => x.WId == wid);
        }

        public static void Resigster(string wid, string name)
        {
            var context = DBContext.GetContext();
            var info = new UserInfoSet()
            {
                CreateTime = DateTime.Now,
                WId = wid,
                Name = name,
                NickName = name,
                Id = Guid.NewGuid().ToString()

                //,UserSession = new UserSession { Id = "000" }
            };
            context.UserInfoSet.Add(info);
            context.SaveChanges();
        }

        public static void ResigsterCustom(string name, string pwd)
        {
            var context = DBContext.GetContext();
            var info = new UserInfoSet()
            {
                CreateTime = DateTime.Now,
                Pwd = pwd,
                Name = name,
                NickName = name,
                Id = Guid.NewGuid().ToString()
                 ,
                WId = "",
                LastLoginTime = DateTime.Now,
                DefaultStageId = ""
                //,UserSession = new UserSession { Id = "000" }
            };
            context.UserInfoSet.Add(info);
            context.SaveChanges();
        }
    }
}