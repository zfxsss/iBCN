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
    public class Mode : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public UInt32 Reserved1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 FixInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 Reserved2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 MailboxCheckInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte SurfacingSetting { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 TransmitIntervalFlags { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt16 TransmitInterval { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
        }
    }
}
