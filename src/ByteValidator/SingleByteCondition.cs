// See https://aka.ms/new-console-template for more information
public class SingleByteCondition : IByteCondition
{
    public int Position { get; }
    public byte ExpectedValue { get; }

    public SingleByteCondition(int position, byte expectedValue)
    {
        Position = position;
        ExpectedValue = expectedValue;
    }

    public bool IsSatisfied(byte[] data)
    {
        return data.Length > Position && data[Position] == ExpectedValue;
    }
}
