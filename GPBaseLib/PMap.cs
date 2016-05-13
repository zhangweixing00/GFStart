using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPBaseLib
{
    [Serializable]
    public class PMap
    {
        public PMap()
        {
            RowCount = 10;
            ColumnCount = 10;
            Planes = new List<Plane>();
        }
        public int RowCount { get; set; }

        public int ColumnCount { get; set; }

        public List<Plane> Planes { get; set; }

        public virtual dynamic Render(List<Plane> planes)
        {
            return "";
        }

        public static byte[] ToBytes(PMap map)
        {
            byte[] data = null;
            data = Common.SerializeObject(map);
            return data;
        }

        public static PMap ToMap(byte[] data)
        {
            Object obj = Common.DeserializeObject(data);
            if (obj == null || obj is PMap)
            {
                return obj as PMap;
            }
            return null;
        }
    }
}
