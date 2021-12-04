using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiExampleBackEnd.Models
{
    public class CalculateRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
    }
}