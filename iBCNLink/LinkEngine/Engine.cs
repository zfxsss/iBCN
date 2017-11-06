using iBCNLinkLayer.Link;
using iBCNLinkLayer.LinkRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.LinkEngine
{
    /// <summary>
    /// 
    /// </summary>
    public class Engine
    {
        /// <summary>
        /// 
        /// </summary>
        public static iBCNLinkRepo Repo { get; } = new iBCNLinkRepo();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkDescription"></param>
        /// <returns></returns>
        internal iBCNLink BuildOrGetLink(LinkDescription linkDescription)
        {
            return Repo[linkDescription];
        }


    }
}
