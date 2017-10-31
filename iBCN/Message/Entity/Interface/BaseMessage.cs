using Metocean.iBCN.Interface.Entity;
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
    public abstract class BaseMessage : PropertyAccessor, IMsgEntity
    {
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
        public string EntityName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BaseMessage(string entityName)
        {
            EntityName = entityName;
            //GetConfigItem(null);
        }
    }
}
