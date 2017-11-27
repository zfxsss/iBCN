using Metocean.iBCN.Command.Definition;
using Metocean.iBCN.Command.Interface;
using Metocean.iBCN.Command.Payload.Interface;
using Metocean.iBCN.Message.Entity;
using Metocean.iBCN.Message.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPropertiesIteration
{
    /// <summary>
    /// 
    /// </summary>
    public class PropertiesIterator
    {
        /// <summary>
        /// 
        /// </summary>
        public static event Action<string, string> CB;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        public static void PrintIteration(object o, int identation = 0, string prefix = "")
        {

            string identationSpace = "";

            for (int i = 0; i < identation * 4; i++)
            {
                identationSpace += " ";
            }

            //null
            if (o == null)
            {
                return;
            }

            //it is a struct(almost)
            if (o.GetType().IsValueType)
            {
                if (o.GetType() == typeof(System.DateTime))
                {
                    CB?.Invoke(prefix, identationSpace + o.ToString());
                }
                else
                {
                    CB?.Invoke(prefix, identationSpace + o.ToString());
                }

                return;
            }

            //it is an array
            if (o.GetType().IsArray)
            {
                if (o.GetType() == typeof(byte[]))
                {
                    var bytes = (byte[])o;
                    string bytesStr = "";

                    foreach (var b in bytes)
                    {
                        bytesStr += b;
                        bytesStr += " ";
                    }

                    CB?.Invoke(prefix, identationSpace + bytesStr);
                    return;
                }
                else
                {
                    foreach (var o2 in (object[])o)
                    {
                        PrintIteration(o2, identation + 2, prefix);
                    }

                    return;
                }
            }

            //it is an IEnumerable
            if (o is IEnumerable)
            {
                if (o is string)
                {
                    CB?.Invoke(prefix, identationSpace + o.ToString());
                    return;
                }

                foreach (var o2 in (IEnumerable)o)
                {
                    PrintIteration(o2, identation + 2, prefix);
                }

                return;
            }

            //it is a normal "object"
            foreach (var p in o.GetType().GetProperties())
            {
                //the property is array
                if (p.PropertyType.IsArray)
                {
                    if (p.GetValue(o) is byte[])
                    {
                        var bytes = (byte[])p.GetValue(o);
                        string bytesStr = "";

                        foreach (var b in bytes)
                        {
                            bytesStr += b;
                            bytesStr += " ";
                        }

                        CB?.Invoke(prefix, identationSpace + p.Name + " : " + bytesStr);
                    }
                    else
                    {
                        CB?.Invoke(prefix, identationSpace + p.Name + " : ");

                        foreach (var o2 in (object[])p.GetValue(o))
                        {
                            PrintIteration(o2, identation + 2, prefix);
                        }
                    }
                }
                //the property is IEnumerable but not string
                else if ((p.GetValue(o) is IEnumerable) && !(p.GetValue(o) is string))
                {
                    CB?.Invoke(prefix, identationSpace + p.Name + " : ");

                    foreach (var o2 in (IEnumerable)p.GetValue(o))
                    {
                        PrintIteration(o2, identation + 2, prefix);
                    }
                }
                //the property is struct
                else if (p.PropertyType.IsValueType)
                {
                    if (p.PropertyType == typeof(System.DateTime))
                    {
                        CB?.Invoke(prefix, identationSpace + p.Name + " : " + p.GetValue(o).ToString());
                    }
                    else
                    {
                        CB?.Invoke(prefix, identationSpace + p.Name + " : " + p.GetValue(o).ToString());
                    }
                }
                //the property is "normal" reference type, including string type
                else
                {
                    if (p.GetValue(o) is string)
                    {
                        CB?.Invoke(prefix, identationSpace + p.Name + " : " + p.GetValue(o).ToString());
                    }
                    else
                    {
                        CB?.Invoke(prefix, identationSpace + p.Name + " : ");
                        PrintIteration(p.GetValue(o), identation + 2, prefix);
                    }
                }

            }
        }

    }
}
