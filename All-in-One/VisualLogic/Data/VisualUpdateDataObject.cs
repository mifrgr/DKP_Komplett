using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.VisualLogic.Data
{
    public class VisualUpdateDataObject
    {
        public VisualUpdateDataObject(object Data,Type Type,string Name) 
        {
            data = Data;
            type = Type;
            name = Name;
        }
        public object data;
        public Type type;
        public string name;
    }
}
