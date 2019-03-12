namespace VSP.Data.Models
{
    public interface IFileData
    {
        string Author { get; set; }

        string[] Tags { get; set; }

        string ContentType { get; set; }

        byte[] FileContents { get; set; }

        string Url { get; set; }
    }
}
