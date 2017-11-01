﻿using Metocean.iBCN.Message.Entity.Interface;
using Metocean.iBCN.Message.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class Acknowledgement : BaseMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Ack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Acknowledgement() : base()
        {

        }
    }
}
