using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Metocean.iBCNLinkLayer.Link.Interface;

namespace Metocean.iBCNLinkLayer.Link
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class iBCNLink : ILink
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public abstract void Open(string name);

        /// <summary>
        /// 
        /// </summary>
        public abstract void Close();

    }
}
