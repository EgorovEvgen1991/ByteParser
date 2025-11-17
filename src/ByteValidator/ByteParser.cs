// See https://aka.ms/new-console-template for more information
public class ByteParser
{
    private readonly List<IByteCondition> _conditions;
    private readonly List<IDataExtractor> _extractors;

    public ByteParser()
    {
        _conditions = new List<IByteCondition>();
        _extractors = new List<IDataExtractor>();
    }

    public ByteParser AddCondition(IByteCondition condition)
    {
        _conditions.Add(condition);
        return this;
    }

    public ByteParser AddExtractor(IDataExtractor extractor)
    {
        _extractors.Add(extractor);
        return this;
    }

    public bool Validate(byte[] data)
    {
        return _conditions.All(condition => condition.IsSatisfied(data));
    }

    public Dictionary<string, byte[]> Parse(byte[] data)
    {
        var result = new Dictionary<string, byte[]>();

        if (!Validate(data))
            throw new InvalidOperationException("Data validation failed");

        foreach (var extractor in _extractors)
        {
            if (extractor.ShouldExtract(data))
            {
                var extracted = extractor.Extract(data);
                result.Add($"extracted_{result.Count}", extracted);
            }
        }

        return result;
    }

    public ParsingResult ParseWithDetails(byte[] data)
    {
        var validationResults = _conditions
            .Select((condition, index) => new ValidationResult
            {
                Index = index,
                IsValid = condition.IsSatisfied(data)
            })
            .ToList();

        var extractionResults = _extractors
            .Where(extractor => extractor.ShouldExtract(data))
            .Select((extractor, index) => new ExtractionResult
            {
                Index = index,
                Data = extractor.Extract(data)
            })
            .ToList();

        return new ParsingResult
        {
            IsValid = validationResults.All(r => r.IsValid),
            ValidationResults = validationResults,
            ExtractionResults = extractionResults
        };
    }
}
