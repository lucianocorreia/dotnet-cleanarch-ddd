using System.Net;
using FluentResults;

namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailException : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => throw new NotImplementedException();

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}

