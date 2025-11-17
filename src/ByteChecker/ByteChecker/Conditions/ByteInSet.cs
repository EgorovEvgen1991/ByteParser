// See https://aka.ms/new-console-template for more information
public class ByteInSet : IByteCondition
{
    public ByteInSet(int position, HashSet<byte> allowedBytes)
    {
        _position = position;
        _allowedBytes = allowedBytes;
    }

    public int _position { get; }
    public HashSet<byte> _allowedBytes { get; }


    public bool Check(byte[] data, int position)
    {
        throw new NotImplementedException();
    }

    public int GetlLenght()
    {
        throw new NotImplementedException();
    }
}
