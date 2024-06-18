using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Static.Data
{
    public static class Handlers
    {
        public static Spreadsheet.Handler spreadsheethandler = new();
        public static Warcraft_Logs.Handler logshandler = new();
        public static VisualLogic.Handler visualLogicHandler = new();
        public static Logik_Side.Handler logikHandler = new();
    }
}
