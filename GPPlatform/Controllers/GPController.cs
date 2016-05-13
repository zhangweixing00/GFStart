using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using GPBaseLib;
using GPLib.DAL;
using Newtonsoft.Json.Linq;
using System.Web.Routing;

namespace GPPlatform.Controllers
{
    public class GPController : ApiController
    {
        GPLib.DAL.GPEntities DBContext = new GPLib.DAL.GPEntities();
        public List<FightInfo> StageList
        {
            get
            {
                return FGService.GlobalResource.GetFightList();
            }
        }

        /// <summary>
        /// 默认采用httpget
        /// 参数要用data传过来 data: { "userId": id（或直接值） },或者data: { "": userId（变量名必须与参数一致） }
        /// 自定义返回格式，Route不能省略
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("api/gp/GetStageListByUser")]
        public List<Stage> GetStageListByUser(string userId)
        {
            var infos = DBContext.Stage.Where(x => x.CreateUser == userId).OrderByDescending(x => x.CreateTime).ToList();
            infos.ForEach(x => x.StageData = null);
            return infos;
        }


        [Route("api/gp/SaveStage")]
        [HttpPost]
        public bool SaveStage([FromBody]dynamic stage)
        {
            try
            {
                PMap map = new PMap();
                map.RowCount = int.Parse(stage.map.row.ToString());
                map.ColumnCount = int.Parse(stage.map.col.ToString());
                List<dynamic> infos = new List<dynamic>();

                for (int index = 0; index < stage.map.data.Count; index++)
                {
                    infos.Add(new
                    {
                        x = stage.map.data[index].x,
                        y = stage.map.data[index].y,
                        n = stage.map.data[index].n
                    });
                }

                List<dynamic> headerInfos = infos.Where(x => x.n == "headerItem").ToList();
                if (headerInfos.Count != 4)
                {
                    return false;
                }

                foreach (var item in headerInfos)
                {
                    var p = GetPlane(item, infos.ToArray());
                    if (p == null)
                    {
                        return false;
                    }

                    map.Planes.Add(p);
                }
                byte[] mapData = PMap.ToBytes(map);
                DBContext.Stage.Add(new Stage()
                {
                    Name = stage.map.Name,
                    CreateTime = DateTime.Now,
                    StageData = mapData,
                    CreateUser = stage.UserId
                });

                DBContext.SaveChanges(); return true;
            }
            catch (Exception ex)
            {

                return false;
            }

        }



        private Plane GetPlane(dynamic item, dynamic[] infos)
        {
            Plane p = new Plane()
            {
                BlockLength = 1,
                Orientation = PlaneOrientation.Normal,
                Header = new Block()
                {
                    Length = 1,
                    X = item.x,
                    Y = item.y,
                }
            };
            List<dynamic> exsitBodys = infos.ToList().Where(x => x.n == "bodyItem").ToList();
            List<Block> bodyList = p.GetBodyFast();
            if (CheckExsit(exsitBodys, bodyList))
            {
                return p;
            }

            p.Orientation = PlaneOrientation.Back;
            bodyList = p.GetBodyFast();
            if (CheckExsit(exsitBodys, bodyList))
            {
                return p;
            }

            p.Orientation = PlaneOrientation.Left;
            bodyList = p.GetBodyFast();
            if (CheckExsit(exsitBodys, bodyList))
            {
                return p;
            }

            p.Orientation = PlaneOrientation.Right;
            bodyList = p.GetBodyFast();
            if (CheckExsit(exsitBodys, bodyList))
            {
                return p;
            }

            return null;
        }

        private bool CheckExsit(List<dynamic> exsitBodys, List<Block> bodyList)
        {
            foreach (var item in bodyList)
            {
                if (!exsitBodys.Exists(x => x.x == item.X.ToString() && x.y == item.Y))
                {
                    return false;
                }
            }
            return true;
        }
        [HttpGet]
        public bool SaveMap(int id, [FromBody]PMap map)
        {
            var stage = DBContext.Stage.FirstOrDefault(x => x.Id == id);
            if (stage != null)
            {
                stage.StageData = PMap.ToBytes(map);
                DBContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Stage GetStage(int id)
        {
            var stage = DBContext.Stage.FirstOrDefault(x => x.Id == id);
            if (stage != null)
            {
                stage = new GPLib.DAL.Stage();
                stage.Id = -1;
            }
            return stage;
        }

        public PMap GetMap(int id)
        {
            var stage = DBContext.Stage.FirstOrDefault(x => x.Id == id);
            if (stage == null || stage.StageData == null)
            {
                return new PMap();
            }
            return PMap.ToMap(stage.StageData);
        }

        [Route("api/gp/GetStageList")]
        public List<Stage> GetStageList()
        {
            var infos = DBContext.Stage.OrderByDescending(x => x.CreateTime).ToList();
            infos.ForEach(x => x.StageData = null);
            return infos;
        }

        [Route("api/gp/ClickOne")]
        public RetrunInfo ClickOne([FromBody]dynamic stage)
        {
            RetrunInfo retrunInfo = new RetrunInfo();

            int id = int.Parse(stage.Id.ToString());
            var info = DBContext.Stage.FirstOrDefault(x => x.Id == id);
            PMap map = PMap.ToMap(info.StageData);

            retrunInfo.Blocks = new List<RetrunBlockInfo>();
            List<RetrunBlockInfo> infos = retrunInfo.Blocks;
            string clickX = stage.x.ToString();
            string clickY = stage.y.ToString();
            Plane p = map.Planes.FirstOrDefault(x => x.Header.X.ToString() == clickX
              && x.Header.Y.ToString() == clickY);
            if (p != null)
            {
                infos.Add(new RetrunBlockInfo()
                {
                    X = p.Header.X,
                    Y = p.Header.Y,
                    n = "headerItem"
                });
                //List<Block> bodyBlocks = p.GetBodyFast();
                //foreach (var item in bodyBlocks)
                //{
                //    infos.Add(new RetrunBlockInfo()
                //    {
                //        X = item.X,
                //        Y = item.Y,
                //        n = "bodyItem"
                //    });
                //}


                if (stage.headers.Count == 3)
                {
                    retrunInfo.IsFinish = 1;
                }
                else
                {
                    retrunInfo.IsFinish = 2;//header snap
                }

            }
            else
            {
                List<Block> allBodyBlocks = new List<Block>();
                foreach (var plane in map.Planes.ToList())
                {
                    allBodyBlocks.AddRange(plane.GetBodyFast());
                }

                var bodyBlock = allBodyBlocks.FirstOrDefault(i => i.X.ToString() == clickX
                && i.Y.ToString() == clickY);
                if (bodyBlock != null)
                {
                    infos.Add(new RetrunBlockInfo()
                    {
                        X = bodyBlock.X,
                        Y = bodyBlock.Y,
                        n = "bodyItem"
                    });
                    retrunInfo.IsFinish = 3;//
                }
                else
                {
                    infos.Add(new RetrunBlockInfo()
                    {
                        X = int.Parse(clickX),
                        Y = int.Parse(clickY),
                        n = "selectedItem"
                    });
                    retrunInfo.IsFinish = -1;
                    //为-1指不刷新
                }
            }

            return retrunInfo;
        }

        public class RetrunInfo
        {
            public int IsFinish { get; set; }
            public List<RetrunBlockInfo> Blocks { get; set; }

        }
        public class RetrunBlockInfo
        {
            public int X { get; set; }
            public int Y { get; set; }
            public string n { get; set; }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}