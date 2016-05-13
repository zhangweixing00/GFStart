using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBaseLib
{
    [Serializable]
    public class Plane
    {
        public Block Header { set; get; }
        public PlaneOrientation Orientation { set; get; }

        public bool IsGuessed { get; set; }

        private int blockLength;

        public int BlockLength
        {
            get
            {
                if (blockLength == 0)
                {//未初始化
                    return Header.Length;
                }
                return blockLength;
            }
            set { blockLength = value; }
        }

        public List<Block> GetBodyFast()
        {
            List<Block> bodys = new List<Block>();
            //1,5,1,3

            //先创建nomal
            //5
            bodys.Add(new Block()
            {
                X = Header.X,
                Y = Header.Y + BlockLength
            });
            bodys.Add(new Block()
            {
                X = Header.X - BlockLength,
                Y = Header.Y + BlockLength
            });
            bodys.Add(new Block()
            {
                X = Header.X - BlockLength * 2,
                Y = Header.Y + BlockLength
            });
            bodys.Add(new Block()
            {
                X = Header.X + BlockLength,
                Y = Header.Y + BlockLength
            });
            bodys.Add(new Block()
            {
                X = Header.X + BlockLength * 2,
                Y = Header.Y + BlockLength
            });
            //1
            bodys.Add(new Block()
            {
                X = Header.X,
                Y = Header.Y + BlockLength * 2
            });
            //3
            bodys.Add(new Block()
            {
                X = Header.X,
                Y = Header.Y + BlockLength * 3
            });
            bodys.Add(new Block()
            {
                X = Header.X - BlockLength,
                Y = Header.Y + BlockLength * 3
            });
            bodys.Add(new Block()
            {
                X = Header.X + BlockLength,
                Y = Header.Y + BlockLength * 3
            });


            switch (Orientation)
            {
                case PlaneOrientation.Normal:
                    //直接返回
                    break;
                case PlaneOrientation.Back:
                    foreach (var item in bodys)
                    {
                        item.Y = 2 * Header.Y - item.Y;
                    }
                    break;
                case PlaneOrientation.Right:
                    foreach (var item in bodys)
                    {
                        int tmp = item.X - Header.X + Header.Y;
                        item.X = item.Y - Header.Y + Header.X;
                        item.Y = tmp;
                    }
                    break;
                case PlaneOrientation.Left:
                    foreach (var item in bodys)
                    {
                        item.Y = 2 * Header.Y - item.Y;

                        int tmp = item.X;
                        item.X = item.Y;
                        item.Y = tmp;
                    }

                    break;

                default:
                    break;
            }

            return bodys;
        }


        [Obsolete("未完全实现", true)]
        public List<Block> GetBody()
        {
            List<Block> bodys = new List<Block>();
            //1,5,1,3
            switch (Orientation)
            {
                case PlaneOrientation.Normal:

                    //5
                    bodys.Add(new Block()
                    {
                        X = Header.X,
                        Y = Header.Y + BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength,
                        Y = Header.Y + BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength * 2,
                        Y = Header.Y + BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength,
                        Y = Header.Y + BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength * 2,
                        Y = Header.Y + BlockLength
                    });
                    //1
                    bodys.Add(new Block()
                    {
                        X = Header.X,
                        Y = Header.Y + BlockLength * 2
                    });
                    //3
                    bodys.Add(new Block()
                    {
                        X = Header.X,
                        Y = Header.Y + BlockLength * 3
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength,
                        Y = Header.Y + BlockLength * 3
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength,
                        Y = Header.Y + BlockLength * 3
                    });
                    break;
                case PlaneOrientation.Back:
                    bodys.Add(new Block()
                    {
                        X = Header.X,
                        Y = Header.Y - BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength,
                        Y = Header.Y - BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength * 2,
                        Y = Header.Y - BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength,
                        Y = Header.Y - BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength * 2,
                        Y = Header.Y - BlockLength
                    });
                    //1
                    bodys.Add(new Block()
                    {
                        X = Header.X,
                        Y = Header.Y - BlockLength * 2
                    });
                    //3
                    bodys.Add(new Block()
                    {
                        X = Header.X,
                        Y = Header.Y - BlockLength * 3
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength,
                        Y = Header.Y - BlockLength * 3
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength,
                        Y = Header.Y - BlockLength * 3
                    });
                    break;
                case PlaneOrientation.Left:
                    //5
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength,
                        Y = Header.Y
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength,
                        Y = Header.Y - BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength * 2,
                        Y = Header.Y - BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength,
                        Y = Header.Y - BlockLength
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength * 2,
                        Y = Header.Y - BlockLength
                    });
                    //1
                    bodys.Add(new Block()
                    {
                        X = Header.X,
                        Y = Header.Y - BlockLength * 2
                    });
                    //3
                    bodys.Add(new Block()
                    {
                        X = Header.X,
                        Y = Header.Y - BlockLength * 3
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X - BlockLength,
                        Y = Header.Y - BlockLength * 3
                    });
                    bodys.Add(new Block()
                    {
                        X = Header.X + BlockLength,
                        Y = Header.Y - BlockLength * 3
                    });
                    break;
                case PlaneOrientation.Right:
                    break;
                default:
                    break;
            }

            return bodys;
        }




    }
}
