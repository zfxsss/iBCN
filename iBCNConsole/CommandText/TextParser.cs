using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iBCNConsole.CommandText
{
    /// <summary>
    /// 
    /// </summary>
    public class TextParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string[] GetSplittedStringArray(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                return new string[] { };
            }

            return txt.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }

    }
}
