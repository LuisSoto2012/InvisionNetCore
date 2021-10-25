using System;
using System.Collections.Generic;

namespace Ino_InvisionCore.Dominio.Entidades.EvaluacionEscrita
{
    public partial class Answers
    {
        public Answers()
        {
            TestResultDetails = new HashSet<TestResultDetails>();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }

        public Questions Question { get; set; }
        public ICollection<TestResultDetails> TestResultDetails { get; set; }
    }
}
