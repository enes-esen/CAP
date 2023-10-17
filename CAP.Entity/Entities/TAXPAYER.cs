using System.ComponentModel.DataAnnotations;
using CAP.Core.Abstract.Entities;

namespace CAP.Entity.Entities
{
    public class TAXPAYER : EntityBase
	{
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //public Guid ID { get; set; }

        [Required]
        [StringLength(50)]
        public string? tp_name{ get; set; }

        [Required]
        [StringLength(100)]
        public string? tp_company_name { get; set; }

        [Required]
        [MaxLength(11), MinLength(11)]
        public long VKN { get; set; }

        [Required]
        [StringLength(100)]
        public string? tp_tax_office { get; set; }


        public Guid tp_address_id { get; set; }
        public ADDRESS? tp_address { get; set; }


        [StringLength(13)]
        public string? tp_phone { get; set; }

        [StringLength(150)]
        public string? tp_email { get; set; }

        public int tp_employees_num { get; set; }

        public DateTime tp_opening_date { get; set; }

        //public bool STATUS { get; set; }

    }
}

