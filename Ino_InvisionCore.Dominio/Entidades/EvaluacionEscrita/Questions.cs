using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Entidades.EvaluacionEscrita
{
    public partial class Questions
    {
        public Questions()
        {
            Answers = new HashSet<Answers>();
            TestResultDetails = new HashSet<TestResultDetails>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public int? TimeLimit { get; set; }
        public string Image { get; set; }
        public int? TestPartId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public double? Penality { get; set; }
        public double Score { get; set; }

        public TestParts TestPart { get; set; }
        public ICollection<Answers> Answers { get; set; }
        public ICollection<TestResultDetails> TestResultDetails { get; set; }
    }
}
