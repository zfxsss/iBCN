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
    public class PositionReport : iBCNMessage, IParser
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Timestamp { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte EventCode { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 Latitude { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public UInt32 Longitude { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Speed { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte FixAccuracy { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte TimeToFix { get; private set; }

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
