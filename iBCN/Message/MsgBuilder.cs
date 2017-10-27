using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message
{
    class MsgBuilder
    {
        internal static T BuildMsg<T>(byte[] data) where T : new()
        {
            var msg = new T();
            var msgName = typeof(T).Name;
            return default(T);
        }
    }
}
