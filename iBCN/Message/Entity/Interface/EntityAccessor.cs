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
    public abstract class EntityAccessor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public virtual Type GetPropertyType(string propertyName)
        {
            return GetType().GetProperty(propertyName).PropertyType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public virtual object this[string propertyName]
        {
            get
            {
                return GetType().GetProperty(propertyName).GetValue(this);
            }
            set
            {
                GetType().GetProperty(propertyName).SetValue(this, value);
            }
        }
    }
}
