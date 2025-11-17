// See https://aka.ms/new-console-template for more information
public class ByteAtPosition : IByteCondition
{
    public ByteAtPosition(int position, byte expectedByte)
    {
        _position = position;
        _expectedByte = expectedByte;
    }

    public int _position { get; }
    public byte _expectedByte { get; }
    
    public bool Check(byte[] data, int position)
    {
        int actualPos = position + _position;
        var result = actualPos < data.Length && data[actualPos] == _expectedByte;
        return result;
    }

    public int GetlLenght()
    {
        return _position + 1;
    }
}
