using Metocean.iBCNLinkLayer.Link.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCNLinkLayer.Link
{
    public class IridiumLink : iBCNLink, ILink
    {
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
