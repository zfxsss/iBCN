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
    public interface IMsgEntity : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        bool HasDirectEvtDataProperty { get; }

        /// <summary>
        /// 
        /// </summary>
        string EvtDataPropertyName { get; }

        /// <summary>
        /// 
        /// </summary>
        [Obsolete]
        string EntityName { get; }
    }
}
