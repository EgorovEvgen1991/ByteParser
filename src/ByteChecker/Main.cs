namespace ByteChecker
{
    internal class Main
    {
        public static void Example()
        {
            var parser = ParserBuilder.CreateProtocolParser();
            byte[] data = {
                0xAA, 0x01,0x00, 0x73,0x6f,0x65,0x20,0x64,0x61,0x74,0x61
            };
            var (result, nextPos) = parser.Parse(data, 0);
            if (result is List<object> results)
            {
                Console.WriteLine($"Parsed {results.Count} elements");
                Console.WriteLine($" Next postion: {nextPos}");
            }
        }
    }
}
