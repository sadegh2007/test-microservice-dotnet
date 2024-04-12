using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestMicro.Core.Exceptions;

namespace TestMicro.Core.ExceptionHandler;

public class TestMicroExceptionHandler(ILogger<TestMicroExceptionHandler> logger) : IExceptionHandler
{
	private readonly ILogger<TestMicroExceptionHandler> _logger = logger;

	public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
	{
		var problemDetails = exception switch
		{
			HttpException httpException => ProcessHttpException(httpException),
			_ => ProcessUnKnownException(exception)
		};

		httpContext.Response.StatusCode = problemDetails.Status ?? 400;

		await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

		return true;
	}

	private static ProblemDetails ProcessHttpException(HttpException exception)
	{
		var problemDetails = new ProblemDetails
		{
			Status = (int)exception.StatusCode,
			Title = exception.Title,
			Detail = exception.Message
		};

		return problemDetails;
	}

	private ProblemDetails ProcessUnKnownException(Exception exception)
	{
		_logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

		var problemDetails = new ProblemDetails
		{
			Status = StatusCodes.Status400BadRequest,
			Title = "Bad Request",
			Detail = exception.Message
		};

		return problemDetails;
	}
}
