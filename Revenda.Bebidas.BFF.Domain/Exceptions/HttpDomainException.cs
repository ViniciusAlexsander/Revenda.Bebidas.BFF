using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Revenda.Bebidas.BFF.Domain.Exceptions
{
    [Serializable]
    public class HttpDomainException : DomainException<HttpCoreError>
    {
        public HttpDomainException(HttpCoreError httpCoreError)
        {
            AddError(httpCoreError);
        }

        public HttpDomainException(HttpCoreError httpCoreError, HttpStatusCode? statusCode) : this(httpCoreError)
        {
            statusCode ??= HttpStatusCode.BadRequest;

            SetStatusCode(statusCode.Value);
        }

        protected HttpDomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Key => nameof(HttpDomainException);
    }

    public class HttpCoreError : DomainError
    {
        protected HttpCoreError(string key, string message) : base(key, message)
        {
        }

        public static HttpCoreError HttpContentError(string message) =>
             new(nameof(HttpContentError), message);

        public static HttpCoreError HttpContentError(string key, string message) =>
             new(key, message);

        public static HttpCoreError HttpNotFound =>
             new(nameof(HttpNotFound), "Not Found");
    }
}
