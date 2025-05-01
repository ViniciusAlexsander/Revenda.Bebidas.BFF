using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Domain.Exceptions.Revendas
{
    public class CadastrarRevendasDomainException : DomainException<CadastrarRevendasCoreError>
    {
        public CadastrarRevendasDomainException(CadastrarRevendasCoreError coreError)
        {
            AddError(coreError);
        }

        protected CadastrarRevendasDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Key => "CadastrarRevendasDomainException";
    }

    public class CadastrarRevendasCoreError : DomainError
    {
        protected CadastrarRevendasCoreError(string key, string message): base(key, message) { }

        public static CadastrarRevendasCoreError CnpjInvalido =>
            new("CnpjInvalido",
                "É necessário informar um CNPJ válido. Verifique e tente novamente.");

        public static CadastrarRevendasCoreError RazaoSocialInvalido =>
            new("RazaoSocialInvalido",
                "É necessário informar uma razão social válida. Verifique e tente novamente.");

        public static CadastrarRevendasCoreError NomeFantasiaInvalido =>
            new("NomeFantasiaInvalido",
                "É necessário informar um nome fantasia válido. Verifique e tente novamente.");

        public static CadastrarRevendasCoreError EmailInvalido =>
            new("EmailInvalido",
                "É necessário informar um email válido. Verifique e tente novamente.");

        public static CadastrarRevendasCoreError NomeContatoInvalido =>
            new("NomeContatoInvalido",
                "É necessário informar um nome de contato válido. Verifique e tente novamente.");

        public static CadastrarRevendasCoreError EnderecoEntregaInvalido =>
            new("EnderecoEntregaInvalido",
                "É necessário informar um endereco de entrega válido. Verifique e tente novamente.");
    }
}
