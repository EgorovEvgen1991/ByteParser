// See https://aka.ms/new-console-template for more information
public static class ParserBuilder
{
    public static IParserRule CreateProtocolParser()
    {
        return new ConditionalParser()
            .AddCondition(new ByteAtPosition(0, 0xAA))
            .AddCondition(new ByteSequence(0, [0x00, 0x43]))
            .IfTrue(new SequenceParser()
                .AddParser(new ByteExtractor(0, 1))
                .AddParser(new ConditionalParser()
                    .AddCondition(new ByteAtPosition(1, 0x01))
                    .IfTrue(new ByteExtractor(2, 2))
                    .IfFalse(new ByteExtractor(2, 1))
                )
            )
            .IfFalse(new SequenceParser().AddParser(new ByteExtractor(0, 4))
            );

    }
}
