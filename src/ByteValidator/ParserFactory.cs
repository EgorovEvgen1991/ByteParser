// See https://aka.ms/new-console-template for more information
public static class ParserFactory
{
    public static ByteParser CreateProtocolParser()
    {
        return new ByteParser()
            // Проверка заголовка
            .AddCondition(new SingleByteCondition(0, 0x55))
            .AddCondition(new MultiByteCondition(1, new byte[] { 0xAA, 0xBB }))

            // Извлечение данных с условиями
            .AddExtractor(new ConditionalExtractor(
                start: 3,
                length: 2,
                condition: data => data[0] == 0x55
            ))
            .AddExtractor(new DynamicExtractor(
                startCalculator: data => data[3],
                lengthCalculator: data => data[4],
                condition: data => data.Length > 5
            ))
            .AddExtractor(new ConditionalExtractor(
                start: 5,
                length: 4,
                condition: data => data[2] == 0x01
            ));
    }

    public static ByteParser CreateCustomParser(Action<ByteParser> configurator)
    {
        var parser = new ByteParser();
        configurator(parser);
        return parser;
    }
}