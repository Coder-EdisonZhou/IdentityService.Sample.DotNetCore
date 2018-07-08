using System;
using System.Collections.Generic;
using System.Text;

namespace Manulife.DNC.MSAD.Common
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string ToWho { get; set; }
        public string ToAccount { get; set; }
        public string FromWho { get; set; }
        public string FromAccount { get; set; }
        public string AuthAccount { get; set; }
        public string AuthPassword { get; set; }
        public string Subject { get; set; }
    }
}
