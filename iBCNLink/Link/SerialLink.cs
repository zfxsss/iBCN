using iBCNLinkLayer.Link.Interface;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNLinkLayer.Link
{
    /// <summary>
    /// 
    /// </summary>
    public class SerialLink : iBCNLink, ILink
    {
        /// <summary>
        /// 
        /// </summary>
        private SerialPort serialPort;

        /// <summary>
        /// 
        /// </summary>
        public override void OnReceiving(byte[] bytes)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnSending(byte[] bytes)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public override void Open(string name, bool supportQueue)
        {
            if(serialPort == null)
            {

            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Close()
        {
            throw new NotImplementedException();
        }


    }
}
