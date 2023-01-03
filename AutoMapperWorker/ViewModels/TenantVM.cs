namespace AutoMapperWorker.ViewModels
{
    public class TenantVM<TClientKey>
        where TClientKey : IEquatable<TClientKey>
    {
        public TClientKey TenantId { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Folder { get; set; }
        public string Description { get; set; }
        public ClientBreifVM<TClientKey> Client { get; set; } = new ClientBreifVM<TClientKey>();


    }

    public class ClientBreifVM<TClientKey>

    {
        public TClientKey Id { get; set; }
        public string Name { get; set; }
    }

}
