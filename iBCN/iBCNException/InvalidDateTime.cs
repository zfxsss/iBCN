﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.iBCNException
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidDateTime : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public InvalidDateTime(string msg) : base(msg) { }
    }
}
