// See https://aka.ms/new-console-template for more information
public class ConditionalParser : IParserRule
{
    private readonly List<IByteCondition> _conditions = new();
    private  IParserRule _trueBranch;
    private  IParserRule _falseBranch;

    public ConditionalParser AddCondition(IByteCondition condition)
    {
        _conditions.Add(condition);
        return this;
    }

    public ConditionalParser IfTrue(IParserRule parserRule)
    {
        _trueBranch = parserRule;
        return this;
    }
    public ConditionalParser IfFalse(IParserRule parserRule)
    {
        _falseBranch = parserRule;
        return this;
    }
    public (object Result, int NewPosition) Parse(byte[] data, int startPos)
    {
        foreach (var condition in  _conditions)
        {
            if(!condition.Check(data,startPos))
                return  _falseBranch?.Parse(data, startPos) ??  (null,startPos);
        }
        return _trueBranch?.Parse(data, startPos) ?? (null, startPos);
    }
}