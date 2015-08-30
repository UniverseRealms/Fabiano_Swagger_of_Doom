#region

using db;
using MySql.Data.MySqlClient;
using System;
using System.Text;

#endregion

namespace server.arena
{
    internal class getRecords : RequestHandler
    {
        protected override void HandleRequest()
        {
            string result = "";
            using (Database dbx = new Database())
            {
                Account acc = dbx.Verify(Query["guid"], Query["password"], Program.GameData);
                if (String.IsNullOrEmpty(Query["guid"]) ||
                    String.IsNullOrEmpty(Query["password"]) ||
                    String.IsNullOrEmpty(Query["type"]) ||
                    acc == null)
                {
                    Context.Response.StatusCode = 400;
                    result = "<Error>Invalid GUID/password combination</Error>";
                }
                else
                {
                    string[][] ranks = dbx.GetArenaLeaderboards(Query["type"], acc);
                    result += "<ArenaRecords>";
                    foreach (string[] i in ranks)
                    {
                        MySqlCommand cmd = dbx.CreateQuery();
                        cmd.CommandText = "select skin, tex1, tex2, items, charType, petId from characters where charid = @charid";
                        cmd.Parameters.AddWithValue("@charid", i[2]);
                        string skin, tex1, tex2, inventory, cclass, petid;
                        skin = tex1 = tex2 = inventory = cclass = petid = null;
                        using (MySqlDataReader drdr = cmd.ExecuteReader())
                        {
                            while (drdr.Read())
                            {
                                skin = drdr.GetString("skin");
                                tex1 = drdr.GetString("tex1");
                                tex2 = drdr.GetString("tex2");
                                inventory = drdr.GetString("items");
                                cclass = drdr.GetString("charType");
                                petid = drdr.GetString("petId");
                            }
                        }

                        var _pet = dbx.GetPet(int.Parse(petid), acc);
                        result += $"<Record><WaveNumber>{i[0]}</WaveNumber><Time>{i[4]}</Time><PlayData><CharacterData>";
                        if (acc.Guild.Name != null) result += $@"<GuildName>{acc.Guild.Name}</GuildName><GuildRank>{acc.Guild.Rank}</GuildRank>";
                        result += $"<Id>{i[2]}</Id><Texture>{skin}</Texture><Tex1>{tex1}</Tex1><Tex2>{tex2}</Tex2><Inventory>{inventory}</Inventory><Name>{acc.Name}</Name><Class>{cclass}</Class></CharacterData>";
                        result += "<Pet name=\"" + _pet.SkinName + "\" type=\"" + _pet.Type + "\" instanceId=\"" + _pet.InstanceId + "\" rarity=\"" + _pet.Rarity + "\" maxAbilityPower=\"" + _pet.MaxAbilityPower + "\" skin=\"" + _pet.Skin + "\" family=\"" + "Farm" + "\"><Abilities>";
                        for (int e = 0; e < 3; e++)
                            result += "<Ability type=\"" + _pet.Abilities[e].Type + "\" power=\"" + _pet.Abilities[e].Power + "\" points=\"" + _pet.Abilities[e].Points + "\"/>";
                        result += "</Abilities></Pet></PlayData></Record>";
                    }
                    result += "</ArenaRecords>";
                }
            }
            byte[] buf = Encoding.UTF8.GetBytes(result);
            Context.Response.ContentType = "text/*";
            Context.Response.OutputStream.Write(buf, 0, buf.Length);
        }
    }
}

