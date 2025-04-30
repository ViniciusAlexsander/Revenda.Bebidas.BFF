using Revenda.Bebidas.BFF.Domain.Adapters;
using Revenda.Bebidas.BFF.Domain.Models.Revenda;
using System.Data;

namespace Revenda.Bebidas.BFF.Infra.DbAdapter
{
    public class RevendaDbAdapter : BaseDbAdapter, IRevendaDbAdapter
    {
        public RevendaDbAdapter(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        private static readonly string INSERIR_REVENDA = @"
            INSERT INTO
            public.revenda 
                (cnpj, 
                razaosocial, 
                nomefantasia, 
                email, 
                telefone, 
                nomecontato, 
                enderecoentrega)
            VALUES(@Cnpj, @RazaoSocial, @NomeFantasia, @Email, @Telefone, @NomeContato, @EnderecoEntrega);
        ";

        public async Task InserirRevenda(RevendaModel revendaModel)
        {
            await ExecuteAsync(INSERIR_REVENDA, revendaModel);
        }
    }
}
