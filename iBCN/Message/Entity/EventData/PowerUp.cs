using Metocean.iBCN.Message.Entity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.EventData
{
    /// <summary>
    /// 
    /// </summary>
    public class PowerUp : PropertyAccessor, IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public byte ResetReason { get; set; }
    }
}
