using Metocean.iBCN.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity.Interface
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseMessage : PropertyAccessor, IConfigReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public object GetConfigItem(string configItemPath)
        {
            //to be implemented
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasDirectEvtDataProperty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EvtDataPropertyName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseMessage()
        {

        }
    }
}
