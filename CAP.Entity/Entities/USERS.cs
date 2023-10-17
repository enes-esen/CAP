using System.ComponentModel.DataAnnotations;
using CAP.Core.Abstract.Entities;

namespace CAP.Entity.Entities
{
	public class USERS : EntityBase
	{
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string? u_name { get; set; }

        [Required]  
        [StringLength(50)]
        public string? u_email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string? u_password { get; set; }

        [Required]
        [StringLength(13)]
        public string? u_phone { get; set; }

        [Required]
        [StringLength(150)]
        public string? u_address { get; set; }

        [Required]
        [StringLength(50)]
        public string? u_department { get; set; }

        [Required]
        public DateTime u_date { get; set; }

        //[Required]
        //public DateTime u_time { get; set; }

        //public bool? USTATUS { get; set; }
    }
}