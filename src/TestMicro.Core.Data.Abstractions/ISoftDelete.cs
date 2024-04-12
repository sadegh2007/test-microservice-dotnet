namespace TestMicro.Core.Data.Abstractions;

public interface ISoftDelete
{
    DateTimeOffset? DeletedAt { get; set; }
}