// See https://aka.ms/new-console-template for more information
public class MultiByteCondition : IByteCondition
{
    public int StartPosition { get; }
    public byte[] ExpectedSequence { get; }

    public MultiByteCondition(int startPosition, byte[] expectedSequence)
    {
        StartPosition = startPosition;
        ExpectedSequence = expectedSequence;
    }

    public bool IsSatisfied(byte[] data)
    {
        if (data.Length < StartPosition + ExpectedSequence.Length)
            return false;

        for (int i = 0; i < ExpectedSequence.Length; i++)
        {
            if (data[StartPosition + i] != ExpectedSequence[i])
                return false;
        }
        return true;
    }
}
