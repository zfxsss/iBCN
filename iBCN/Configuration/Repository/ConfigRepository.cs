using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json.Linq;

namespace Metocean.iBCN.Configuration.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class ConfigRepository
    {
        /// <summary>
        /// 
        /// </summary>
        private static JObject _content = null;

        /// <summary>
        /// 
        /// </summary>
        public static JObject Content
        {
            get
            {
                try
                {
                    if (_content == null)
                    {
                        _content = JObject.Parse(File.ReadAllText("iBCN_Configuration.json"));
                    }
                    return _content;
                }
                catch (Exception ex)
                {
                    //throw new DomainException(ex.Message, PubLib.Log.ExceptionSrc.Init, PubLib.Log.ExceptionType.System, PubLib.Log.LogType.Console);
                    throw new Exception();
                }
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
