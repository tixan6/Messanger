namespace Messanger.Scripts
{
    public static class RandomCodeConfirm
    {
        public static string codeConfirm() 
        {
            Random rnd = new Random();

            string utf = "1234567890QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm";
            char[] tableWord = utf.ToCharArray();
            char[] code = new char[9];


            for (int i = 0; i <= 8; i++)
            {
                
                code[i] = tableWord[rnd.Next(0, tableWord.Length)];
            }
            return new string(code);
        }
    }
}
