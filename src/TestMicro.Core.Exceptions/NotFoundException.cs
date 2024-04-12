using System.Net;

namespace TestMicro.Core.Exceptions;

public class NotFoundException(string message, string title = "Not Found") : HttpException(message, title, HttpStatusCode.NotFound);
