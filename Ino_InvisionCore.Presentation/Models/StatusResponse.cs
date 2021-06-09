using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ino_InvisionCore.Presentacion.Models
{
    public class StatusResponse
    {
        public string Status { get; set; }
        public bool Ok { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }

        public StatusResponse(string status, string message)
        {
            Status = status;
            Message = message;
        }

        public StatusResponse(string status, string message, bool ok, int id)
        {
            Status = status;
            Message = message;
            Ok = ok;
            Id = id;
        }
    }
}
