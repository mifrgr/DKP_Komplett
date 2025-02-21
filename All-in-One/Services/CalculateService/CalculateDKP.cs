using All_in_One.DataModels.SpreadSheetModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.CalculateService
{
    internal class CalculateDKP
    {
        public float CalculateDKPPoints(SpreadsheetEntry entry)
        {
            if (entry.VersäumteIDs.Contains("Umgeloggt") || int.Parse(entry.VersäumteIDs) < 2)
            {
                if (entry.GetDKP)
                {
                    if (float.Parse(entry.Punkte) + 10 >= 101)
                    {
                        return 101;
                    }
                    else
                    {
                        return float.Parse(entry.Punkte) + 10;
                    }
                }
                else
                {
                    return float.Parse(entry.Punkte);
                }
            }
            else if (int.Parse(entry.VersäumteIDs) >= 10)
            {
                return 0;

            }
            else if(int.Parse(entry.VersäumteIDs) >= 2)
            {
                if (float.Parse(entry.Punkte) - 5 >= 0)
                {
                    return float.Parse(entry.Punkte) - 5;
                }
                else
                {
                    return 0;
                }
                
            }

            return -1;
        }
    }
}
