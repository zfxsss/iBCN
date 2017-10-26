using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metocean.iBCN.Interface;
using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.Command.Definition.Interface;

namespace Metocean.iBCN.Command
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Command<T> : ICmd where T : ICmdDefinition
    {
        /// <summary>
        /// 
        /// </summary>
        public Type CmdType
        {
            get
            {
                return typeof(T);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public T CmdDefinition { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdDefinition"></param>
        public Command(T cmdDefinition)
        {
            CmdDefinition = cmdDefinition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdName"></param>
        public Command(string cmdName)
        {

        }

    }
}
