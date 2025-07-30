using System.ComponentModel;
using All_in_One.Services;

namespace All_in_One.Services.CalculateService.DataModels
{
    /// <summary>
    /// Die Basisklasse für einen Spieler.
    /// Name, Anzahl un- oder ungenügend verzauberter Gegenstände , Consumables und CPM-Wert
    /// </summary>
    public class PlayerExtractedData
    {
        string _PlayerName = string.Empty;
        public int CountOfNotEnchantetItems = 0;
        string _Enchantment = string.Empty;
        string _Consumable1 = string.Empty;
        string _Consumable2 = string.Empty;
        float _CountPerMinutes;


        public string PlayerName
        {
            get { return _PlayerName; }
            set { _PlayerName = value; MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerExtractedData), PlayerName)); }
        }
        public string Enchantment
        {
            get { return _Enchantment; }
            set { _Enchantment = value; MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerExtractedData), PlayerName)); }
        }
        public string Consumable1
        {
            get { return _Consumable1; }
            set { _Consumable1 = value; MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerExtractedData), PlayerName)); }
        }
        public string Consumable2
        {
            get { return _Consumable2; }
            set { _Consumable2 = value; MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerExtractedData), PlayerName)); }
        }
        public float CountPerMinutes
        {
            get { return _CountPerMinutes; }
            set { _CountPerMinutes = value; MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerExtractedData), PlayerName)); }
        }

    }
}
