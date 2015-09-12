#region

using db.data;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace wServer.realm.entities
{
    internal class MerchantLists
    {
        public static int[] AccessoryClothList;
        public static int[] AccessoryDyeList;
        public static int[] ClothingClothList;
        public static int[] ClothingDyeList;

        // Normal price, testing price, simplified price. Normal currency, testing currency,
        // simplified currency.
        public static Dictionary<int, Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>> MerchantPrices = new Dictionary<int, Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>>
        {
            {0xa07, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(51, 1, 51, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Wand of Death
            {0xa85, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T9) Wand of Deep Sorcery - 150 Gold
            {0xa86, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T10) Wand of Shadow - 225 Gold
            {0xa87, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T11) Wand of Ancient Warning - 450 Gold
            {0xaf6, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T12) Wand of Recompense - 550 Gold
            {0xa1e, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T8) Golden Bow - 51 Gold
            {0xa8b, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T9) Verdant Bow - 150 Gold
            {0xa8c, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T10) Bow of Fey Magic - 225 Gold
            {0xa8d, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T11) Bow of Innocent Blood - 450 Gold
            {0xb02, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T12) Bow of Covert Havens - 600 Gold
            {0xa19, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T8) Fire Dagger - 51 Gold
            {0xa88, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T9) Ragetalon Dagger - 150 Gold
            {0xa89, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T10) Emeraldshard Dagger - 225 Gold
            {0xa8a, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T11) Agateclaw Dagger - 450 Gold
            {0xaff, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T12) Dagger of Foul Malevolence - 650 Gold
            {0xa82, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T8) Ravenheart Sword - 51 Gold
            {0xa83, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T9) Dragonsoul Sword - 150 Gold
            {0xa84, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T10) Archon Sword - 225 Gold
            {0xa47, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T11) Skysplitter Sword - 450 Gold
            {0xb0b, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T12) Sword of Acclaim - 900 Gold
            {0xa9f, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T8) Staff of Horror - 51 Gold
            {0xaa0, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T9) Staff of Necrotic Arcana - 150 Gold
            {0xaa1, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T10) Staff of Diabolic Secrets - 225 Gold
            {0xaa2, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T11) Staff of Astral Knowledge - 450 Gold
            {0xb08, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T12) Staff of the Cosmic Whole - 900 Gold
            {0xc4c, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T8) Demon Edge - 51 Gold
            {0xc4d, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T9) Jewel Eye Katana - 150 Gold
            {0xc4e, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T10) Ichimonji - 225 Gold
            {0xc4f, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T11) Muramasa - 450 Gold
            {0xc50, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T12) Masamune - 700 Gold
            {0xabf, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T4) Ring of Paramount Attack - 90 Gold
            {0xac0, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T4) Ring of Paramount Defense - 225 Gold
            {0xac1, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T4) Ring of Paramount Speed - 90 Gold
            {0xac2, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T4) Ring of Paramount Vitality - 90 Gold
            {0xac3, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T4) Ring of Paramount Wisdom - 90 Gold
            {0xac4, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },  // (T4) Ring of Paramount Dexterity - 90 Gold
            {0xac5, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T4) Ring of Paramount Health - 225 Gold
            {0xac6, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T4) Ring of Paramount Magic - 225 Gold
            {0xac7, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T5) Ring of Exalted Attack - 180 Gold
            {0xac8, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T5) Ring of Exalted Defense - 360 Gold
            {0xac9, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T5) Ring of Exalted Speed - 180 Gold
            {0xaca, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T5) Ring of Exalted Vitality - 180 Gold
            {0xacb, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T5) Ring of Exalted Wisdom - 180 Gold
            {0xacc, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T5) Ring of Exalted Dexterity - 180 Gold
            {0xacd, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T5) Ring of Exalted Health - 360 Gold
            {0xace, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // (T5) Ring of Exalted Magic - 360 Gold
            {0xa13, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Dragonscale Armor
            {0xa60, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Robe of the Master
            {0xa8e, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Roc Leather Armor
            {0xa8f, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Hippogriff Hide Armor
            {0xa90, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Griffon Hide Armor
            {0xa91, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Desolation Armor
            {0xa92, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Vengeance Armor
            {0xa93, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Abyssal Armor
            {0xa94, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, // Robe of the Shadow Magus
            {0xa95, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xa96, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xad3, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xaf9, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xafc, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb05, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xa0c, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xa30, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xa46, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xa55, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xa5b, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xa65, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xa6b, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xaa8, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xaaf, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xab6, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xae1, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb20, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb22, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb23, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb24, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb25, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb26, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb27, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb28, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb29, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb2a, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb2b, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb2c, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb2d, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb32, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xb33, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xc58, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xc59, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xcc4, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xcc5, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xcc6, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xcc7, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xcc8, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xcc9, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xcca, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xccb, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xccc, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) },
            {0xc86, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon feline egg
            {0xc87, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare feline egg
            {0xc8a, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon canine egg
            {0xc8b, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare canine egg
            {0xc8e, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon avian egg
            {0xc8f, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare avian egg
            {0xc92, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon exotic egg
            {0xc93, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare exotic egg
            {0xc96, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon farm egg
            {0xc97, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare farm egg
            {0xc9a, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon woodland egg
            {0xc9b, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare woodland egg
            {0xc9e, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon reptile egg
            {0xc9f, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare reptile egg
            {0xca2, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon insect egg
            {0xca3, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare insect egg
            {0xca6, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon pinguin egg
            {0xca7, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare pinguin egg
            {0xcaa, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon aquatic egg
            {0xcab, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare aquatic egg
            {0xcae, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon spooky egg
            {0xcaf, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare spooky egg
            {0xcb2, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon humanoid egg
            {0xcb3, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare humanoid egg
            {0xcb6, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon ???? egg
            {0xcb7, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare ???? egg
            {0xcba, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon automaton egg
            {0xcbb, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare automaton egg
            {0xcbe, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //uncommon mystery egg
            {0xcbf, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //rare mystery egg
            {0x2290, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Bella's Key - just temponary for testing
            {0x701, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Undead lair key
            {0x705, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Pirate cave key
            {0x70a, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Abyss of demons key
            {0x70b, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Snake pit key
            {0x710, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Tomb of the ancients key
            {0x71f, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Sprite World Key
            {0xc11, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Ocean Trench Key
            {0xc19, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Totem Key
            {0xc23, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Manor Key
            {0xc2e, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Daby's Key
            {0xc2f, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Lab Key
            {0xcce, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Deadwater docks key
            {0xccf, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Woodland Labyrinth Key
            {0xcda, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //The crawling depths key
            {0xcdd, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(150, 1, 150, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold) }, //Shatters key
        };

        // Keys
        public static int[] StoreList1 =
        {
            0xcdd, 0xcda, 0xccf, 0xcce, 0xc2f,
            0xc2e, 0xc23, 0xc19, 0xc11, 0x71f,
            0x710, 0x70b, 0x70a, 0x705, 0x701,
            0x2290
        };

        public static int[] StoreList10 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList11 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList12 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList13 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList14 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList15 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList16 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList17 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList18 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static int[] StoreList19 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        // Eggs
        public static int[] StoreList2 =
        {
            0xcbf, 0xcbe, 0xcbb, 0xcba, 0xcb7,
            0xcb6, 0xcb2, 0xcb3, 0xcae, 0xcaf,
            0xcab, 0xcaa, 0xca7, 0xca6, 0xca3,
            0xca2, 0xc9f, 0xc9e, 0xc9b, 0xc9a,
            0xc97, 0xc96, 0xc93, 0xc92, 0xc8f,
            0xc8e, 0xc8b, 0xc8a, 0xc87, 0xc86
        };

        public static int[] StoreList20 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        // Pet food
        public static int[] StoreList3 =
        {
            0xccc, 0xccb, 0xcca, 0xcc9, 0xcc8,
            0xcc7, 0xcc6, 0xcc5, 0xcc4
        };

        // Abilities
        public static int[] StoreList4 =
        {
            0xb25, 0xa5b, 0xb22, 0xa0c, 0xb24,
            0xa30, 0xb26, 0xa55, 0xb27, 0xae1,
            0xb28, 0xa65, 0xb29, 0xa6b, 0xb2a,
            0xaa8, 0xb2b, 0xaaf, 0xb2c, 0xab6,
            0xb2d, 0xa46, 0xb23, 0xb20, 0xb33,
            0xb32, 0xc59, 0xc58
        };

        // Armor
        public static int[] StoreList5 =
        {
            0xb05, 0xa96, 0xa95, 0xa94, 0xa60,
            0xafc, 0xa93, 0xa92, 0xa91, 0xa13,
            0xaf9, 0xa90, 0xa8f, 0xa8e, 0xad3
        };

        // Weapons Top
        public static int[] StoreList6 =
        {
            0xaf6, 0xa87, 0xa86, 0xa85, 0xa07,
            0xb02, 0xa8d, 0xa8c, 0xa8b, 0xa1e,
            0xb08, 0xaa2, 0xaa1, 0xaa0, 0xa9f
        };

        // Weapons Down
        public static int[] StoreList7 =
        {
            0xb0b, 0xa47, 0xa84, 0xa83, 0xa82,
            0xaff, 0xa8a, 0xa89, 0xa88, 0xa19,
            0xc50, 0xc4f, 0xc4e, 0xc4d, 0xc4c
        };

        // Rings
        public static int[] StoreList8 =
        {
            0xabf, 0xac0, 0xac1, 0xac2, 0xac3,
            0xac4, 0xac5, 0xac6, 0xac7, 0xac8,
            0xac9, 0xaca, 0xacb, 0xacc, 0xacd,
            0xace
        };

        // Shatters
        public static int[] StoreList9 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        public static bool TM = Program.TestingMerchants;

        private static readonly string[] ExcludedCloths =
        {
            "Large Ivory Dragon Scale Cloth", "Small Ivory Dragon Scale Cloth",
            "Large Green Dragon Scale Cloth", "Small Green Dragon Scale Cloth",
            "Large Midnight Dragon Scale Cloth", "Small Midnight Dragon Scale Cloth",
            "Large Blue Dragon Scale Cloth", "Small Blue Dragon Scale Cloth",
            "Large Red Dragon Scale Cloth", "Small Red Dragon Scale Cloth",
            "Large Jester Argyle Cloth", "Small Jester Argyle Cloth",
            "Large Alchemist Cloth", "Small Alchemist Cloth",
            "Large Mosaic Cloth", "Small Mosaic Cloth",
            "Large Spooky Cloth", "Small Spooky Cloth",
            "Large Flame Cloth", "Small Flame Cloth",
            "Large Heavy Chainmail Cloth", "Small Heavy Chainmail Cloth",
            "Large Blue Camo Cloth", "Small Blue Camo Cloth"
        };

        private static readonly ILog logger = LogManager.GetLogger(typeof(MerchantLists));

        public static void InitMerchatLists(XmlData data)
        {
            logger.Info("Loading MerchantLists");
            List<int> accessoryDyeList = new List<int>();
            List<int> clothingDyeList = new List<int>();
            List<int> accessoryClothList = new List<int>();
            List<int> clothingClothList = new List<int>();

            foreach (KeyValuePair<ushort, Item> item in data.Items.Where(_ => ExcludedCloths.All(i => i != _.Value.ObjectId)))
            {
                if (item.Value.Texture1 != 0 && item.Value.ObjectId.Contains("Clothing") && item.Value.Class == "Dye")
                {
                    MerchantPrices.Add(item.Value.ObjectType, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(51, 1, 51, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold));
                    clothingDyeList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture2 != 0 && item.Value.ObjectId.Contains("Accessory") && item.Value.Class == "Dye")
                {
                    MerchantPrices.Add(item.Value.ObjectType, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(51, 1, 51, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold));
                    accessoryDyeList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture1 != 0 && item.Value.ObjectId.Contains("Cloth") && item.Value.ObjectId.Contains("Large"))
                {
                    MerchantPrices.Add(item.Value.ObjectType, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(160, 1, 160, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold));
                    clothingClothList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture2 != 0 && item.Value.ObjectId.Contains("Cloth") && item.Value.ObjectId.Contains("Small"))
                {
                    MerchantPrices.Add(item.Value.ObjectType, new Tuple<int, int, int, CurrencyType, CurrencyType, CurrencyType>(160, 1, 160, CurrencyType.Gold, CurrencyType.Fame, CurrencyType.Gold));
                    accessoryClothList.Add(item.Value.ObjectType);
                }
            }

            ClothingDyeList = clothingDyeList.ToArray();
            ClothingClothList = clothingClothList.ToArray();
            AccessoryClothList = accessoryClothList.ToArray();
            AccessoryDyeList = accessoryDyeList.ToArray();
            logger.Info("MerchantLists added");
        }
    }
}
