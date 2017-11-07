﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace iBCNLinkLayer.Link.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILink
    {
        /// <summary>
        /// 
        /// </summary>
        void OnReceiving(byte[] bytes);

        /// <summary>
        /// 
        /// </summary>
        void OnSending(byte[] bytes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        void Open(string name);

        /// <summary>
        /// 
        /// </summary>
        void Close();

    }
}
