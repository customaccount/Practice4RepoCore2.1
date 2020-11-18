using System;
using System.Collections.Generic;


namespace Remote_Debug_App2.Models
{
    public partial class DebugTable
    {
        public int Id { get; set; }
        public string RandomGuid { get; set; }
        public DateTime DateTime { get; set; }
        public string SerializedObject { get; set; }
    }
}
