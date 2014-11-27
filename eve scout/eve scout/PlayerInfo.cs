using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eve_scout
{
    class PlayerInfo
    {
        public string player__name { get; set; }
        public DateTime recorded__time { get; set; }

        public bool join_leave { get; set; }
        public string systemID { get; set; }
        public string userID { get; set; }
        public string corpID { get; set; }
        public string allianceID { get; set; }

        public PlayerInfo(string name, bool join_leave, string systemID, string userID, string corpID, string allianceID)
        {
            this.player__name = name;
            this.recorded__time = DateTime.UtcNow;
            this.join_leave = join_leave;
            this.systemID = systemID;
            this.userID = userID;
            this.corpID = corpID;
            this.allianceID = allianceID;
        }

        
    }
}
