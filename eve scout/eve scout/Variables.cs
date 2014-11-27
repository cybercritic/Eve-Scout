using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace eve_scout
{
    class Variables
    {
        private enum Element { none, eve_path, auto_start_log, auto_start_eve, update_local, view_options, view_local, view_xml, view_hotlist,
                               play_alarm, auto_save, hotlist}

        public string assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public string currentEveFolder { get; set; }
        public string appDirectory { get; set; }

        public bool autoStartLog { get; set; }
        public bool autoStartEve { get; set; }
        public bool viewOptions { get; set; }
        public bool viewLocal { get; set; }
        public bool viewXML { get; set; }
        public bool viewHotlist { get; set; }
        public bool playAlarm { get; set; }
        public bool autoSave { get; set; }
        public bool hotlistOnly { get; set; }

        public int updateLocal { get; set; }
        public string currentSystem { get; set; }


        public volatile List<PlayerInfo> players;
        public List<string> possibleEveFolders { get; set; }
        public List<string> hotList { get; set; }

        public EventHandler<AlarmEventArgs> RaiseAlarmEvent;
        public eve_scout.MainWindow.RefreshList refreshList; 

        public Variables()
        {
            this.possibleEveFolders = new List<string>();
            this.possibleEveFolders.Add("C:\\Program Files (x86)\\CCP\\EVE");
            this.possibleEveFolders.Add("C:\\Program Files\\CCP\\EVE");
            this.possibleEveFolders.Add("C:\\Program Files (x86)\\steam\\steamapps\\common\\EVE Online");
            this.possibleEveFolders.Add("C:\\Program Files\\steam\\steamapps\\common\\EVE Online");

            appDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            appDirectory += "/cybercritics";
            Directory.CreateDirectory(appDirectory);
            appDirectory += "/eve scout";
            Directory.CreateDirectory(appDirectory);

            this.autoStartEve = false;
            this.autoStartLog = true;
            this.autoSave = false;
            this.hotlistOnly = false;
            this.playAlarm = true;
            this.viewHotlist = true;
            this.viewLocal = true;
            this.viewOptions = true;
            this.viewXML = true;
            this.updateLocal = 10;
            this.readSettingsXML();
            
            //this.players = new List<PlayerInfo>();
            this.players = new List<PlayerInfo>();
            this.currentSystem = "";

            if (this.updateLocal <= 0)
                this.updateLocal = 2;

            this.hotList = new List<string>();
            try { this.hotList.AddRange(File.ReadAllLines(this.appDirectory + "/hotlist.txt")); }
            catch { }
        }

        public List<PlayerInfo> ParseLogFile(string filename)
        {
            List<PlayerInfo> result = new List<PlayerInfo>();

            if (filename == null || filename.Length <= 0)
                return null;

            string content = "";
            if (File.Exists(filename))
                content = File.ReadAllText(filename);
            
            content = Regex.Replace(content, @"[^\u0000-\u007F]", string.Empty);

            string contentCopy = content;

            while (true)
            {
                int begin = content.IndexOf("LSC: OnLSC with locals=");
                if (begin < 0)
                    break;

                content = content.Remove(0, begin);
                int mStart = content.IndexOf("{");
                int mEnd = content.IndexOf("}") + 1;

                string message = content.Substring(mStart, mEnd - mStart);
                content = content.Substring(mEnd);

                int aStart = message.IndexOf("(") + 1;
                int aEnd = message.IndexOf(",",aStart);
                string alliance = message.Substring(aStart, aEnd - aStart);

                int cStart = message.IndexOf("(");
                cStart = message.IndexOf(",", cStart + 1) + 2;
                int cEnd = message.IndexOf(",", cStart + 1);
                string corpID = message.Substring(cStart, cEnd - cStart);

                int uStart = message.IndexOf("[");
                int uEnd = message.IndexOf("]") + 1;
                string userSec = message.Substring(uStart, uEnd - uStart);
                message = message.Substring(uEnd);

                int nStart = userSec.IndexOf("u'");
                if(nStart < 0)
                    nStart = userSec.IndexOf("u\"");
                nStart += 2;
                int nEnd = userSec.LastIndexOf("',");
                if(nEnd < 0)
                    nEnd = userSec.LastIndexOf("\",");
                string user = "";
                try { user = userSec.Substring(nStart, nEnd - nStart); }
                catch { continue; }

                int iStart = 1;
                int iEnd = userSec.IndexOf(",");
                string userID = userSec.Substring(iStart, iEnd - iStart);

                int sAnc = message.IndexOf("solarsystemid2");
                if (sAnc < 0)
                    continue;
                int sStart = message.IndexOf(",", sAnc + 1) + 2;
                int sEnd = message.IndexOf(")", sStart);
                if (sEnd < 0)
                    continue;
                string systemID = message.Substring(sStart, sEnd - sStart);

                bool join = message.IndexOf("Join") != -1 ? true : false;

                PlayerInfo player = new PlayerInfo(user, join, systemID, userID, corpID, alliance);
                player.player__name = Regex.Replace(player.player__name, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                player.userID = Regex.Replace(player.userID, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                player.corpID = Regex.Replace(player.corpID, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                player.allianceID = Regex.Replace(player.allianceID, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                player.systemID = Regex.Replace(player.systemID, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                result.Add(player);
            }

            //////////////
            //// LSC: __JoinChannelHelper has memberList=
            /////////////

            content = contentCopy;

            int begin2 = content.IndexOf("LSC: __JoinChannelHelper has memberList=");
            int systemIndex = content.IndexOf("lscProxy::JoinChannels args=([(('solarsystemid2',");

            bool ok = true;
            if (begin2 < 0 || systemIndex < 0)
                ok = false;

            string systemID2 = "";
            if (ok)
            {
                content = content.Remove(0, systemIndex);

                int sStart2 = content.IndexOf(",") + 2;
                int sEnd2 = content.IndexOf(")");

                systemID2 = content.Substring(sStart2, sEnd2 - sStart2);
            }

            while (ok)
            {
                int mStart = content.IndexOf("\"<Row");
                if (mStart < 0)
                    break;
                int mEnd = content.IndexOf(">\"", mStart);
                if (mEnd < 0)
                    break;

                string message = content.Substring(mStart, mEnd - mStart);
                content = content.Substring(mEnd);

                int iStart = message.IndexOf("charID:") + ("charID:").Length;
                int iEnd = message.IndexOf(",", iStart);
                string userID = message.Substring(iStart, iEnd - iStart);
                
                int cStart = message.IndexOf("corpID:") + ("corpID:").Length;
                int cEnd = message.IndexOf(",", cStart);
                string corpID = message.Substring(cStart, cEnd - cStart);

                int aStart = message.IndexOf("allianceID:") + ("allianceID:").Length;
                int aEnd = message.IndexOf(",", aStart);
                string alliance = message.Substring(aStart, aEnd - aStart);

                int uStart = message.IndexOf("extra:[") + ("extra:[").Length;
                int uEnd = message.IndexOf("]", uStart) + 1;
                if (uEnd < uStart)
                    uEnd = uStart;
                if (uStart < 0 || uEnd < 0)
                    uEnd = uStart = 0;

                string userSec = message.Substring(uStart, uEnd - uStart);
                message = message.Substring(uEnd);

                int nStart = userSec.IndexOf("u'");
                if (nStart < 0)
                    nStart = userSec.IndexOf("u\"");
                nStart += 2;
                int nEnd = userSec.LastIndexOf("',");
                if (nEnd < 0)
                    nEnd = userSec.LastIndexOf("\",");
                string user = "";
                try { user = userSec.Substring(nStart, nEnd - nStart); }
                catch { continue; }

                bool join = true;

                PlayerInfo player = new PlayerInfo(user, join, systemID2, userID, corpID, alliance);
                player.player__name = Regex.Replace(player.player__name, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                player.userID = Regex.Replace(player.userID, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                player.corpID = Regex.Replace(player.corpID, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                player.allianceID = Regex.Replace(player.allianceID, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                player.systemID = Regex.Replace(player.systemID, "[^a-zA-Z0-9_. ]+", String.Empty, RegexOptions.Compiled);
                result.Add(player);

                if (content.IndexOf("solarsystemid2") > 0 && content.IndexOf("solarsystemid2") < content.IndexOf("\"<Row"))
                    break;
            }

            this.updateLocalList(result);

            return result;
        }

        private void updateLocalList(List<PlayerInfo> input)
        {
            List<string> joinedPlayers = new List<string>();
            List<PlayerInfo> hitlistCheck = new List<PlayerInfo>();

            foreach (PlayerInfo player in input)
            {
                if (player.systemID != this.currentSystem)
                {
                    this.players.Clear();
                    this.currentSystem = player.systemID;
                }

                if (player.join_leave)
                {
                    int ind = this.players.FindIndex(p => p.userID == player.userID);
                    if (ind == -1)
                    {
                        this.players.Add(player);
                        joinedPlayers.Add(player.player__name);
                        hitlistCheck.Add(player);
                    }
                }
                else
                {
                    int ind = this.players.FindIndex(p => p.userID == player.userID);
                    if (ind != -1)
                        this.players.RemoveAt(ind);
                }
            }

            if (joinedPlayers.Count != 0)
            {
                string message = joinedPlayers[0];
                if (joinedPlayers.Count > 1)
                    message += "+" + (joinedPlayers.Count - 1).ToString();
                message += "\nJoined the system.";
                OnRaiseAlarmEvent(new AlarmEventArgs(message,this.hotlistHit(hitlistCheck)));

                //this.players.Clear();
                //this.players.AddRange(this.players.OrderBy(p => p.player__name).ToArray());
                //this.refreshList();
            }
        }

        public bool hotlistHit(List<PlayerInfo> players)
        {
            foreach (string s in this.hotList)
            {
                if (players.Find(p => p.player__name.ToLower() == s.ToLower()) != null)
                    return true;
                try
                {
                    if (s.Substring(0, 1) == "(")
                    {
                        string corpID = s.Substring(1, s.Length - 2);
                        if (players.Find(p => p.corpID.ToLower() == corpID.ToLower()) != null)
                            return true;
                    }
                    else if (s.Substring(0, 1) == "[")
                    {
                        string allianceID = s.Substring(1, s.Length - 2);
                        if (players.Find(p => p.allianceID.ToLower() == allianceID.ToLower()) != null)
                            return true;
                    }
                }
                catch { }
            }

            return false;
        }

        public void SaveHotlist()
        {
            File.WriteAllLines(this.appDirectory + "/hotlist.txt", this.hotList.ToArray());
        }

        public string GetHotlist()
        {
            string result = "";
            foreach (string s in this.hotList)
                result += s + "\n";

            return result;
        }

        public void SetHotlist(string text)
        {
            this.hotList.Clear();
            this.hotList.AddRange(text.Trim().Split('\n'));
        }

        public void writeSettingsXML()
        {
            StringBuilder sBuilder = new StringBuilder();

            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            XmlWriter writer = XmlWriter.Create(sBuilder, xmlSettings);

            writer.WriteStartDocument();
            writer.WriteStartElement("settings");

            writer.WriteStartElement("eve_path");
            writer.WriteString(currentEveFolder);
            writer.WriteEndElement();

            writer.WriteStartElement("auto_start_log");
            writer.WriteString(autoStartLog.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("auto_start_eve");
            writer.WriteString(autoStartEve.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("update_local");
            writer.WriteString(updateLocal.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("view_options");
            writer.WriteString(viewOptions.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("view_local");
            writer.WriteString(viewLocal.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("view_xml");
            writer.WriteString(viewXML.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("view_hotlist");
            writer.WriteString(viewHotlist.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("play_alarm");
            writer.WriteString(playAlarm.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("auto_save");
            writer.WriteString(autoSave.ToString());
            writer.WriteEndElement();

            writer.WriteStartElement("hotlist");
            writer.WriteString(hotlistOnly.ToString());
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();

            writeFile(sBuilder, "settings.xml");
        }

        private void readSettingsXML()
        {
            string input = readFile();

            try
            {
                XmlReader reader = XmlReader.Create(new StringReader(input));
                Element current = Element.none;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name.Equals("eve_path", StringComparison.OrdinalIgnoreCase))
                                current = Element.eve_path;
                            else if (reader.Name.Equals("auto_start_log", StringComparison.OrdinalIgnoreCase))
                                current = Element.auto_start_log;
                            else if (reader.Name.Equals("auto_start_eve", StringComparison.OrdinalIgnoreCase))
                                current = Element.auto_start_eve;
                            else if (reader.Name.Equals("update_local", StringComparison.OrdinalIgnoreCase))
                                current = Element.update_local;
                            else if (reader.Name.Equals("view_options", StringComparison.OrdinalIgnoreCase))
                                current = Element.view_options;
                            else if (reader.Name.Equals("view_local", StringComparison.OrdinalIgnoreCase))
                                current = Element.view_local;
                            else if (reader.Name.Equals("view_xml", StringComparison.OrdinalIgnoreCase))
                                current = Element.view_xml;
                            else if (reader.Name.Equals("view_hotlist", StringComparison.OrdinalIgnoreCase))
                                current = Element.view_hotlist;
                            else if (reader.Name.Equals("play_alarm", StringComparison.OrdinalIgnoreCase))
                                current = Element.play_alarm;
                            else if (reader.Name.Equals("auto_save", StringComparison.OrdinalIgnoreCase))
                                current = Element.auto_save;
                            else if (reader.Name.Equals("hotlist", StringComparison.OrdinalIgnoreCase))
                                current = Element.hotlist;
                            break;
                        case XmlNodeType.Text:
                            if (current == Element.eve_path)
                                currentEveFolder = reader.Value;
                            else if (current == Element.auto_start_log)
                                autoStartLog = Convert.ToBoolean(reader.Value);
                            else if (current == Element.auto_start_eve)
                                autoStartEve = Convert.ToBoolean(reader.Value);
                            else if (current == Element.update_local)
                                updateLocal = Convert.ToInt32(reader.Value);
                            else if (current == Element.view_options)
                                viewOptions = Convert.ToBoolean(reader.Value);
                            else if (current == Element.view_local)
                                viewLocal = Convert.ToBoolean(reader.Value);
                            else if (current == Element.view_xml)
                                viewXML = Convert.ToBoolean(reader.Value);
                            else if (current == Element.view_hotlist)
                                viewHotlist = Convert.ToBoolean(reader.Value);
                            else if (current == Element.play_alarm)
                                playAlarm = Convert.ToBoolean(reader.Value);
                            else if (current == Element.auto_save)
                                autoSave = Convert.ToBoolean(reader.Value);
                            else if (current == Element.hotlist)
                                hotlistOnly = Convert.ToBoolean(reader.Value);
                            break;
                        case XmlNodeType.EndElement:
                            current = Element.none;
                            break;
                    }
                }
            }
            catch { }
        }

        public string writeLocalXML()
        {
            StringBuilder sBuilder = new StringBuilder();

            XmlWriterSettings xmlSettings = new XmlWriterSettings();
            xmlSettings.Indent = true;

            XmlWriter writer = XmlWriter.Create(sBuilder, xmlSettings);

            writer.WriteStartDocument();
            writer.WriteStartElement("local");

            foreach (PlayerInfo player in this.players)
            {
                writer.WriteStartElement("player");

                writer.WriteStartElement("player_name");
                writer.WriteString(player.player__name.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("player_id");
                writer.WriteString(player.userID.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("corp_id");
                writer.WriteString(player.corpID.ToString());
                writer.WriteEndElement();

                writer.WriteStartElement("alliance_id");
                writer.WriteString(player.allianceID.ToString().Trim());
                writer.WriteEndElement();

                writer.WriteStartElement("system_id");
                writer.WriteString(player.systemID.ToString());
                writer.WriteEndElement();
                
                writer.WriteStartElement("recorded_time");
                writer.WriteString(player.recorded__time.ToString());
                writer.WriteEndElement();

                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();

            writer.Flush();
            writeFile(sBuilder, "local_" + this.currentSystem.ToString() + ".xml");
            return sBuilder.ToString();
        }

        private async void writeFile(StringBuilder input, string filename)
        {
            FileStream file = new FileStream(this.appDirectory + "/" + filename, FileMode.Create);
            
            StreamWriter writer = new StreamWriter(file);
            await writer.WriteAsync(input.ToString());
            await writer.FlushAsync();
            
            writer.Close();
            file.Close();
        }

        private string readFile()
        {
            try
            {
                FileStream stream = new FileStream(this.appDirectory + "/settings.xml", FileMode.Open);
                StreamReader reader = new StreamReader(stream);

                string result = reader.ReadToEnd();

                return result;
            }
            catch { return ""; }
        }

        protected virtual void OnRaiseAlarmEvent(AlarmEventArgs e)
        {
            EventHandler<AlarmEventArgs> handler = RaiseAlarmEvent;

            if (handler != null)
                handler(this, e);
        }
    }

    public class AlarmEventArgs : EventArgs
    {
        public string Message { get; set; }
        public bool InHotlist { get; set; }

        public AlarmEventArgs(string s, bool inHotlist)
        {
            Message = s;
            InHotlist = inHotlist;
        }
    }
}
