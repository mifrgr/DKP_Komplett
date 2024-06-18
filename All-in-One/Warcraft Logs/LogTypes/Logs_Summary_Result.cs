using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace All_in_One.Warcraft_Logs.LogTypes.Summary
{

    public class Summary_Rootobject
    {
        public int totalTime { get; set; }
        public float itemLevel { get; set; }
        public Composition[] composition { get; set; }
        public Damagedone[] damageDone { get; set; }
        public Healingdone[] healingDone { get; set; }
        public Damagetaken[] damageTaken { get; set; }
        public Deathevent[] deathEvents { get; set; }
        public Playerdetails playerDetails { get; set; }
        public int logVersion { get; set; }
        public int gameVersion { get; set; }
    }

    public class Playerdetails
    {
        public Tank[] tanks { get; set; }
        public Dp[] dps { get; set; }
        public Healer[] healers { get; set; }
    }

    public class Tank
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string server { get; set; }
        public string icon { get; set; }
        public string[] specs { get; set; }
        public int minItemLevel { get; set; }
        public int maxItemLevel { get; set; }
        public int potionUse { get; set; }
        public int healthstoneUse { get; set; }
        public Combatantinfo combatantInfo { get; set; }
    }

    public class Combatantinfo
    {
        public Stats stats { get; set; }
        public Talent[] talents { get; set; }
        public Artifact[] artifact { get; set; }
        public Gear[] gear { get; set; }
        public int[] specIDs { get; set; }
        public int factionID { get; set; }
    }

    public class Stats
    {
        public Speed Speed { get; set; }
        public Dodge Dodge { get; set; }
        public Mastery Mastery { get; set; }
        public Spirit Spirit { get; set; }
        public Stamina Stamina { get; set; }
        public Haste Haste { get; set; }
        public Leech Leech { get; set; }
        public Intellect Intellect { get; set; }
        public Armor Armor { get; set; }
        public Agility Agility { get; set; }
        public Block Block { get; set; }
        public Crit Crit { get; set; }
        public ItemLevel ItemLevel { get; set; }
        public Parry Parry { get; set; }
        public Strength Strength { get; set; }
        public Avoidance Avoidance { get; set; }
        public Versatility Versatility { get; set; }
    }

    public class Speed
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Dodge
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Mastery
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Spirit
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Stamina
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Haste
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Leech
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Intellect
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Armor
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Agility
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Block
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Crit
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class ItemLevel
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Parry
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Strength
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Avoidance
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Versatility
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Talent
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
    }

    public class Artifact
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
        public int total { get; set; }
    }

    public class Gear
    {
        public int id { get; set; }
        public int slot { get; set; }
        public int quality { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public int itemLevel { get; set; }
        public int permanentEnchant { get; set; }
        public string permanentEnchantName { get; set; }
        public int setID { get; set; }
        public int temporaryEnchant { get; set; }
        public string temporaryEnchantName { get; set; }
    }

    public class Dp
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string server { get; set; }
        public string icon { get; set; }
        public string[] specs { get; set; }
        public int minItemLevel { get; set; }
        public int maxItemLevel { get; set; }
        public int potionUse { get; set; }
        public int healthstoneUse { get; set; }
        public Combatantinfo1 combatantInfo { get; set; }
    }

    public class Combatantinfo1
    {
        public Stats1 stats { get; set; }
        public Talent1[] talents { get; set; }
        public Artifact1[] artifact { get; set; }
        public Gear1[] gear { get; set; }
        public int[] specIDs { get; set; }
        public int factionID { get; set; }
    }

    public class Stats1
    {
        public Speed1 Speed { get; set; }
        public Mastery1 Mastery { get; set; }
        public Spirit1 Spirit { get; set; }
        public Stamina1 Stamina { get; set; }
        public Haste1 Haste { get; set; }
        public Leech1 Leech { get; set; }
        public Intellect1 Intellect { get; set; }
        public Agility1 Agility { get; set; }
        public Crit1 Crit { get; set; }
        public ItemLevel1 ItemLevel { get; set; }
        public Strength1 Strength { get; set; }
        public Avoidance1 Avoidance { get; set; }
        public Versatility1 Versatility { get; set; }
    }

    public class Speed1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Mastery1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Spirit1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Stamina1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Haste1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Leech1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Intellect1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Agility1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Crit1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class ItemLevel1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Strength1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Avoidance1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Versatility1
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Talent1
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
    }

    public class Artifact1
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
        public int total { get; set; }
    }

    public class Gear1
    {
        public int id { get; set; }
        public int slot { get; set; }
        public int quality { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public int itemLevel { get; set; }
        public int permanentEnchant { get; set; }
        public string permanentEnchantName { get; set; }
        public int setID { get; set; }
        public int temporaryEnchant { get; set; }
        public string temporaryEnchantName { get; set; }
    }

    public class Healer
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string server { get; set; }
        public string icon { get; set; }
        public string[] specs { get; set; }
        public int minItemLevel { get; set; }
        public int maxItemLevel { get; set; }
        public int potionUse { get; set; }
        public int healthstoneUse { get; set; }
        public Combatantinfo2 combatantInfo { get; set; }
    }

    public class Combatantinfo2
    {
        public Stats2 stats { get; set; }
        public Talent2[] talents { get; set; }
        public Artifact2[] artifact { get; set; }
        public Gear2[] gear { get; set; }
        public int[] specIDs { get; set; }
        public int factionID { get; set; }
    }

    public class Stats2
    {
        public Speed2 Speed { get; set; }
        public Mastery2 Mastery { get; set; }
        public Spirit2 Spirit { get; set; }
        public Stamina2 Stamina { get; set; }
        public Haste2 Haste { get; set; }
        public Leech2 Leech { get; set; }
        public Intellect2 Intellect { get; set; }
        public Agility2 Agility { get; set; }
        public Crit2 Crit { get; set; }
        public ItemLevel2 ItemLevel { get; set; }
        public Strength2 Strength { get; set; }
        public Avoidance2 Avoidance { get; set; }
        public Versatility2 Versatility { get; set; }
    }

    public class Speed2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Mastery2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Spirit2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Stamina2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Haste2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Leech2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Intellect2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Agility2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Crit2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class ItemLevel2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Strength2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Avoidance2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Versatility2
    {
        public int min { get; set; }
        public int max { get; set; }
    }

    public class Talent2
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
    }

    public class Artifact2
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
        public int total { get; set; }
    }

    public class Gear2
    {
        public int id { get; set; }
        public int slot { get; set; }
        public int quality { get; set; }
        public string icon { get; set; }
        public string name { get; set; }
        public int itemLevel { get; set; }
        public int permanentEnchant { get; set; }
        public string permanentEnchantName { get; set; }
        public int setID { get; set; }
        public int temporaryEnchant { get; set; }
        public string temporaryEnchantName { get; set; }
    }

    public class Composition
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public Spec[] specs { get; set; }
    }

    public class Spec
    {
        public string spec { get; set; }
        public string role { get; set; }
    }

    public class Damagedone
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public int total { get; set; }
    }

    public class Healingdone
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public int total { get; set; }
    }

    public class Damagetaken
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
        public int total { get; set; }
        public bool composite { get; set; }
    }

    public class Deathevent
    {
        public string name { get; set; }
        public int id { get; set; }
        public int guid { get; set; }
        public string type { get; set; }
        public string icon { get; set; }
        public int deathTime { get; set; }
        public Ability ability { get; set; }
    }

    public class Ability
    {
        public string name { get; set; }
        public int guid { get; set; }
        public int type { get; set; }
        public string abilityIcon { get; set; }
    }

}
