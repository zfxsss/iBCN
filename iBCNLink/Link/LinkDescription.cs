using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.Link
{
    /// <summary>
    /// 
    /// </summary>
    public class LinkDescription : IEquatable<LinkDescription>
    {
        /// <summary>
        /// 
        /// </summary>
        public LinkType LType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LinkName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(LinkDescription other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if ((LType == other.LType) && (LinkName == other.LinkName))
            {
                return true;
            }

            return false;
        }
    }
}
