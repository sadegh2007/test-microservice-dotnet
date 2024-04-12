namespace TestMicro.Core.Data.Abstractions;

public interface IUpdateTime
{
    public DateTimeOffset? UpdatedAt { get; set; }
}