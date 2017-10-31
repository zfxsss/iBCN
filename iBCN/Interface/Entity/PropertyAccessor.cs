using Metocean.iBCN.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Interface.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PropertyAccessor : IEntity
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
