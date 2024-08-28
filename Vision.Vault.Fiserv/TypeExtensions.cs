using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Vision.Vault.Fiserv
{
    public static class TypeExtensions
    {
        public static byte[] ToX9BigEndianFieldZero(this int recordLength)
        {
            var bytes = BitConverter.GetBytes(recordLength);

            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);

            return bytes;
        }

        public static int FromX9BigEndianFieldZero(this byte[] fieldZero)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(fieldZero);

            return BitConverter.ToInt32(fieldZero, 0);
        }

    }
}
