using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GPLib.DAL;

namespace GPPlatform.FGService
{
    public class GlobalResource
    {
        public static List<FightInfo> GetFightList()
        {
            string StageCacheName = "CacheForStageList";
            if (HttpRuntime.Cache[StageCacheName] == null)
            {
                GPLib.DAL.GPEntities DBContext = new GPLib.DAL.GPEntities();
                var fightList = DBContext.FightInfo.ToList();
                HttpRuntime.Cache[StageCacheName] = fightList;
                return fightList;
            }

            return HttpRuntime.Cache[StageCacheName] as List<FightInfo>;
        }

        public static bool SyncToDB()
        {
            new Task(() =>
            {
                string StageCacheName = "CacheForStageList";
                if (HttpRuntime.Cache[StageCacheName] != null)
                {
                    GPLib.DAL.GPEntities DBContext = new GPLib.DAL.GPEntities();
                    var infos = HttpRuntime.Cache[StageCacheName] as List<FightInfo>;
                    foreach (var item in infos)
                    {
                        var dbItem = DBContext.FightInfo.FirstOrDefault(x => x.Id == item.Id);
                        if (dbItem == null)
                        {
                            DBContext.FightInfo.Add(item);
                        }
                        else
                        {
                            dbItem.Status = item.Status;
                            dbItem.WinnerId = item.WinnerId;
                            dbItem.EndTime = item.EndTime;
                        }
                        foreach (var subItem in item.FightDetail)
                        {
                            var dbSubItem = DBContext.FightDetail.FirstOrDefault(x => x.Id == subItem.Id);
                            if (dbSubItem == null)
                            {
                                DBContext.FightDetail.Add(dbSubItem);
                            }
                            else
                            {
                                dbSubItem.Status = subItem.Status;
                                dbSubItem.BodyCount = subItem.BodyCount;
                                dbSubItem.HeadCount = subItem.HeadCount;
                                dbSubItem.ExitTime = subItem.ExitTime;
                            }
                        }
                    }
                }
            });
        }
    }
}