using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CAP.Core.Abstract.Interfaces;

namespace CAP.Core.Abstract.Entities
{
	public abstract class EntityBase : IEntityBase
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public virtual Guid ID { get; set; } = Guid.NewGuid();

        public virtual bool STATUSS { get; set; } = true;
    }
}

