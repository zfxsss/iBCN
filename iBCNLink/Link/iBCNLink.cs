using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using iBCNLinkLayer.Link.Interface;

namespace iBCNLinkLayer.Link
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class iBCNLink : ILink
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual void OnReceiving(byte[] bytes)
        {
            if (GetType() == typeof(IridiumLink))
            {

            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnSending(byte[] bytes)
        {
            throw new NotImplementedException();
        }

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
