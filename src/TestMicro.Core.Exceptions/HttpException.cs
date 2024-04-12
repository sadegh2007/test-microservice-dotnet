using System.Net;

namespace TestMicro.Core.Exceptions;

public class HttpException(string message, string title, HttpStatusCode statusCode) : Exception(message)
{
	public HttpStatusCode StatusCode { get; init; } = statusCode;
	public string Title { get; init; } = title;
}
