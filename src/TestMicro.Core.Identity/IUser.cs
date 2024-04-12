using TestMicro.Core.Shared;

namespace TestMicro.Core.Identity;

public interface IUser
{
	UserId UserId { get; }
	bool IsAuthenticated { get; }
}
