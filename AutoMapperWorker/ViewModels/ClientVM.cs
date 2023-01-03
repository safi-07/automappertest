using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoMapperWorker.ViewModels
{
    public class ClientVM<TClientKey>
            where TClientKey : IEquatable<TClientKey>
    {
        public TClientKey ClientId { get; set; }
        [DisplayName("Name")]
        [Display(Prompt = "Add Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [DisplayName("Description")]
        [Display(Prompt = "Add Description")]
        public string Description { get; set; }

        public List<TenantVM<TClientKey>> Tenants { get; set; }
    }

}
