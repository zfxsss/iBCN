﻿using Metocean.iBCN.Message.Interface.Parser;
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
    public abstract class iBCNMessage : IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual void FromBytes(byte[] entityData)
        {
            //throw new NotImplementedException("");
        }
    }
}
