﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class ReceiveIridiumMessage : iBCNMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public byte[] Msg { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            Msg = entityData;
        }
    }
}
