using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Server
{
    public static class FormReference
    {
        #region Properties
        public static ConnectDatabase connDatabase { get; set; }
        public static Monitoring monitorPrefer { get; set; }
        #endregion
    }
}
