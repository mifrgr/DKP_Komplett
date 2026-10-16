using All_in_One.Static.Data;
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
        int _punktestand = 0;
        float _idmissed;
        string _enchantment = string.Empty;
        string _consum1 = string.Empty;
        string _consum2 = string.Empty;
        float _cpm;
        string _worldbuffs = string.Empty;
        string _date = string.Empty;
        int _bossDKP = 0;


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

        public int Punktestand
        {
            get
            {
                return _punktestand;
            }
            set
            {
                _punktestand = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this,typeof(PlayerData),_name));
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
        public string Worldbuffs
        {
            get
            {
                return _worldbuffs;
            }
            set
            {
                _worldbuffs = value;
                MainService.Instance.visualViewModeel.UpdateViewModellData(new VisualLogic.Data.VisualUpdateDataObject(this,typeof(PlayerData), _name));
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
                return IDs_Missed_Count == 0 && _enchantment == "" && (_consum1 != "" && !_consum1.Contains("[")) && (_consum2 !="" && !_consum2.Contains("[")) && _cpm >= Static.Data.BonusConditions.CountsPerMinuteReq && HasPlayerWorldbuffs;
            }
            set
            {

            }
        }

        public bool HasPlayerWorldbuffs
        {
            get
            {
                var splitArray = _worldbuffs.Split(Environment.NewLine).ToList();
                return splitArray.Count == 0 || splitArray.Where(line => line != "" && !line.Contains(ClassEnums.Alternative.ToString())).Count() == 0;
            }
        }

        public int BossDKP
        { 
            get 
            { 
                return _bossDKP; 
            } 
            set 
            { 
                _bossDKP = value; 
            }
        }
            

    }
}
