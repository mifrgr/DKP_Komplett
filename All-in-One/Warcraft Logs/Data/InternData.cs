using All_in_One.Warcraft_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_Logs.Data
{
    internal class InternData
    {
        /// <summary>
        /// This means the endTime from the Log File.
        /// </summary>
        internal long endTime { get; set; }

        /// <summary>
        /// The duration of the combat from the file. Uptime % calculation will be based on that time.
        /// </summary>
        internal long FightTime { get; set; }

        internal int Encounters { get; set; }

        internal LogGetter getter;
    }
}
