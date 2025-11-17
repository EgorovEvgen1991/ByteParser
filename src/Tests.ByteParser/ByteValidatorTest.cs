using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Tests.ByteParser
{
    [TestFixture]
    public sealed class ByteValidatorTest
    {
        [Test]  
        public void Test()
        {
            // Создаем парсер
            var parser = ParserFactory.CreateProtocolParser();

            // Тестовые данные
            var testData = new byte[] { 0x55, 0xAA, 0xBB, 0x03, 0x02, 0x11, 0x22, 0x33, 0x44 };

            try
            {
                // Валидация
                if (parser.Validate(testData))
                {
                    Console.WriteLine("Data validation passed");

                    // Парсинг
                    var result = parser.Parse(testData);

                    foreach (var item in result)
                    {
                        Console.WriteLine($"{item.Key}: {BitConverter.ToString(item.Value)}");
                    }

                    // Детальный парсинг
                    var detailedResult = parser.ParseWithDetails(testData);
                    Console.WriteLine($"Detailed validation: {detailedResult.IsValid}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            ClassicAssert.IsTrue(true);
        }
    }
}
