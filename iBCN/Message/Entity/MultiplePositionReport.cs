using Metocean.iBCN.Message.Interface.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metocean.iBCN.Message.Entity
{
    /// <summary>
    /// 
    /// </summary>
    public class MultiplePositionReport : iBCNMessage, IMsgEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public EventReport[] PositionReports { get; private set; } = new EventReport[] { };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityData"></param>
        public override void FromBytes(byte[] entityData)
        {
            base.FromBytes(entityData);
            var count = entityData.Length / 16;
            for (int i = 0; i < count; i++)
            {
                var report = new EventReport();
                report.FromBytes(entityData.Skip(i * 16).Take(16).ToArray());
                PositionReports = PositionReports.Concat(new EventReport[] { report }).ToArray();
            }
        }
    }
}
