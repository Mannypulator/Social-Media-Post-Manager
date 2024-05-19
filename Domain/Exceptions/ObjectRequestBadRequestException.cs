using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class ObjectRequestBadRequestException(string? message) : BadRequestException(message)
    {
    }
}