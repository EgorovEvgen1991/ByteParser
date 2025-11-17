
public class ByteSequence : IByteCondition
{
    public ByteSequence(int position, byte[] expectedBytes)
    {
        _position = position;
        _expectedBytes = expectedBytes;
    }

    public int _position { get; }
    public byte[] _expectedBytes { get; }
    public bool Check(byte[] data, int position)
    {
       int startPos = position + _position;
        int endPos = startPos + _expectedBytes.Length;
        if (endPos > data.Length) 
            return false;
        for (int i = 0; i < _expectedBytes.Length; i++)
        {
            if (data[startPos +i ] != _expectedBytes[i])
                return false;
        }
        return true;
    }

    public int GetlLenght()
    {
      return  _position + _expectedBytes.Length;
    }
}


