using CAP.Core.Abstract.Entities;

namespace CAP.Entity.Entities
{
	public class ADDRESS : EntityBase
	{
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Required]
        //public Guid ID { get; set; }
        public string? ad_address { get; set; }
		//public bool STATUSS { get; set; }

		public ICollection<TAXPAYER>? tax_payers { get; set; }
		//Burada TAXPAYER sınıfı ile birden çoğa bir ilişki kuruldu.
		


	}
}