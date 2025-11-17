// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

public interface IParserRule
{
    (object Result, int NewPosition) Parse(byte[] data, int startPos);
}
