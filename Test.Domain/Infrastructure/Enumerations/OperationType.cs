using System.ComponentModel;

namespace Test.Domain.Infrastructure.Enumerations
{
    public enum OperationType
    {
        [Description("*")]
        Multiply,
        [Description("/")]
        Divide,
        [Description("+")]
        Add,
        [Description("-")]
        Subtract
    }
}
