using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Entidades.EvaluacionEscrita
{
    public partial class TestResults
    {
        public TestResults()
        {
            TestResultDetails = new HashSet<TestResultDetails>();
        }

        public int Id { get; set; }
        public DateTime TestStartTime { get; set; }
        public DateTime? TestEndTime { get; set; }
        public int? TotalTimeInSeconds { get; set; }
        public string TotalTimeStr { get; set; }
        public double? TotalScore { get; set; }
        public bool Approved { get; set; }
        public int? UserId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? Finish { get; set; }

        public Users User { get; set; }
        public ICollection<TestResultDetails> TestResultDetails { get; set; }
    }
}
