// See https://aka.ms/new-console-template for more information
public class ConditionalExtractor : IDataExtractor
{
    public int Start { get; }
    public int Length { get; }
    public Func<byte[], bool> Condition { get; }

    public ConditionalExtractor(int start, int length, Func<byte[], bool> condition = null)
    {
        Start = start;
        Length = length;
        Condition = condition;
    }

    public bool ShouldExtract(byte[] data)
    {
        return Condition?.Invoke(data) ?? true;
    }

    public byte[] Extract(byte[] data)
    {
        if (data.Length < Start + Length)
            return Array.Empty<byte>();

        return data.Skip(Start).Take(Length).ToArray();
    }
}
