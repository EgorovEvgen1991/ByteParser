// See https://aka.ms/new-console-template for more information
public class DynamicExtractor : IDataExtractor
{
    public Func<byte[], int> StartCalculator { get; }
    public Func<byte[], int> LengthCalculator { get; }
    public Func<byte[], bool> Condition { get; }

    public DynamicExtractor(Func<byte[], int> startCalculator,
                           Func<byte[], int> lengthCalculator,
                           Func<byte[], bool> condition = null)
    {
        StartCalculator = startCalculator;
        LengthCalculator = lengthCalculator;
        Condition = condition;
    }

    public bool ShouldExtract(byte[] data)
    {
        return Condition?.Invoke(data) ?? true;
    }

    public byte[] Extract(byte[] data)
    {
        var start = StartCalculator(data);
        var length = LengthCalculator(data);

        if (data.Length < start + length)
            return Array.Empty<byte>();

        return data.Skip(start).Take(length).ToArray();
    }
}