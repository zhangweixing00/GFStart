using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GPLib.DAL;

namespace GPPlatform.FGService
{
    public class FightService
    {
        GPLib.DAL.GPEntities DBContext = new GPLib.DAL.GPEntities();

        public List<FightInfo> StageList
        {
            get
            {
                return FGService.GlobalResource.GetFightList();
            }
        }
        public bool CreateFight(List<string> users)
        {
            string fId = Guid.NewGuid().ToString();
            var fInfo = new GPLib.DAL.FightInfo()
            {
                Id = fId,
                StartTime = DateTime.Now,
                Status = 1,
                WinnerId = "",
                FightDetail = new List<FightDetail>()
            };
            foreach (var item in users)
            {
                fInfo.FightDetail.Add(new GPLib.DAL.FightDetail()
                {
                    Status = 1,
                    BodyCount = 0,
                    HeadCount = 0,
                    FightId = fId,
                    PartTime = DateTime.Now,
                    UserId = item,
                    StageId = GetUserStageId(users, item)
                });
            }
            StageList.Add(fInfo);

            new Task(() =>
            {
                DBContext.FightInfo.Add(fInfo);
                DBContext.FightDetail.AddRange(fInfo.FightDetail);
            });

            return true;
        }

        private string GetUserStageId(List<string> users, string item)
        {
            string otherSide = users.Except(new List<string> { item }).FirstOrDefault();
            var defaultStage = DBContext.DefaultStage.FirstOrDefault(x => x.Uid == item);
            if (defaultStage == null)
            {
                throw new Exception("没有设置默认dt");
            }
            return defaultStage.StageId.Value.ToString();
        }
    }
}