namespace Messanger.Scripts
{
    public static class BinaryAvatar
    {
        public static byte[] binaryPhotoEncoding(IFormFile img) 
        {
            byte[] imageData = null;
            using (var binaryReader = new BinaryReader(img.OpenReadStream()))
            {
                imageData = binaryReader.ReadBytes((int)img.Length);
            }
            return imageData;
        }


        public static string binaryPhotoDecoding(byte[] img)
        {
             return Convert.ToBase64String(img);
        }
    }
}
