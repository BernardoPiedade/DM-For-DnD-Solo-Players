﻿using System;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;
using System.Drawing;

namespace DnD_SoloPlayers
{
    public partial class Form1 : Form
    {
        static string version = "";
        static string actualVersion = "1.4.1";
        static string checkId = "";
        static string lang = "English";

        public Form1()
        {
            InitializeComponent();

            try
            {
                string ConnectionString = "Server=remotemysql.com; Port=3306; Database=Pfw7lneUyi; Uid=Pfw7lneUyi; Pwd=aZmR4ahZS2";

                using (MySqlConnection conn = new MySqlConnection(ConnectionString))
                {
                    conn.Open();

                    XmlDocument userid = new XmlDocument();
                    userid.Load(filename: "xml\\user\\userId.xml");

                    XmlNodeList idX = userid.GetElementsByTagName("userId");

                    foreach (XmlNode node in idX)
                    {
                        checkId = node.InnerText;
                    }

                    UserID_Number.Text = checkId;

                    if (checkId.Equals("") || checkId.Equals(" "))
                    {
                        Random uid = new Random();

                        int id = uid.Next(0, 999999999);
                        string ConvertId = id.ToString();

                        foreach (XmlNode node in idX)
                        {
                            node.InnerText = ConvertId;
                        }

                        userid.Save(filename: "xml\\user\\userid.xml");

                        MySqlCommand insert = new MySqlCommand("INSERT INTO usageTrack (id, usedTimes) VALUES ("+ConvertId+","+1+")",conn);
                        insert.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        using (MySqlCommand select = new MySqlCommand("SELECT usedTimes FROM usageTrack WHERE id="+checkId+"",conn))
                        {
                            MySqlDataReader reader = select.ExecuteReader();
                            int getUsedTimes = 0;
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    getUsedTimes = (int)reader["usedTimes"];
                                }
                            }

                            reader.Close();

                            int updateUsedTimes = getUsedTimes + 1;

                            MySqlCommand update = new MySqlCommand("UPDATE usageTrack SET usedTimes="+updateUsedTimes+" WHERE id="+checkId+"",conn);
                            update.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                }                
            }
            catch
            {
            }

            try
            {
                string a = "https://dndoracle.com/DnD_SoloPlayers/version.xml";

                XmlDocument versionxml = new XmlDocument();
                versionxml.Load(a);

                XmlNodeList nodeList = versionxml.GetElementsByTagName("version");
               
                foreach (XmlNode node in nodeList)
                {
                    version = node.InnerText;
                }
                
                if (version.Equals(actualVersion))
                {
                    Version_Update_MSG.Text = version;
                    B_Update.Visible = false;
                }
                else
                {
                    Version_Update_MSG.Text = "New update available!";
                    B_Update.Visible = true;
                }

                
            }
            catch
            {
                Version_Update_MSG.Text = "Couldn't connect with the server...";
                Whats_New_Button.Visible = false;
            }

            try
            {
                if(B_Update.Visible == false)
                {
                    XmlDocument showBox = new XmlDocument();
                    showBox.Load(filename: "xml\\updates.xml");

                    XmlNodeList showBoxNodeList = showBox.GetElementsByTagName("open");
                    string open = "";
                    string b = "false";

                    if (open.Equals(""))
                    {
                        foreach (XmlNode node in showBoxNodeList)
                        {
                            open = node.InnerText;
                        }

                        if (open.Equals("true"))
                        {
                            foreach (XmlNode node in showBoxNodeList)
                            {
                                node.InnerText = b;
                            }
                            showBox.Save(filename: "xml\\updates.xml");
                            new Updates_Panel().Show();
                        }
                    }
                }
            }
            catch
            {
                
            }

            //change button color

            OracleMenu_Button.BackColor = SystemColors.ControlDarkDark;
            PlayerMenu_Button.BackColor = SystemColors.AppWorkspace;
            MoreMenu_Button.BackColor = SystemColors.AppWorkspace;

            //setting visible items

            //not visible
            Player_Label.Visible = false;
            PlayerSheet_Button.Visible = false;
            DiceBag_Label.Visible = false;
            DB_Roll.Visible = false;
            DB_Roll_Time.Visible = false;
            Whats_New_Button.Visible = false;
            B_OW.Visible = false;
            Reddit_B.Visible = false;
            Documentation_B.Visible = false;

            //Visible
            Hooks_Label.Visible = true;
            CH_Town.Visible = true;
            AH_Town.Visible = true;
            Hooks_CustomSearch_B.Visible = true;
            SideQuests_Label.Visible = true;
            SQ_Town_Village.Visible = true;
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
            Version_Label.Visible = true;
            Version_Update_MSG.Visible = true;
            UserId_Label.Visible = true;
            UserID_Number.Visible = true;
            SD_Custom_Quests.Visible = true;
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
            string owUrl = "https://dndoracle.com/";

            System.Diagnostics.Process.Start(owUrl);
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
            DiceBag_Label.Visible = false;
            DB_Roll.Visible = false;
            DB_Roll_Time.Visible = false;
            Whats_New_Button.Visible = false;
            B_OW.Visible = false;
            Reddit_B.Visible = false;
            Documentation_B.Visible = false;

            //Visible
            Hooks_Label.Visible = true;
            CH_Town.Visible = true;
            AH_Town.Visible = true;
            Hooks_CustomSearch_B.Visible = true;
            SideQuests_Label.Visible = true;
            SQ_Town_Village.Visible = true;
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
            Version_Label.Visible = true;
            Version_Update_MSG.Visible = true;
            UserId_Label.Visible = true;
            UserID_Number.Visible = true;
            SD_Custom_Quests.Visible = true;
            if (version.Equals(actualVersion))
            {
                Version_Update_MSG.Text = version;
                B_Update.Visible = false;
            }
            else
            {
                Version_Update_MSG.Text = "New update available!";
                B_Update.Visible = true;
            }
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
            Whats_New_Button.Visible = false;
            B_OW.Visible = false;
            Reddit_B.Visible = false;
            Documentation_B.Visible = false;
            SD_Custom_Quests.Visible = false;

            //visible
            DiceBag_Label.Visible = true;
            DB_Roll.Visible = true;
            DB_Roll_Time.Visible = true;
            Player_Label.Visible = true;
            PlayerSheet_Button.Visible = true;
            Version_Label.Visible = true;
            Version_Update_MSG.Visible = true;
            UserId_Label.Visible = true;
            UserID_Number.Visible = true;
            if (version.Equals(actualVersion))
            {
                Version_Update_MSG.Text = version;
                B_Update.Visible = false;
            }
            else
            {
                Version_Update_MSG.Text = "New update available!";
                B_Update.Visible = true;
            }
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
            DiceBag_Label.Visible = false;
            DB_Roll.Visible = false;
            DB_Roll_Time.Visible = false;
            Player_Label.Visible = false;
            PlayerSheet_Button.Visible = false;
            SD_Custom_Quests.Visible = false;

            //visible
            Version_Label.Visible = true;
            Version_Update_MSG.Visible = true;
            Whats_New_Button.Visible = true;
            B_OW.Visible = true;
            UserId_Label.Visible = true;
            UserID_Number.Visible = true;
            Reddit_B.Visible = true;
            Documentation_B.Visible = true;
            if (version.Equals(actualVersion))
            {
                Version_Update_MSG.Text = version;
                B_Update.Visible = false;
            }
            else
            {
                Version_Update_MSG.Text = "New update available!";
                B_Update.Visible = true;
            }
        }

        private void Reddit_B_Click(object sender, EventArgs e)
        {
            string RUrl = "https://www.reddit.com/r/DndOracle/";

            System.Diagnostics.Process.Start(RUrl);
        }

        private void Documentation_B_Click(object sender, EventArgs e)
        {
            string DocUrl = "https://dndoracle.com/documentation.html";

            System.Diagnostics.Process.Start(DocUrl);
        }

        private void SD_Custom_Quests_Click(object sender, EventArgs e) => new SD_Custom_Quests().Show();
    }
}