using System.ComponentModel.DataAnnotations;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter
{
    public class DbAdapterConfiguration
    {
        [Required]
        public string ConnectionString { get; init; }
    }
}

