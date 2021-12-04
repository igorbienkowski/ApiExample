using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiExampleBackEnd.Models
{
    public class CalculationsResult
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int AdditionResult { get; set; }
        public int SubtractionResult { get; set; }
        public int DivsionResult { get; set; }
        public int MultiplicationResult { get; set; }
    }
}