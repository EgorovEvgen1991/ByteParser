// See https://aka.ms/new-console-template for more information
public class ByteExtractor : IParserRule
{
    private readonly int _position;
    private readonly int _length;

    public ByteExtractor(int position, int length)
    {
        _position = position;
        _length = length;
    }

    public (object Result, int NewPosition) Parse(byte[] data, int startPos)
    {
       int actPos = startPos + _position;
       int endPos = actPos + _length;
       if (endPos > data.Length)
            return (new byte[0], startPos);
       var result = new byte[_length];
       Array.Copy(data,actPos, result, 0, _length);
       return (result, startPos);

    }
}
