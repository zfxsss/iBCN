using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfigReader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        object GetConfigItem(string configItemPath);
    }
}
