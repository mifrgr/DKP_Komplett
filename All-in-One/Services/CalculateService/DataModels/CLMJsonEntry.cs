using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Services.CalculateService.DataModels
{

    public class CLMJsonEntry
    {
        public Standings standings { get; set; }
    }

    public class Standings
    {
        public Roster[] roster { get; set; }
    }

    public class Roster
    {
        public int uid { get; set; }
        public string name { get; set; }
        public object[] fieldNames { get; set; }
        public Standings1 standings { get; set; }
        public Config config { get; set; }
        public int type { get; set; }
    }

    public class Standings1
    {
        public Player[] player { get; set; }
    }

    public class Player
    {
        public string name { get; set; }
        public string guid { get; set; }
        public int spent { get; set; }
        public string _class { get; set; }
        public int points { get; set; }
    }

    public class Config
    {
        public int itemValueMode { get; set; }
        public bool allowEqualMax { get; set; }
        public int baseSpent { get; set; }
        public int raidCompletionBonusValue { get; set; }
        public bool autoAwardOnlineOnly { get; set; }
        public bool dynamicValue { get; set; }
        public bool zeroSumBank { get; set; }
        public bool autoAwardSameZoneOnly { get; set; }
        public int minimalIncrement { get; set; }
        public int weeklyReset { get; set; }
        public bool always0 { get; set; }
        public bool onTimeBonus { get; set; }
        public int intervalBonusValue { get; set; }
        public int onTimeBonusValue { get; set; }
        public int minimumPoints { get; set; }
        public bool useOS { get; set; }
        public int antiSnipe { get; set; }
        public int benchMultiplier { get; set; }
        public bool selfBenchSubscribe { get; set; }
        public bool baseAlways { get; set; }
        public int auctionTime { get; set; }
        public bool raidCompletionBonus { get; set; }
        public int minGP { get; set; }
        public int intervalBonusTime { get; set; }
        public int hardCap { get; set; }
        public int basePoints { get; set; }
        public bool autoAwardIncludeBench { get; set; }
        public bool allowBelowMinStandings { get; set; }
        public int weeklyCap { get; set; }
        public bool multiplyTime { get; set; }
        public bool bossKillBonus { get; set; }
        public bool intervalBonus { get; set; }
        public bool allowCancelPass { get; set; }
        public bool allInAlways { get; set; }
        public int zeroSumBankInflation { get; set; }
        public int roundPR { get; set; }
        public bool namedButtons { get; set; }
        public int bossKillBonusValue { get; set; }
        public bool autoBenchLeavers { get; set; }
        public int auctionType { get; set; }
        public int rollTime { get; set; }
        public int tax { get; set; }
        public int roundDecimals { get; set; }
    }


}
