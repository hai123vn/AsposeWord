namespace API.Dtos
{
    public class UploadFile
    {
        public IFormFile File { get; set; }
        public string FileType { get; set; }
    }

    public class FileOutput
    {
        public string FileName { get; set; }
        public string Url { get; set; }
    }
}