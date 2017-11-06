using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using iBCNLinkLayer.Link;

namespace iBCNLinkLayer.LinkRepository
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class iBCNLinkRepo
    {
        /// <summary>
        /// 
        /// </summary>
        private ConcurrentDictionary<LinkDescription, iBCNLink> _linkDictionary = new ConcurrentDictionary<LinkDescription, iBCNLink>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkDescription"></param>
        /// <returns></returns>
        public iBCNLink this[LinkDescription linkDescription]
        {
            get
            {
                if (!_linkDictionary.ContainsKey(linkDescription))
                {
                    try
                    {
                        if (!_linkDictionary.TryAdd(linkDescription, null))
                        {
                            throw new Exception("");
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                return _linkDictionary[linkDescription];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkDescription"></param>
        public void RemoveItem(LinkDescription linkDescription)
        {
            iBCNLink removed;
            try
            {
                if (!_linkDictionary.TryRemove(linkDescription, out removed))
                {
                    throw new Exception("");
                }
                removed.Close();
            }
            catch (Exception)
            {

            }
        }

    }
}
