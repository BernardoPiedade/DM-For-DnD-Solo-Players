﻿using System;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.IO;

namespace DnD_SoloPlayers
{
    public partial class Form1 : Form
    {
        static string version = "";
        static string actualVersion = "2.0.0";
        static string checkId = "";

        static string lang = "";
        

        public Form1()
        {
            InitializeComponent();

            try
            {

                Version_Update_MSG.Text = "2.0.0";
                B_Update.Visible = false;


            }
            catch
            {
                Version_Update_MSG.Text = "Couldn't connect with the server...";
                Whats_New_Button.Visible = false;
            }

            //change button color

            OracleMenu_Button.BackColor = SystemColors.ControlDarkDark;
            PlayerMenu_Button.BackColor = SystemColors.AppWorkspace;
            MoreMenu_Button.BackColor = SystemColors.AppWorkspace;

            //setting visible items

            //not visible
            Player_Label.Visible = false;
            PlayerSheet_Button.Visible = false;
            Pet_Sheet_Button.Visible = false;
            P_Spell_List_Button.Visible = false;
            DiceBag_Label.Visible = false;
            DB_Roll.Visible = false;
            DB_Roll_Time.Visible = false;
            Whats_New_Button.Visible = false;
            B_OW.Visible = false;
            Reddit_B.Visible = false;
            Documentation_B.Visible = false;
            Instagram_B.Visible = false;
            Twitter_B.Visible = false;
            choose_Language.Visible = false;
            Lang_Label.Visible = false;

            //Visible
            Hooks_Label.Visible = true;
            CH_Town.Visible = true;
            AH_Town.Visible = true;
            Hooks_CustomSearch_B.Visible = true;
            SideQuests_Label.Visible = true;
            SQ_Town_Village.Visible = true;
            SQ_My_Quests.Visible = true;
            RE_Label.Visible = true;
            RE_Dungeon.Visible = true;
            RE_Desert.Visible = true;
            RE_Forest.Visible = true;
            RE_Beach.Visible = true;
            RNPC_Label.Visible = true;
            RNPC.Visible = true;
            NPC_CustomSearch.Visible = true;
            DiceYesNo_Label.Visible = true;
            DiceRoll.Visible = true;
            Items_Label.Visible = true;
            I_Magical.Visible = true;
            I_BlackMarket.Visible = true;
            I_Weaponsmith.Visible = true;
            I_Armorsmith.Visible = true;
            Version_Label.Visible = true;
            Version_Update_MSG.Visible = true;
            UserId_Label.Visible = true;
            UserID_Number.Visible = true;
            SQ_Online_Quests.Visible = true;
            Infinite_Dungeon_Crawler_Label.Visible = true;
            Enter_Dungeon_Crawler_Button.Visible = true;

            UserID_Number.Text = checkId;

            // Create Img folder with images for Battle Map

            string folderPath = @"img\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string Player_Img_File = "player.png";
            string Monster_Img_File = "Monster.png";

            if (File.Exists(Player_Img_File) && File.Exists(Monster_Img_File))
            {
                File.Move(Player_Img_File, folderPath+"\\"+Player_Img_File);
                File.Move(Monster_Img_File, folderPath+"\\"+Monster_Img_File);
            }

            // Create Configs folder

            string configFolderPath = @"configs\";
            if (!Directory.Exists(configFolderPath))
            {
                Directory.CreateDirectory(configFolderPath);
            }

            // Create language config file

            string languageConfigFile = @"configs\language.conf";
            string lang = "";

            if (!File.Exists(languageConfigFile))
            {
                using (StreamWriter sw = File.CreateText(languageConfigFile))
                {
                    sw.Write("0");
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(languageConfigFile))
                {
                    lang = sr.ReadLine();
                }
            }

            // Set Language

            choose_Language.Items.Add("en");
            choose_Language.Items.Add("pt");

            if(lang == "0")
            {
                choose_Language.Text = "en";
            }
            else
            {
                choose_Language.Text = "pt";
            }

            setLanguage();
        }

        private void AH_Town_Click(object sender, EventArgs e) => new AH().Show();

        private void CH_Town_Click(object sender, EventArgs e) => new CH().Show();

