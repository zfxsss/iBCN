﻿using Metocean.iBCN.Message.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEvtData : IParser
    {
        //int EventCode { get; }
        string ToString();
    }
}
