using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.ConfigRepository
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigRepo
    {
        /// <summary>
        /// 
        /// </summary>
        private static JObject _content = null;

        /// <summary>
        /// 
        /// </summary>
        public static JObject GetContent(string path)
        {
            try
            {
                if (_content == null)
                {
                    _content = JObject.Parse(File.ReadAllText(path));
                }

                return _content;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Exception raised in the configuration file loading process", ex);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        public static void Clear()
        {
            _content = null;
        }
    }
}
