using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLib.Models
{
    public class AuthToken
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public DateTime DateGenerated { get; set; }
        public string Ip { get; set; }

        [ForeignKey(nameof(ModeratorId))]
        public int? ModeratorId { get; set; }
        public virtual Moderator Moderator { get; set; }
    }
}
