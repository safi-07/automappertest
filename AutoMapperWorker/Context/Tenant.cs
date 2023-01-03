using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoMapperWorker.Context
{
    public class Tenant<TClientKey>
        where TClientKey : IEquatable<TClientKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TClientKey TenantId { get; set; }
        [StringLength(100)]
        public string? Name { get; set; }
        [StringLength(100)]
        public string? Host { get; set; }
        [StringLength(200)]
        public string? Folder { get; set; }
        public string? Description { get; set; }

        [ForeignKey("Client")]
        public TClientKey ClientId { get; set; }
        public virtual Client<TClientKey>? Client { get; set; }


    }
}
