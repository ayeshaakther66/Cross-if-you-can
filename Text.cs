using System;
using System.IO;
namespace Custom
{
    public static class Text
    {
        public static int ReadInteger(this StreamReader reader)
        {
            return Convert.ToInt32(reader.ReadLine());
        }



    }
}
