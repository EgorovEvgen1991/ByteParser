// See https://aka.ms/new-console-template for more information
public interface IDataExtractor
{
    byte[] Extract(byte[] data);
    bool ShouldExtract(byte[] data);
}
