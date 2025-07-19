using All_in_One.DataModels.SpreadSheetModels;
using System;

namespace All_in_One.Services.CalculateService
{
    internal class CalculateDKP
    {
        /// <summary>
        /// Berecnet die Punkte für den Spieler. Maximal dürfen 101 erreicht werden.
        /// </summary>
        /// <param name="entry">Spielerdaten als SpreadSheet Eintrag</param>
        /// <returns></returns>
        public float CalculateDKPPoints(SpreadsheetEntry entry)
        {
            if (entry.VersäumteIDs.Contains("Umgeloggt") || int.Parse(entry.VersäumteIDs) < 2)
            {
                if (entry.GetDKP)
                {
                    if (float.Parse(entry.Punkte) + 10 >= 100)
                    {
                        if (entry.Punkte.EndsWith("1") || entry.Punkte.EndsWith("6") && float.Parse(entry.Punkte) - Math.Floor(float.Parse(entry.Punkte)) == 0)
                        {
                            return 101;
                        }
                        if (float.Parse(entry.Punkte) - Math.Floor(float.Parse(entry.Punkte)) != 0)
                        {
                            return 100 + (float.Parse(entry.Punkte) - ((float)Math.Floor(float.Parse(entry.Punkte))));
                        }
                        else
                        {
                            return 100;
                        }
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
            else if (int.Parse(entry.VersäumteIDs) >= 2)
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
