using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerLib
{
    public class Group
    {
        public string GroupId { get; set; }
        public int RoomId { get; set; }
        public GroupStatus Status { get; set; }

        /// <summary>
        /// 启动条件个数
        /// </summary>
        public int StartCount { get; set; }

        /// <summary>
        /// 观察个数
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// 当前用户
        /// </summary>
        private List<User> _CurrentUsers;
        public List<User> CurrentUsers
        {
            get
            {
                return _CurrentUsers;
            }
        }

        public Group()
        {
            _CurrentUsers = new List<User>();
            Status = GroupStatus.未开始;
        }

        /// <summary>
        /// 启动一个组
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="startCount"></param>
        public static void CreateGroup(int roomId, int startCount = 2)
        {
            Group newGroup = new Group()
            {
                GroupId = Guid.NewGuid().ToString(),
                StartCount = startCount,
                RoomId = roomId,
                Status = GroupStatus.未开始,
                ViewCount = 5
            };
        }

        public ReturnInfo Join(User user)
        {
            ReturnInfo info = new ReturnInfo();

            if (this.Status != GroupStatus.未开始)
            {
                info.IsSuccess = false;
                info.Des = "不允许加入";
            }

            if (_CurrentUsers.Exists(x => x.UId == user.UId))
            {
                info.IsSuccess = false;
                info.Des = "已加入过";
            }
            else
            {
                _CurrentUsers.Add(user);
                if (_CurrentUsers.Count == StartCount)
                {
                    Task.Factory.StartNew(Start);
                }
            }
            return info;
        }

        private void Start()
        {
            this.Status = GroupStatus.进行中;
            InitStart();
            foreach (var item in _CurrentUsers)
            {
                NotifyUserStart(item);
            }
        }

        protected virtual void NotifyUserStart(User item)
        {
            throw new NotImplementedException();
        }

        protected virtual void InitStart()
        {

        }

        //
        public void Stop()
        {
            foreach (var item in _CurrentUsers)
            {
                NotifyUserStop(item);
            }
            Release();
            this.Status = GroupStatus.结束;
        }

        protected virtual void NotifyUserStop(User item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 释放人员
        /// </summary>
        public void Release()
        {
            foreach (var item in _CurrentUsers)
            {
                item.GroupId = string.Empty;
            }
            _CurrentUsers.Clear();
        }
        

    }
}
