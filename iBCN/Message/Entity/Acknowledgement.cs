using Metocean.iBCN.Message.Entity.Interface;
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
    public class Acknowledgement : BaseMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public bool Ack { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Acknowledgement() : base("Acknowledgement")
        {

        }
    }
}