//<? xml version="1.0" encoding="UTF-8"?>
//<ArenaRecords>
//    <Record>
//        <WaveNumber>48</WaveNumber>
//        <Time>9118.82</Time>
//        <PlayData>
//            <CharacterData>
//                <GuildName>MAFIA</GuildName>
//                <GuildRank>10</GuildRank>
//                <Id>556</Id>
//                <Texture>853</Texture>
//                <Tex1>33506560</Tex1>
//                <Tex2>33488896</Tex2>
//                <Inventory>9063,3080,2812,2987,-1,-1,-1,2857,-1,2827,8963,3077,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>Pharest</Name>
//                <Class>797</Class>
//            </CharacterData>
//            <Pet name = "{pets.Night_Mare_Skin}" type="32625" instanceId="112" rarity="4" maxAbilityPower="100" skin="32877" family="Farm">
//                <Abilities>
//                    <Ability type = "407" power="100" points="510610" />
//                    <Ability type = "408" power="100" points="511860" />
//                    <Ability type = "406" power="89" points="218191" />
//                </Abilities>
//            </Pet>
//        </PlayData>
//    </Record>
//    <Record>
//        <WaveNumber>48</WaveNumber>
//        <Time>11864.8</Time>
//        <PlayData>
//            <CharacterData>
//                <GuildName>from PrOLAND</GuildName>
//                <GuildRank>30</GuildRank>
//                <Id>129</Id>
//                <Texture>0</Texture>
//                <Tex1>26922290</Tex1>
//                <Tex2>19041058</Tex2>
//                <Inventory>3082,2855,2809,2987,2815,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>LeetScorp</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Baby_Dragon_Skin}" type= "32592" instanceId= "25" rarity= "3" maxAbilityPower= "90" skin= "32844" family= "Reptile" >
//                < Abilities >
//                    < Ability type= "407" power= "84" points= "151954" />
//                    < Ability type= "404" power= "78" points= "95317" />
//                    < Ability type= "408" power= "63" points= "30480" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 47 </ WaveNumber >
//        < Time > 12069.4 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > FellStar </ GuildName >
//                < GuildRank > 30 </ GuildRank >
//                < Id > 384 </ Id >
//                < Texture > 913 </ Texture >
//                < Tex1 > 16777216 </ Tex1 >
//                < Tex2 > 16777216 </ Tex2 >
//                < Inventory > 3113,2855,2809,2987,2815,3106,-1,2650,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>BTEL</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Leprechaun_Skin}" type= "32607" instanceId= "81" rarity= "3" maxAbilityPower= "90" skin= "32859" family= "Humanoid" >
//                < Abilities >
//                    < Ability type= "407" power= "90" points= "239554" />
//                    < Ability type= "408" power= "90" points= "235634" />
//                    < Ability type= "406" power= "76" points= "85664" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 45 </ WaveNumber >
//        < Time > 11309.7 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > TwinStars </ GuildName >
//                < GuildRank > 30 </ GuildRank >
//                < Id > 223 </ Id >
//                < Texture > 0 </ Texture >
//                < Tex1 > 167772202 </ Tex1 >
//                < Tex2 > 83886081 </ Tex2 >
//                < Inventory > 3082,2650,2809,2978,-1,-1,-1,3113,-1,-1,-1,3106,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>Seikon</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Mallard_Skin}" type= "32587" instanceId= "59" rarity= "3" maxAbilityPower= "90" skin= "32839" family= "Farm" >
//                < Abilities >
//                    < Ability type= "407" power= "90" points= "236104" />
//                    < Ability type= "408" power= "90" points= "236255" />
//                    < Ability type= "406" power= "77" points= "89132" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 44 </ WaveNumber >
//        < Time > 7613.42 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > from PrOLAND</GuildName>
//                   < GuildRank > 10 </ GuildRank >
//                   < Id > 469 </ Id >
//                   < Texture > 883 </ Texture >
//                   < Tex1 > 150994958 </ Tex1 >
//                   < Tex2 > 150994958 </ Tex2 >
//                   < Inventory > 3073,2857,2812,2978,3077,3080,3109,2794,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>Kieubasa</Name>
//                <Class>797</Class>
//            </CharacterData>
//            <Pet name = "{pets.Elf_Skin}" type= "32608" instanceId= "64" rarity= "3" maxAbilityPower= "90" skin= "32860" family= "Humanoid" >
//                < Abilities >
//                    < Ability type= "407" power= "77" points= "89554" />
//                    < Ability type= "408" power= "74" points= "68615" />
//                    < Ability type= "410" power= "51" points= "11760" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 44 </ WaveNumber >
//        < Time > 8469.17 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Japan Event Guild</GuildName>
//                <GuildRank>20</GuildRank>
//                <Id>304</Id>
//                <Texture>839</Texture>
//                <Tex1>16777216</Tex1>
//                <Tex2>67108866</Tex2>
//                <Inventory>9063,2850,9060,2977,3109,3109,3109,3109,3109,3109,3073,2827,3109,3109,3109,3109,3109,3109,-1,-1</Inventory>
//                <Name>Kuroino</Name>
//                <Class>798</Class>
//            </CharacterData>
//            <Pet name = "{pets.Phoenix_Skin}" type= "32620" instanceId= "221" rarity= "4" maxAbilityPower= "100" skin= "32872" family= "Avian" >
//                < Abilities >
//                    < Ability type= "408" power= "100" points= "510060" />
//                    < Ability type= "407" power= "100" points= "511502" />
//                    < Ability type= "409" power= "89" points= "218337" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 44 </ WaveNumber >
//        < Time > 11044.1 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Japan Event Guild</GuildName>
//                <GuildRank>20</GuildRank>
//                <Id>287</Id>
//                <Texture>8967</Texture>
//                <Tex1>25198720</Tex1>
//                <Tex2>167772208</Tex2>
//                <Inventory>8962,2857,9015,2984,2563,9063,3169,2978,3105,3105,3109,3109,2828,2828,2828,2828,3109,3109,3109,3109</Inventory>
//                <Name>LoopLine</Name>
//                <Class>797</Class>
//            </CharacterData>
//            <Pet name = "{pets.Black_Wolf_Skin}" type= "32578" instanceId= "213" rarity= "3" maxAbilityPower= "90" skin= "32830" family= "Canine" >
//                < Abilities >
//                    < Ability type= "407" power= "90" points= "235970" />
//                    < Ability type= "408" power= "86" points= "173279" />
//                    < Ability type= "409" power= "71" points= "56734" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 43 </ WaveNumber >
//        < Time > 3579.79 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > NIN GUILD</GuildName>
//                <GuildRank>30</GuildRank>
//                <Id>858</Id>
//                <Texture>839</Texture>
//                <Tex1>25165780</Tex1>
//                <Tex2>32896501</Tex2>
//                <Inventory>9063,3087,3169,2989,-1,-1,-1,-1,-1,-1,-1,-1,-1,2986,8963,8962,-1,2985,9017,9015</Inventory>
//                <Name>Japannnnn</Name>
//                <Class>798</Class>
//            </CharacterData>
//            <Pet name = "{pets.War_Elephant_Skin}" type= "32622" instanceId= "31" rarity= "4" maxAbilityPower= "100" skin= "32874" family= "Exotic" >
//                < Abilities >
//                    < Ability type= "408" power= "100" points= "510610" />
//                    < Ability type= "407" power= "97" points= "424110" />
//                    < Ability type= "406" power= "94" points= "322610" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 43 </ WaveNumber >
//        < Time > 4439.18 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Keepers of Harmony</GuildName>
//                <GuildRank>40</GuildRank>
//                <Id>893</Id>
//                <Texture>883</Texture>
//                <Tex1>167772215</Tex1>
//                <Tex2>150994958</Tex2>
//                <Inventory>2827,3080,2812,2984,2857,3109,2828,2828,2828,3109,2828,3109,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>TFoxt</Name>
//                <Class>797</Class>
//            </CharacterData>
//            <Pet name = "{pets.Mermaid_Skin}" type= "32609" instanceId= "95" rarity= "3" maxAbilityPower= "90" skin= "32861" family= "Humanoid" >
//                < Abilities >
//                    < Ability type= "407" power= "90" points= "237604" />
//                    < Ability type= "408" power= "90" points= "235747" />
//                    < Ability type= "406" power= "89" points= "219122" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 43 </ WaveNumber >
//        < Time > 5313.9 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > The Pinky Ds</GuildName>
//                <GuildRank>40</GuildRank>
//                <Id>165</Id>
//                <Texture>0</Texture>
//                <Tex1>16812939</Tex1>
//                <Tex2>31200316</Tex2>
//                <Inventory>3073,2850,2812,2977,2828,-1,-1,2831,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>Stoppable</Name>
//                <Class>798</Class>
//            </CharacterData>
//            <Pet name = "{pets.Forest_Fairy_Skin}" type= "32642" instanceId= "124" rarity= "4" maxAbilityPower= "100" skin= "32894" family= "Humanoid" >
//                < Abilities >
//                    < Ability type= "407" power= "100" points= "510610" />
//                    < Ability type= "408" power= "100" points= "511860" />
//                    < Ability type= "406" power= "89" points= "218476" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 43 </ WaveNumber >
//        < Time > 10235.4 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Awe Inspiring</GuildName>
//                <GuildRank>10</GuildRank>
//                <Id>597</Id>
//                <Texture>916</Texture>
//                <Tex1>0</Tex1>
//                <Tex2>0</Tex2>
//                <Inventory>3082,2855,3112,2987,3105,3109,2594,2594,2594,2594,2978,2704</Inventory>
//                <Name>Wizardism</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Baby_Dragon_Skin}" type= "32592" instanceId= "6" rarity= "3" maxAbilityPower= "90" skin= "32844" family= "Reptile" >
//                < Abilities >
//                    < Ability type= "407" power= "86" points= "178004" />
//                    < Ability type= "408" power= "82" points= "133326" />
//                    < Ability type= "405" power= "66" points= "38295" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 43 </ WaveNumber >
//        < Time > 12640.3 </ Time >
//        < PlayData >
//            < CharacterData >
//                < Id > 113 </ Id >
//                < Texture > 8967 </ Texture >
//                < Tex1 > 0 </ Tex1 >
//                < Tex2 > 0 </ Tex2 >
//                < Inventory > 3077,2857,3169,2978,3109,-1,-1,3080,3109,-1,-1,3073</Inventory>
//                <Name>Yamaooo</Name>
//                <Class>797</Class>
//            </CharacterData>
//            <Pet name = "{pets.Funkatron_Skin}" type= "32615" instanceId= "38" rarity= "3" maxAbilityPower= "90" skin= "32867" family= "Automaton" >
//                < Abilities >
//                    < Ability type= "406" power= "90" points= "236254" />
//                    < Ability type= "407" power= "84" points= "155025" />
//                    < Ability type= "408" power= "71" points= "55770" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 42 </ WaveNumber >
//        < Time > 7412.71 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Spy </ GuildName >
//                < GuildRank > 40 </ GuildRank >
//                < Id > 601 </ Id >
//                < Texture > 834 </ Texture >
//                < Tex1 > 16777216 </ Tex1 >
//                < Tex2 > 150994944 </ Tex2 >
//                < Inventory > 3082,2855,2809,2978,2815,2650,-1,-1,3106,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>Otipo</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.King_Gorilla_Skin}" type= "32623" instanceId= "166" rarity= "4" maxAbilityPower= "100" skin= "32875" family= "Exotic" >
//                < Abilities >
//                    < Ability type= "408" power= "100" points= "512110" />
//                    < Ability type= "407" power= "100" points= "509165" />
//                    < Ability type= "405" power= "88" points= "209502" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 42 </ WaveNumber >
//        < Time > 7761.08 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Terrestrial </ GuildName >
//                < GuildRank > 40 </ GuildRank >
//                < Id > 154 </ Id >
//                < Texture > 913 </ Texture >
//                < Tex1 > 150994954 </ Tex1 >
//                < Tex2 > 167772170 </ Tex2 >
//                < Inventory > 3082,2785,2809,2978,2815,2764,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>RichDemon</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Elf_Skin}" type= "32608" instanceId= "24" rarity= "3" maxAbilityPower= "90" skin= "32860" family= "Humanoid" >
//                < Abilities >
//                    < Ability type= "407" power= "90" points= "235954" />
//                    < Ability type= "408" power= "85" points= "160561" />
//                    < Ability type= "406" power= "71" points= "55680" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 42 </ WaveNumber >
//        < Time > 9594.55 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > La Renaissance</GuildName>
//                <GuildRank>10</GuildRank>
//                <Id>20</Id>
//                <Texture>0</Texture>
//                <Tex1>167772169</Tex1>
//                <Tex2>150994950</Tex2>
//                <Inventory>8608,2650,2809,2985,2835,3109,3105,-1,-1,-1,-1,-1,3106,8610,-1,3167,2815,2855,-1,-1</Inventory>
//                <Name>Shu</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Gummy_Bear_Skin}" type= "32611" instanceId= "27" rarity= "3" maxAbilityPower= "90" skin= "32863" family= "? ? ? ?" >
//                < Abilities >
//                    < Ability type= "408" power= "90" points= "240354" />
//                    < Ability type= "407" power= "90" points= "235702" />
//                    < Ability type= "406" power= "76" points= "85902" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 42 </ WaveNumber >
//        < Time > 10920.9 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > from PrOLAND</GuildName>
//                   < GuildRank > 30 </ GuildRank >
//                   < Id > 370 </ Id >
//                   < Texture > 0 </ Texture >
//                   < Tex1 > 167772213 </ Tex1 >
//                   < Tex2 > 167772215 </ Tex2 >
//                   < Inventory > 2815,2855,3096,2978,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>Sebeuke</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Orangutan_Skin}" type= "32586" instanceId= "91" rarity= "3" maxAbilityPower= "90" skin= "32838" family= "Exotic" >
//                < Abilities >
//                    < Ability type= "408" power= "74" points= "71404" />
//                    < Ability type= "407" power= "69" points= "47872" />
//                    < Ability type= "402" power= "43" points= "6315" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 41 </ WaveNumber >
//        < Time > 5593.83 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Group NineThreeFive</GuildName>
//                <GuildRank>10</GuildRank>
//                <Id>517</Id>
//                <Texture>855</Texture>
//                <Tex1>67108870</Tex1>
//                <Tex2>167772207</Tex2>
//                <Inventory>3088,2856,3096,2978,3074,2782,3112,2759,3308,-1,-1,-1,-1,-1,2877,3167,-1,-1,-1,2875</Inventory>
//                <Name>MatooWolf</Name>
//                <Class>775</Class>
//            </CharacterData>
//            <Pet name = "{pets.Tandem_Cobra_Skin}" type= "32628" instanceId= "61" rarity= "4" maxAbilityPower= "95" skin= "32880" family= "Reptile" >
//                < Abilities >
//                    < Ability type= "407" power= "95" points= "347673" />
//                    < Ability type= "408" power= "95" points= "347809" />
//                    < Ability type= "406" power= "83" points= "144410" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 41 </ WaveNumber >
//        < Time > 5725.31 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Infuse </ GuildName >
//                < GuildRank > 30 </ GuildRank >
//                < Id > 912 </ Id >
//                < Texture > 8964 </ Texture >
//                < Tex1 > 83886084 </ Tex1 >
//                < Tex2 > 83886084 </ Tex2 >
//                < Inventory > 3077,2850,2812,2985,2563,3109,-1,-1,8963,3109,-1,-1,2594,2594,2594,2594,2594,2594,2594,2594</Inventory>
//                <Name>XBlueNeonX</Name>
//                <Class>798</Class>
//            </CharacterData>
//            <Pet name = "{pets.Raven_Skin}" type= "32581" instanceId= "9" rarity= "3" maxAbilityPower= "90" skin= "32833" family= "Avian" >
//                < Abilities >
//                    < Ability type= "408" power= "90" points= "235754" />
//                    < Ability type= "407" power= "88" points= "203646" />
//                    < Ability type= "405" power= "74" points= "70750" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 41 </ WaveNumber >
//        < Time > 5995.92 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > The Realm Elites</GuildName>
//                <GuildRank>40</GuildRank>
//                <Id>888</Id>
//                <Texture>913</Texture>
//                <Tex1>167772208</Tex1>
//                <Tex2>167772208</Tex2>
//                <Inventory>3082,2855,2809,2989,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>Kmoelite</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Enraged_Yack_Skin}" type= "32624" instanceId= "151" rarity= "4" maxAbilityPower= "100" skin= "32876" family= "Farm" >
//                < Abilities >
//                    < Ability type= "407" power= "100" points= "509632" />
//                    < Ability type= "408" power= "96" points= "379073" />
//                    < Ability type= "406" power= "84" points= "152152" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//    < Record >
//        < WaveNumber > 41 </ WaveNumber >
//        < Time > 7786.08 </ Time >
//        < PlayData >
//            < CharacterData >
//                < GuildName > Night Owls</GuildName>
//                <GuildRank>30</GuildRank>
//                <Id>578</Id>
//                <Texture>0</Texture>
//                <Tex1>0</Tex1>
//                <Tex2>0</Tex2>
//                <Inventory>3082,2650,2809,2978,2815,2785,3105,-1,3098,3098,3098,3098,3109,3105,-1,-1,-1,-1,-1,-1</Inventory>
//                <Name>Wylem</Name>
//                <Class>768</Class>
//            </CharacterData>
//            <Pet name = "{pets.Baby_Dragon_Skin}" type= "32592" instanceId= "151" rarity= "3" maxAbilityPower= "90" skin= "32844" >
//                < Abilities >
//                    < Ability type= "407" power= "85" points= "160504" />
//                    < Ability type= "408" power= "81" points= "121951" />
//                    < Ability type= "406" power= "64" points= "33045" />
//                </ Abilities >
//            </ Pet >
//        </ PlayData >
//    </ Record >
//</ ArenaRecords >