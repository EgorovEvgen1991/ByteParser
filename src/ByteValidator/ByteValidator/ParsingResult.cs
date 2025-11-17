// See https://aka.ms/new-console-template for more information
public class ParsingResult
{
    public bool IsValid { get; set; }
    public List<ValidationResult> ValidationResults { get; set; }
    public List<ExtractionResult> ExtractionResults { get; set; }
}
