using Metocean.iBCN.Message.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.MsgQueue
{
    /// <summary>
    /// 
    /// </summary>
    public class QueueItem
    {
        /// <summary>
        /// 
        /// </summary>
        public Action<byte[]> ItemAction { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public byte[] Message { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="itemAction"></param>
        public QueueItem(byte[] message, Action<byte[]> itemAction)
        {
            ItemAction = itemAction;
            Message = message;
        }
    }
}
