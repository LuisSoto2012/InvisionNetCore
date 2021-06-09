using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Models
{
    public class StatusResponse
    {
        public string Status { get; set; }

        public string Message { get; set; }

        public StatusResponse(string status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
