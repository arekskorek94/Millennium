using System;

namespace Millenium.Application.Exceptions
{
    public class EntityNotFoundException : AppException
    {
        public EntityNotFoundException(string entityName, Guid id) : base($"Id: {id} nie zostało znalezione w {entityName}.")
        {
        }
    }
}