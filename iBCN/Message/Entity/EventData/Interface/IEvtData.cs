using Metocean.iBCN.Interface.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData.Interface
{
    public interface IEvtData : IEntity
    {
        int EventCode { get; }
    }
}
