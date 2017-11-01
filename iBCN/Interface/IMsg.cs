﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMsg
    {
        /// <summary>
        /// 
        /// </summary>
        Type MsgType { get; }

        /// <summary>
        /// 
        /// </summary>
        int CmdType { get; }

        /// <summary>
        /// 
        /// </summary>
        int SubCmdType { get; }

        /// <summary>
        /// 
        /// </summary>
        byte[] MsgBytes { get; }
    }
}
