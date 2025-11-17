// See https://aka.ms/new-console-template for more information
public class SequenceParser : IParserRule
{
    private readonly List<IParserRule> _parsers = new ();
    public SequenceParser AddParser(IParserRule parser)
    {
        _parsers.Add(parser);
        return this;
    }
    public (object Result, int NewPosition) Parse(byte[] data, int startPos)
    {
        var results = new List<object>();
        int currentPos = startPos;
        foreach (var parser in _parsers)
        {
            var (result, newPos) = parser.Parse(data, currentPos);
            results.Add(result);
            currentPos = newPos;
        }
        return  (results, currentPos);
    }
}