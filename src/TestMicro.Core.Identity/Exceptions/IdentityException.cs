using Microsoft.AspNetCore.Identity;

namespace TestMicro.Core.Identity.Exceptions;

public class IdentityException(IdentityResult result) : Exception(result.Errors.First().Description);
