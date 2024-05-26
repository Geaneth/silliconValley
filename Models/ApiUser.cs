using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace silliconValley.Models
{
        [Table("t_usuario")]
    public class ApiUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string job { get; set; }
    }
}