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

        // Normal price, testing price, simplified price. Normal currency, testing currency, simplified currency.
        public static Dictionary<int, Tuple<int, int, CurrencyType, CurrencyType>> MerchantPrices = new Dictionary<int, Tuple<int, int, CurrencyType, CurrencyType>>
        {
            {0xa07, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) }, // Wand of Death
            {0xa85, new Tuple<int, int, CurrencyType, CurrencyType>(150, 150, 0, 0) }, // Wand of Deep Sorcery
            {0xa86, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Wand of Shadow
            {0xa87, new Tuple<int, int, CurrencyType, CurrencyType>(450, 450, 0, 0) }, // Wand of Ancient Warning
            {0xaf6, new Tuple<int, int, CurrencyType, CurrencyType>(550, 550, 0, 0) }, // Wand of Recompense
            {0xa1e, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) },  // Golden Bow
            {0xa8b, new Tuple<int, int, CurrencyType, CurrencyType>(150, 150, 0, 0) }, // Verdant Bow
            {0xa8c, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Bow of Fey Magic
            {0xa8d, new Tuple<int, int, CurrencyType, CurrencyType>(450, 450, 0, 0) }, // Bow of Innocent Blood
            {0xb02, new Tuple<int, int, CurrencyType, CurrencyType>(600, 600, 0, 0) }, // Bow of Covert Havens
            {0xa19, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) },  // Fire Dagger
            {0xa88, new Tuple<int, int, CurrencyType, CurrencyType>(150, 150, 0, 0) }, // Ragetalon Dagger
            {0xa89, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Emeraldshard Dagger
            {0xa8a, new Tuple<int, int, CurrencyType, CurrencyType>(450, 450, 0, 0) }, // Agateclaw Dagger
            {0xaff, new Tuple<int, int, CurrencyType, CurrencyType>(650, 650, 0, 0) }, // Dagger of Foul Malevolence
            {0xa82, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) },  // Ravenheart Sword
            {0xa83, new Tuple<int, int, CurrencyType, CurrencyType>(150, 150, 0, 0) }, // Dragonsoul Sword
            {0xa84, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Archon Sword
            {0xa47, new Tuple<int, int, CurrencyType, CurrencyType>(450, 450, 0, 0) }, // Skysplitter Sword
            {0xb0b, new Tuple<int, int, CurrencyType, CurrencyType>(900, 900, 0, 0) }, // Sword of Acclaim
            {0xa9f, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) },  // Staff of Horror
            {0xaa0, new Tuple<int, int, CurrencyType, CurrencyType>(150, 150, 0, 0) }, // Staff of Necrotic Arcana
            {0xaa1, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Staff of Diabolic Secrets
            {0xaa2, new Tuple<int, int, CurrencyType, CurrencyType>(450, 450, 0, 0) }, // Staff of Astral Knowledge
            {0xb08, new Tuple<int, int, CurrencyType, CurrencyType>(900, 900, 0, 0) }, // Staff of the Cosmic Whole
            {0xc4c, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) },  // Demon Edge
            {0xc4d, new Tuple<int, int, CurrencyType, CurrencyType>(150, 150, 0, 0) }, // Jewel Eye Katana
            {0xc4e, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Ichimonji
            {0xc4f, new Tuple<int, int, CurrencyType, CurrencyType>(450, 450, 0, 0) }, // Muramasa
            {0xc50, new Tuple<int, int, CurrencyType, CurrencyType>(700, 700, 0, 0) }, // Masamune

            {0xabf, new Tuple<int, int, CurrencyType, CurrencyType>(90, 90, 0, 0) },  // Ring of Paramount Attack
            {0xac0, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Ring of Paramount Defense
            {0xac1, new Tuple<int, int, CurrencyType, CurrencyType>(90, 90, 0, 0) },  // Ring of Paramount Speed
            {0xac2, new Tuple<int, int, CurrencyType, CurrencyType>(90, 90, 0, 0) },  // Ring of Paramount Vitality
            {0xac3, new Tuple<int, int, CurrencyType, CurrencyType>(90, 90, 0, 0) },  // Ring of Paramount Wisdom
            {0xac4, new Tuple<int, int, CurrencyType, CurrencyType>(90, 90, 0, 0) },  // Ring of Paramount Dexterity
            {0xac5, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Ring of Paramount Health
            {0xac6, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Ring of Paramount Magic
            {0xac7, new Tuple<int, int, CurrencyType, CurrencyType>(180, 180, 0, 0) }, // Ring of Exalted Attack
            {0xac8, new Tuple<int, int, CurrencyType, CurrencyType>(360, 360, 0, 0) }, // Ring of Exalted Defense
            {0xac9, new Tuple<int, int, CurrencyType, CurrencyType>(180, 180, 0, 0) }, // Ring of Exalted Speed
            {0xaca, new Tuple<int, int, CurrencyType, CurrencyType>(180, 180, 0, 0) }, // Ring of Exalted Vitality
            {0xacb, new Tuple<int, int, CurrencyType, CurrencyType>(180, 180, 0, 0) }, // Ring of Exalted Wisdom
            {0xacc, new Tuple<int, int, CurrencyType, CurrencyType>(180, 180, 0, 0) }, // Ring of Exalted Dexterity
            {0xacd, new Tuple<int, int, CurrencyType, CurrencyType>(360, 360, 0, 0) }, // Ring of Exalted Health
            {0xace, new Tuple<int, int, CurrencyType, CurrencyType>(360, 360, 0, 0) }, // Ring of Exalted Magic

            {0xa13, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) }, // Dragonscale Armor
            {0xa60, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) }, // Robe of the Master
            {0xa8e, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Roc Leather Armor
            {0xa8f, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Hippogriff Hide Armor
            {0xa90, new Tuple<int, int, CurrencyType, CurrencyType>(425, 425, 0, 0) }, // Griffon Hide Armor
            {0xa91, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Desolation Armor
            {0xa92, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Vengeance Armor
            {0xa93, new Tuple<int, int, CurrencyType, CurrencyType>(425, 425, 0, 0) }, // Abyssal Armor
            {0xa94, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Robe of the Shadow Magus
            {0xa95, new Tuple<int, int, CurrencyType, CurrencyType>(225, 225, 0, 0) }, // Robe of the Moon Wizard
            {0xa96, new Tuple<int, int, CurrencyType, CurrencyType>(425, 425, 0, 0) }, // Robe of the Elder Warlock
            {0xad3, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0) }, // Drake Hide Armor
            {0xaf9, new Tuple<int, int, CurrencyType, CurrencyType>(800, 800, 0, 0) }, // Hydra Skin Armor
            {0xafc, new Tuple<int, int, CurrencyType, CurrencyType>(850, 850, 0, 0) }, // Acropolis Armor
            {0xb05, new Tuple<int, int, CurrencyType, CurrencyType>(850, 850, 0, 0) }, // Robe of the Grand Sorcerer

            {0xa0c, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Mithril Shield
            {0xa30, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Magic Nova Spell
            {0xa46, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Banishment Orb
            {0xa55, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Seal of the Holy Warrior
            {0xa5b, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Tome of Divine Favor
            {0xa65, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Golden Quiver
            {0xa6b, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Golden Helm
            {0xaa8, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Nightwing Venom
            {0xaaf, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Lifedrinker Skull
            {0xab6, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Dragonstalker Trap
            {0xae1, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Cloak of Endless Twilight
            {0xb20, new Tuple<int, int, CurrencyType, CurrencyType>(175, 175, 0, 0) }, // Prism of Phantoms
            {0xb22, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Colossus Shield
            {0xb23, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Prism of Apparitions
            {0xb24, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Elemental Detonation Spell
            {0xb25, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Tome of Holy Guidance
            {0xb26, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Seal of the Blessed Champion
            {0xb27, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Cloak of Ghostly Concealment
            {0xb28, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Quiver of Elvish Mastery
            {0xb29, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Helm of the Great General
            {0xb2a, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Baneserpent Poison
            {0xb2b, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Bloodsucker Skull
            {0xb2c, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Giantcatcher Trap
            {0xb2d, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Planefetter Orb
            {0xb32, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Scepter of Skybolts
            {0xb33, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Scepter of Storms
            {0xc58, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Ice Star
            {0xc59, new Tuple<int, int, CurrencyType, CurrencyType>(400, 400, 0, 0) }, // Doom Circle

            {0xcc4, new Tuple<int, int, CurrencyType, CurrencyType>(240, 240, 0, 0) }, // Chocolate Cream Sandwich Cookie
            {0xcc5, new Tuple<int, int, CurrencyType, CurrencyType>(180, 180, 0, 0) }, // Power Pizza
            {0xcc6, new Tuple<int, int, CurrencyType, CurrencyType>(120, 120, 0, 0) }, // Great Taco
            {0xcc7, new Tuple<int, int, CurrencyType, CurrencyType>(720, 720, 0, 0) }, // Double Cheeseburger Deluxe
            {0xcc8, new Tuple<int, int, CurrencyType, CurrencyType>(480, 480, 0, 0) }, // Superburger
            {0xcc9, new Tuple<int, int, CurrencyType, CurrencyType>(20, 20, 0, 0) }, // Soft Drink
            {0xcca, new Tuple<int, int, CurrencyType, CurrencyType>(360, 360, 0, 0) }, // Grapes of Wrath
            {0xccb, new Tuple<int, int, CurrencyType, CurrencyType>(60, 60, 0, 0) }, // Fries
            {0xccc, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Ambrosia

            {0xc86, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Feline Egg
            {0xc87, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Feline Egg
            {0xc8a, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Canine Egg
            {0xc8b, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Canine Egg
            {0xc8e, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Avian Egg
            {0xc8f, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Avian Egg
            {0xc92, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Exotic Egg
            {0xc93, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Exotic Egg
            {0xc96, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Farm Egg
            {0xc97, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Farm Egg
            {0xc9a, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Woodland Egg
            {0xc9b, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Woodland Egg
            {0xc9e, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Reptile Egg
            {0xc9f, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Reptile Egg
            {0xca2, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Insect Egg
            {0xca3, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Insect Egg
            {0xca6, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Penguin Egg
            {0xca7, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Penguin Egg
            {0xcaa, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Aquatic Egg
            {0xcab, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Aquatic Egg
            {0xcae, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Spooky Egg
            {0xcaf, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Spooky Egg
            {0xcb2, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Humanoid Egg
            {0xcb3, new Tuple<int, int, CurrencyType, CurrencyType>(2000, 2000, 0, 0) }, // Rare Humanoid Egg
            {0xcb6, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon ???? Egg
            {0xcb7, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare ???? Egg
            {0xcba, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Automaton Egg
            {0xcbb, new Tuple<int, int, CurrencyType, CurrencyType>(1200, 1200, 0, 0) }, // Rare Automaton Egg
            {0xcbe, new Tuple<int, int, CurrencyType, CurrencyType>(300, 300, 0, 0) }, // Uncommon Mystery Egg
            {0xcbf, new Tuple<int, int, CurrencyType, CurrencyType>(1000, 1000, 0, 0) }, // Rare Mystery Egg

            {0x2290, new Tuple<int, int, CurrencyType, CurrencyType>(150, 150, 0, 0) }, // Bella's Key
            {0x701, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Undead Lair Key
            {0x705, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Pirate Cave Key
            {0x70a, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Abyss of Demons Key
            {0x70b, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Snake Pit key
            {0x710, new Tuple<int, int, CurrencyType, CurrencyType>(250, 250, 0, 0) }, // Tomb of the Ancients Key
            {0x71f, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Sprite World Key
            {0xc11, new Tuple<int, int, CurrencyType, CurrencyType>(250, 250, 0, 0) }, // Ocean Trench Key
            {0xc19, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Totem Key
            {0xc23, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Manor Key
            {0xc2e, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Davy's Key
            {0xc2f, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Lab Key
            {0xcce, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Deadwater Docks Key
            {0xccf, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Woodland Labyrinth Key
            {0xcda, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // The Crawling Depths Key
            {0xcdd, new Tuple<int, int, CurrencyType, CurrencyType>(250, 250, 0, 0) }, // Shatters Key
            {0xcd4, new Tuple<int, int, CurrencyType, CurrencyType>(250, 250, 0, 0) }, // Draconis Key
            {0x2294, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) }, // Shaitan's Key


            {0xc6c, new Tuple<int, int, CurrencyType, CurrencyType>(100, 100, 0, 0) } // Backpack
        };

        // Keys
        public static int[] StoreList1 =
        {
            0x2290, 0x701, 0x705, 0x70a, 0x70b, 0x710, 0x71f,
            0xc11, 0xc19, 0xc23, 0xc2e, 0xc2f, 0xcce, 0xccf,
            0xcda, 0xcdd, 0xcd4, 0x2294
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

        // Rare Eggs & Backpack
        public static int[] StoreList2 =
        {
            0xc6c, 0xc87, 0xc8b, 0xc8f, 0xc93, 0xc97, 0xc9b,
            0xc9f, 0xca3, 0xca7, 0xcab, 0xcaf, 0xcb3, 0xcb7,
            0xcbb, 0xcbf
        };

        public static int[] StoreList20 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

        // Uncommon Eggs & Food
        public static int[] StoreList3 =
        {
            0xccc, 0xccb, 0xcca, 0xcc9, 0xcc8, 0xcc7, 0xcc6,
            0xcc5, 0xcc4
        };

        // Abilities
        public static int[] StoreList4 =
        {
            0xb25, 0xa5b, 0xb22, 0xa0c, 0xb24, 0xa30, 0xb26,
            0xa55, 0xb27, 0xae1, 0xb28, 0xa65, 0xb29, 0xa6b,
            0xb2a, 0xaa8, 0xb2b, 0xaaf, 0xb2c, 0xab6, 0xb2d,
            0xa46, 0xb23, 0xb20, 0xb33, 0xb32, 0xc59, 0xc58
        };

        // Armor
        public static int[] StoreList5 =
        {
            0xb05, 0xa96, 0xa95, 0xa94, 0xa60, 0xafc, 0xa93,
            0xa92, 0xa91, 0xa13, 0xaf9, 0xa90, 0xa8f, 0xa8e,
            0xad3
        };

        // Weapons 1
        public static int[] StoreList6 =
        {
            0xaf6, 0xa87, 0xa86, 0xa85, 0xa07, 0xb02, 0xa8d,
            0xa8c, 0xa8b, 0xa1e, 0xb08, 0xaa2, 0xaa1, 0xaa0,
            0xa9f
        };

        // Weapons 2
        public static int[] StoreList7 =
        {
            0xb0b, 0xa47, 0xa84, 0xa83, 0xa82, 0xaff, 0xa8a,
            0xa89, 0xa88, 0xa19, 0xc50, 0xc4f, 0xc4e, 0xc4d,
            0xc4c
        };

        // Rings
        public static int[] StoreList8 =
        {
            0xabf, 0xac0, 0xac1, 0xac2, 0xac3, 0xac4, 0xac5,
            0xac6, 0xac7, 0xac8, 0xac9, 0xaca, 0xacb, 0xacc,
            0xacd, 0xace
        };

        // Shatters
        public static int[] StoreList9 =
        {
            0xb41, 0xbab, 0xbad, 0xbac
        };

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
                    MerchantPrices.Add(item.Value.ObjectType, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0));
                    clothingDyeList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture2 != 0 && item.Value.ObjectId.Contains("Accessory") && item.Value.Class == "Dye")
                {
                    MerchantPrices.Add(item.Value.ObjectType, new Tuple<int, int, CurrencyType, CurrencyType>(51, 51, 0, 0));
                    accessoryDyeList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture1 != 0 && item.Value.ObjectId.Contains("Cloth") && item.Value.ObjectId.Contains("Large"))
                {
                    MerchantPrices.Add(item.Value.ObjectType, new Tuple<int, int, CurrencyType, CurrencyType>(160, 160, 0, 0));
                    clothingClothList.Add(item.Value.ObjectType);
                }

                if (item.Value.Texture2 != 0 && item.Value.ObjectId.Contains("Cloth") && item.Value.ObjectId.Contains("Small"))
                {
                    MerchantPrices.Add(item.Value.ObjectType, new Tuple<int, int, CurrencyType, CurrencyType>(160, 160, 0, 0));
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
