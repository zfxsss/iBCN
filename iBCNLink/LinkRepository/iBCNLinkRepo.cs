using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using iBCNLinkLayer.Link;
using iBCNLinkLayer.Link.Interface;

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
        private const int MaxSize = 1024;

        /// <summary>
        /// 
        /// </summary>
        private ConcurrentDictionary<LinkDescription, ILink> _linkDictionary = new ConcurrentDictionary<LinkDescription, ILink>(5, MaxSize);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="linkDescription"></param>
        /// <returns></returns>
        public ILink this[LinkDescription linkDescription]
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
            ILink removed;
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