        private void RE_Dungeon_Click(object sender, EventArgs e) => new RE_Dungeon().Show();

        private void RNPC_Click(object sender, EventArgs e) => new RNPC().Show();

        private void DiceRoll_Click(object sender, EventArgs e) => new DiceRoll().Show();

        private void B_Update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To update, simply run the update.exe.\nPlease close the program first.","New update!");
        }

        private void PlayerSheet_Button_Click(object sender, EventArgs e) => new P_Sheet().Show();

        private void B_OW_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The website no longer exists");
        }

        private void RE_Forest_Click(object sender, EventArgs e) => new RE_Forest().Show();

        private void RE_Desert_Click(object sender, EventArgs e) => new RE_Desert().Show();

        private void SQ_Town_Village_Click(object sender, EventArgs e) => new SQ_Town_Village().Show();

        private void RE_Beach_Click(object sender, EventArgs e) => new RE_Beach().Show();

        private void I_Magical_Click(object sender, EventArgs e) => new I_Magical().Show();

        private void I_BlackMarket_Click(object sender, EventArgs e) => new I_BlackMarket().Show();

        private void DB_Roll_Click(object sender, EventArgs e) => new DB_Roll().Show();

        private void I_Weaponsmith_Click(object sender, EventArgs e) => new I_Weaponsmith().Show();

        private void DB_Roll_Time_Click(object sender, EventArgs e) => new DB_Roll_Time().Show();

        private void Whats_New_Button_Click(object sender, EventArgs e) => new Updates_Panel().Show();

        private void Hooks_CustomSearch_B_Click(object sender, EventArgs e) => new Hooks_CustomSearch().Show();

        private void NPC_CustomSearch_Click(object sender, EventArgs e) => new NPC_CustomSearch().Show();

        private void OracleMenu_Button_Click(object sender, EventArgs e)
        {
            //change button color

            OracleMenu_Button.BackColor = SystemColors.ControlDarkDark;
            PlayerMenu_Button.BackColor = SystemColors.AppWorkspace;
            MoreMenu_Button.BackColor = SystemColors.AppWorkspace;

            //not visible
            Player_Label.Visible = false;
            PlayerSheet_Button.Visible = false;
            P_Spell_List_Button.Visible = false;
            Pet_Sheet_Button.Visible = false;
            DiceBag_Label.Visible = false;
            DB_Roll.Visible = false;
            DB_Roll_Time.Visible = false;
            Whats_New_Button.Visible = false;
            B_OW.Visible = false;
            Reddit_B.Visible = false;
            Documentation_B.Visible = false;
            Instagram_B.Visible = false;
            Twitter_B.Visible = false;
            choose_Language.Visible = false;
            Lang_Label.Visible = false;

            //Visible
            Hooks_Label.Visible = true;
            CH_Town.Visible = true;
            AH_Town.Visible = true;
            Hooks_CustomSearch_B.Visible = true;
            SideQuests_Label.Visible = true;
            SQ_Town_Village.Visible = true;
            SQ_My_Quests.Visible = true;
            RE_Label.Visible = true;
            RE_Dungeon.Visible = true;
            RE_Desert.Visible = true;
            RE_Forest.Visible = true;
            RE_Beach.Visible = true;
            RNPC_Label.Visible = true;
            RNPC.Visible = true;
            NPC_CustomSearch.Visible = true;
            DiceYesNo_Label.Visible = true;
            DiceRoll.Visible = true;
            Items_Label.Visible = true;
            I_Magical.Visible = true;
            I_BlackMarket.Visible = true;
            I_Weaponsmith.Visible = true;
            I_Armorsmith.Visible = true;
            Version_Label.Visible = true;
            Version_Update_MSG.Visible = true;
            UserId_Label.Visible = true;
            UserID_Number.Visible = true;
            SQ_Online_Quests.Visible = true;
            Infinite_Dungeon_Crawler_Label.Visible = true;
            Enter_Dungeon_Crawler_Button.Visible = true;
            
        }

        private void PlayerMenu_Button_Click(object sender, EventArgs e)
        {
            //change button color

            PlayerMenu_Button.BackColor = SystemColors.ControlDarkDark;
            OracleMenu_Button.BackColor = SystemColors.AppWorkspace;
            MoreMenu_Button.BackColor = SystemColors.AppWorkspace;

            //Not visible
            Hooks_Label.Visible = false;
            CH_Town.Visible = false;
            AH_Town.Visible = false;
            Hooks_CustomSearch_B.Visible = false;
            SideQuests_Label.Visible = false;
            SQ_Town_Village.Visible = false;
            SQ_My_Quests.Visible = false;
            RE_Label.Visible = false;
            RE_Dungeon.Visible = false;
            RE_Forest.Visible = false;
            RE_Desert.Visible = false;
            RE_Beach.Visible = false;
            RNPC_Label.Visible = false;
            RNPC.Visible = false;
            NPC_CustomSearch.Visible = false;
            DiceYesNo_Label.Visible = false;
            DiceRoll.Visible = false;
            Items_Label.Visible = false;
            I_Magical.Visible = false;
            I_BlackMarket.Visible = false;
            I_Weaponsmith.Visible = false;
            I_Armorsmith.Visible = false;
            Whats_New_Button.Visible = false;
            B_OW.Visible = false;
            Reddit_B.Visible = false;
            Documentation_B.Visible = false;
            SQ_Online_Quests.Visible = false;
            Instagram_B.Visible = false;
            Twitter_B.Visible = false;
            Infinite_Dungeon_Crawler_Label.Visible = false;
            Enter_Dungeon_Crawler_Button.Visible = false;
            choose_Language.Visible = false;
            Lang_Label.Visible = false;

            //visible
            DiceBag_Label.Visible = true;
            DB_Roll.Visible = true;
            DB_Roll_Time.Visible = true;
            Player_Label.Visible = true;
            PlayerSheet_Button.Visible = true;
            P_Spell_List_Button.Visible = false;
            Pet_Sheet_Button.Visible = true;
            Version_Label.Visible = true;
            Version_Update_MSG.Visible = true;
            UserId_Label.Visible = true;
            UserID_Number.Visible = true;
           
        }

        private void MoreMenu_Button_Click(object sender, EventArgs e)
        {
            //change button color

            MoreMenu_Button.BackColor = SystemColors.ControlDarkDark;
            PlayerMenu_Button.BackColor = SystemColors.AppWorkspace;
            OracleMenu_Button.BackColor = SystemColors.AppWorkspace;

            //not visible
            Hooks_Label.Visible = false;
            CH_Town.Visible = false;
            AH_Town.Visible = false;
            Hooks_CustomSearch_B.Visible = false;
            SideQuests_Label.Visible = false;
            SQ_Town_Village.Visible = false;
            SQ_My_Quests.Visible = false;
            RE_Label.Visible = false;
            RE_Dungeon.Visible = false;
            RE_Forest.Visible = false;
            RE_Desert.Visible = false;
            RE_Beach.Visible = false;
            RNPC_Label.Visible = false;
            RNPC.Visible = false;
            NPC_CustomSearch.Visible = false;
            DiceYesNo_Label.Visible = false;
            DiceRoll.Visible = false;
            Items_Label.Visible = false;
            I_Magical.Visible = false;
            I_BlackMarket.Visible = false;
            I_Weaponsmith.Visible = false;
            I_Armorsmith.Visible = false;
            DiceBag_Label.Visible = false;
            DB_Roll.Visible = false;
            DB_Roll_Time.Visible = false;
            Player_Label.Visible = false;
            PlayerSheet_Button.Visible = false;
            P_Spell_List_Button.Visible = false;
            Pet_Sheet_Button.Visible = false;
            SQ_Online_Quests.Visible = false;
            Infinite_Dungeon_Crawler_Label.Visible = false;
            Enter_Dungeon_Crawler_Button.Visible = false;

            //visible
            Version_Label.Visible = true;
            Version_Update_MSG.Visible = true;
            Whats_New_Button.Visible = true;
            B_OW.Visible = true;
            UserId_Label.Visible = true;
            UserID_Number.Visible = true;
            Reddit_B.Visible = true;
            Documentation_B.Visible = true;
            Instagram_B.Visible = true;
            Twitter_B.Visible = true;
            choose_Language.Visible = true;
            Lang_Label.Visible = true;
            
        }

        private void Reddit_B_Click(object sender, EventArgs e)
        {
            string RUrl = "https://www.reddit.com/r/DndOracle/";

            System.Diagnostics.Process.Start(RUrl);
        }

        private void Documentation_B_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The website no longer exists");
        }

        private void SQ_Online_Quests_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This doesn't work anymore. There's no database");
        }

        private void Pet_Sheet_Button_Click(object sender, EventArgs e) => new Pet_Sheet().Show();

        private void P_Spell_List_Button_Click(object sender, EventArgs e) => new Spell_List().Show();

        private void I_Armorsmith_Click(object sender, EventArgs e) => new I_Armorsmith().Show();

        private void SQ_My_Quests_Click(object sender, EventArgs e) => new SQ_My_Quests().Show();

        private void Twitter_B_Click(object sender, EventArgs e)
        {
            string TwiUrl = "https://twitter.com/DndSoloPlayers";

            System.Diagnostics.Process.Start(TwiUrl);
        }

        private void Instagram_B_Click(object sender, EventArgs e)
        {
            string InsUrl = "https://www.instagram.com/dndsoloplayers/";

            System.Diagnostics.Process.Start(InsUrl);
        }

        private void Enter_Dungeon_Crawler_Button_Click(object sender, EventArgs e) => new Dungeon_Crawler().Show();

        private void choose_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            lang = choose_Language.SelectedIndex.ToString();
            choose_Language.Text = choose_Language.SelectedIndex.ToString();

            File.WriteAllText(@"configs\language.conf", lang);

            setLanguage();
        }

        private void setLanguage()
        {
            if(lang == "1")
            {
                //Menu Oracle

                //Hooks
                CH_Town.Text = "Campanha";
                AH_Town.Text = "Aventura";
                Hooks_CustomSearch_B.Text = "Pesquisa Personalizada";
                //Custom Search Design
                Hooks_CustomSearch_B.Width = 81;
                Hooks_CustomSearch_B.Height = 35;
                Hooks_CustomSearch_B.Left = 156;
                Hooks_CustomSearch_B.Top = 83;

                //Side Quests
                SideQuests_Label.Text = "Missões Secundárias";
                //Side Quests Design
                SideQuests_Label.Left = 298;
                SideQuests_Label.Top = 9;

                SQ_Town_Village.Text = "Cidade / Vila";
                SQ_My_Quests.Text = "Missões";
                SQ_Online_Quests.Text = "Missões Online";

                //Random Encounter
                RE_Label.Text = "Encontro Aleatório";
                RE_Dungeon.Text = "Masmorra";
                RE_Forest.Text = "Floresta";
                RE_Desert.Text = "Deserto";
                RE_Beach.Text = "Praia";

                //Random NPC
                RNPC_Label.Text = "NPC Aleatório";
                NPC_CustomSearch.Text = "Pesquisa Personalizada";
                //Custom Search Design
                NPC_CustomSearch.Width = 81;
                NPC_CustomSearch.Height = 35;
                NPC_CustomSearch.Left = 669;
                NPC_CustomSearch.Top = 54;
                

                //Items
                Items_Label.Text = "Itens";
                I_Magical.Text = "Mágicos";
                I_BlackMarket.Text = "Mercado Negro";
                //Black Market Design
                I_BlackMarket.Width = 90;
                I_BlackMarket.Height = 23;
                I_BlackMarket.Left = 210;
                I_BlackMarket.Top = 198;

                I_Weaponsmith.Text = "Armeiro";
                I_Armorsmith.Text = "Armoreiro";

                //1D6 for yes or no questions
                DiceYesNo_Label.Text = "1D6 para perguntas sim e não";

                //Battle Map
                Infinite_Dungeon_Crawler_Label.Text = "Mapa de Batalha";
                //Battle Map Design
                Infinite_Dungeon_Crawler_Label.Left = 650;
                Infinite_Dungeon_Crawler_Label.Top = 182;

                Enter_Dungeon_Crawler_Button.Text = "Entrar";

                //Menu Player

                //Player
                Player_Label.Text = "Jogador";
                //Player label Design
                Player_Label.Left = 215;
                Player_Label.Top = 108;

                PlayerSheet_Button.Text = "Folha";
                Pet_Sheet_Button.Text = "Animal";

                //Dice Bag
                DiceBag_Label.Text = "Saco de Dados";
                //Dice Bag label Design
                DiceBag_Label.Left = 588;
                DiceBag_Label.Top = 108;

                DB_Roll_Time.Text = "Roll para tempo";
                //Roll for time Design
                DB_Roll_Time.Width = 90;
                DB_Roll_Time.Height = 23;
                DB_Roll_Time.Left = 587;
                DB_Roll_Time.Top = 153;

                //Menu More
                Lang_Label.Text = "Linguagem";

                //version
                Version_Label.Text = "Versão:";


                //Menus
                
                //Oracle
                OracleMenu_Button.Text = "Oráculo";

                //Player
                PlayerMenu_Button.Text = "Jogador";

                //More
                MoreMenu_Button.Text = "Mais";

            }else if(lang == "0")
            {
                //Menu Oracle

                //Hooks
                CH_Town.Text = "Campaign";
                AH_Town.Text = "Adventure";
                Hooks_CustomSearch_B.Text = "Custom Search";
                //Custom Search Design
                Hooks_CustomSearch_B.Width = 75;
                Hooks_CustomSearch_B.Height = 35;
                Hooks_CustomSearch_B.Left = 159;
                Hooks_CustomSearch_B.Top = 83;

                //Side Quests
                SideQuests_Label.Text = "Side Quests";
                //Side Quests Design
                SideQuests_Label.Left = 320;
                SideQuests_Label.Top = 9;

                SQ_Town_Village.Text = "Town / Village";
                SQ_My_Quests.Text = "My Quests";
                SQ_Online_Quests.Text = "Online Quests";

                //Random Encounter
                RE_Label.Text = "Random Encounter";
                RE_Dungeon.Text = "Dungeon";
                RE_Forest.Text = "Forest";
                RE_Desert.Text = "Desert";
                RE_Beach.Text = "Beach";

                //Random NPC
                RNPC_Label.Text = "Random NPC";
                NPC_CustomSearch.Text = "Custom Search";
                //Custom Search Design
                NPC_CustomSearch.Width = 75;
                NPC_CustomSearch.Height = 35;
                NPC_CustomSearch.Left = 672;
                NPC_CustomSearch.Top = 54;

                //Items
                Items_Label.Text = "Items";
                I_Magical.Text = "Magical";
                I_BlackMarket.Text = "Black Market";
                //Black Market Design
                I_BlackMarket.Width = 86;
                I_BlackMarket.Height = 23;
                I_BlackMarket.Left = 212;
                I_BlackMarket.Top = 198;

                I_Weaponsmith.Text = "Weaponsmith";
                I_Armorsmith.Text = "Armorsmith";

                //1D6 for yes or no questions
                DiceYesNo_Label.Text = "1D6 for yes or no questions";

                //Battle Map
                Infinite_Dungeon_Crawler_Label.Text = "Battle Map";
                //Battle Map label Design
                Infinite_Dungeon_Crawler_Label.Left = 667;
                Infinite_Dungeon_Crawler_Label.Top = 182;

                Enter_Dungeon_Crawler_Button.Text = "Enter";

                //Menu Player

                //Player
                Player_Label.Text = "Player";
                //Player label Design
                Player_Label.Left = 220;
                Player_Label.Top = 108;

                PlayerSheet_Button.Text = "sheet";
                Pet_Sheet_Button.Text = "Pet";

                //Dice Bag
                DiceBag_Label.Text = "Dice Bag";
                //Dice Bag label Design
                DiceBag_Label.Left = 606;
                DiceBag_Label.Top = 108;

                DB_Roll_Time.Text = "Roll for time";
                //Roll for time Design
                DB_Roll_Time.Width = 80;
                DB_Roll_Time.Height = 23;
                DB_Roll_Time.Left = 593;
                DB_Roll_Time.Top = 153;

                //Menu More
                Lang_Label.Text = "Language";

                //version
                Version_Label.Text = "Version:";


                //Menus

                //Oracle
                OracleMenu_Button.Text = "Oracle";

                //Player
                PlayerMenu_Button.Text = "Player";

                //More
                MoreMenu_Button.Text = "More";
            }
        }
    }
}
