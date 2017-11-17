using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Metocean.iBCNLinkLayer.Link.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILink
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        void Open(string name, bool supportQueue = false);

        /// <summary>
        /// 
        /// </summary>
        void Close();

    }
}
