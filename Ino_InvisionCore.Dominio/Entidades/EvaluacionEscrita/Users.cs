using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Entidades.EvaluacionEscrita
{
    public partial class Users
    {
        public Users()
        {
            TestResults = new HashSet<TestResults>();
        }

        public int Id { get; set; }
        public string UserType { get; set; }
        public string Code { get; set; }
        public string Names { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public ICollection<TestResults> TestResults { get; set; }
    }
}
