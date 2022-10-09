namespace Project.Extensions
{
    public static class IFormFileExtensions
    {
        public static byte[] ToBytes(this IFormFile file)
        {
            using (var stream = new MemoryStream((int)file.Length))
            {
                file.CopyTo(stream);
                return stream.GetBuffer();
            }
        }

        public static async Task<byte[]> ToBytesAsync(this IFormFile file)
        {
            using (var stream = new MemoryStream((int)file.Length))
            {
                await file.CopyToAsync(stream);
                return stream.GetBuffer();
            }
        }
    }
}
