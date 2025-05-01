using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        protected DomainException(string message)
            : base(message)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public abstract string Key { get; }

        protected ICollection<DomainError> errors = new List<DomainError>();

        public IEnumerable<DomainError> Errors
        { get { return errors; } }

        protected HttpStatusCode statusCode = HttpStatusCode.BadRequest;

        public HttpStatusCode StatusCode
        { get { return statusCode; } }
    }

    public abstract class DomainException<T> : DomainException
        where T : DomainError
    {
        protected DomainException()
            : base("Ocorreu um erro de negócio, verifique a propriedade 'errors' para obter detalhes.")
        {
        }

        protected DomainException(string message)
            : base(message)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public DomainException AddError(params T[] errors)
        {
            foreach (var error in errors)
            {
                this.errors.Add(error);
            }

            return this;
        }

        public DomainException SetStatusCode(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
            return this;
        }
    }
}
