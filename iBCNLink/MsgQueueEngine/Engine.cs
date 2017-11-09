using iBCNLinkLayer.Link;
using iBCNLinkLayer.Link.Interface;
using iBCNLinkLayer.LinkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.MsgQueueEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// 
        /// </summary>
        private static iBCNLinkRepo linkRepo = new iBCNLinkRepo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkDescription"></param>
        /// <returns></returns>
        internal ILink BuildOrGetLink(LinkDescription linkDescription)
        {
            return linkRepo[linkDescription];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkDescription"></param>
        internal void RemoveLink(LinkDescription linkDescription)
        {
            linkRepo.RemoveItem(linkDescription);
        }


    }
}
