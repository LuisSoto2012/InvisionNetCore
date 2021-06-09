using System;
using System.Collections.Generic;
using System.Text;

namespace Ino_InvisionCore.Dominio.Contratos.Helpers
{
    public class ReportSSRS
    {
        public string SSRSReportServerUrl { get; set; }
        public string SSRSReportFolder { get; set; }
        public string CredentialUser { get; set; }
        public string CredentialPassword { get; set; }
        public string CredentialDomain { get; set; }
    }
}
