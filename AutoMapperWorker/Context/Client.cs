using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapperWorker.Context
{
    [Index(nameof(Name), IsUnique = true)]
    public class Client<TClientKey> 
        where TClientKey : IEquatable<TClientKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual TClientKey ClientId { get; set; }

        [StringLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }

        public TClientKey CreatedBy { get; set; }
        public TClientKey UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Tenant<TClientKey>>? Tenant { get; set; }

    }
}
