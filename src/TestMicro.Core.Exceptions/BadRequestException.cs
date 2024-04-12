using System.Net;

namespace TestMicro.Core.Exceptions;

public class BadRequestException(string message, string title = "Bad Request") : HttpException(message, title, HttpStatusCode.BadRequest);
