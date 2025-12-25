using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.CalculateService.DataModels
{
    /// <summary>
    /// Basisklasse für einen Player. Enthält alle Informationen über Verzauberungen, Consumables und CPM
    /// </summary>
    public class PlayerData
    {
        string _name = string.Empty;
        float _idmissed;
        string _enchantment = string.Empty;
        string _consum1 = string.Empty;
        string _consum2 = string.Empty;
        float _cpm;
        string _date = string.Empty;


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerData), _name));
            }
        }

        public float IDs_Missed_Count 
        { 
            get
            {
                return _idmissed;
            } 
            set
            {
                _idmissed = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerData), _name));
            }
        }
        public string Enchantment 
        { 
            get
            {
                return _enchantment;
            } 
            set
            {
                _enchantment = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerData), _name));
            } 
        }
        public string Consumable1 
        { 
            get
            {
                return _consum1;
            } 
            set
            {
                _consum1 = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerData), _name));
            } 
        }
        public string Consumable2 
        { 
            get
            {
                return _consum2;
            }
            set
            {
                _consum2 = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerData), _name));
            }
        }
        public float CountsPerMinute 
        { 
            get
            {
                return _cpm;
            }
            set
            {
                _cpm = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerData), _name));
            }
        }
        public string Date 
        { 
            get
            {
                return _date;
            } 
            set
            {
                _date = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this, typeof(PlayerData), _name));
            }
        }
        public bool IsGoldDrache
        {
            get
            {
                return _enchantment == "" && (_consum1 != "" && !_consum1.Contains("[")) && (_consum2 !="" && !_consum2.Contains("[")) && _cpm >= Static.Data.BonusConditions.CountsPerMinuteReq;
            }
            set
            {

            }
        }


            

    }
}
