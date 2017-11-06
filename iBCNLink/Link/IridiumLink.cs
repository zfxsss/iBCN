using iBCNLinkLayer.Link.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.Link
{
    class IridiumLink : iBCNLink, ILink
    {
        /// <summary>
        /// 
        /// </summary>
        public override void OnReceiving(byte[] bytes)
        {
            base.OnReceiving(bytes);
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnSending(byte[] bytes)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public override void Open(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Close()
        {
            throw new NotImplementedException();
        }
    }
}
