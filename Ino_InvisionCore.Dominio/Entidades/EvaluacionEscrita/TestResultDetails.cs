using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Entidades.EvaluacionEscrita
{
    public partial class TestResultDetails
    {
        public int Id { get; set; }
        public int? QuestionId { get; set; }
        public int? SelectedAnswerId { get; set; }
        public int TestResultId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public Questions Question { get; set; }
        public Answers SelectedAnswer { get; set; }
        public TestResults TestResult { get; set; }
    }
}
