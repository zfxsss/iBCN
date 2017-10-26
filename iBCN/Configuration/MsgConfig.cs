using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Configuration
{
    public class MsgConfig : IConfigReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public object GetConfigItem(string itemName)
        {
            //to be implemented
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasDirectEvtDataProperty { get; }

        /// <summary>
        /// 
        /// </summary>
        public string EvtDataPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        public MsgConfig()
        {

        }

    }
}
