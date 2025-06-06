public static class FileContentHelper
{
    public static string GetContentType(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLowerInvariant();

        if (extension == ".txt")
            return "text/plain";
        if (extension == ".pdf")
            return "application/pdf";
        if (extension == ".png")
            return "image/png ";
        return "application/octet-stream";
    }
}
