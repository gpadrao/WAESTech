using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace WAES.Infra.CrossCutting.Utilities
{
    public static class SharedMethods
    {
        /// <summary>
        /// Method that check if the parameter content is valid 
        /// </summary>
        /// <param name="base64String">String with a base64 encode value</param>
        /// <returns></returns>
        public static bool IsBase64Valid(string base64String)
        {
            // Credit: oybek https://stackoverflow.com/users/794764/oybek
            if (base64String == null || base64String.Length == 0 || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch
            {

            }
            return false;
        }
        /// <summary>
        /// Method that compares two different images
        /// </summary>
        /// <param name="bmp1">First image</param>
        /// <param name="bmp2">Second image</param>
        /// <param name="numberOfDifferences">It will return 1 if the images have same size, but differ at least one pixel</param>
        /// <returns></returns>
        public static bool GetDifferenceBetweenImages(Bitmap bmp1, Bitmap bmp2, ref int numberOfDifferences)
        {
            numberOfDifferences = 0;
            bool areEqual = true;
            Size s1 = bmp1.Size;
            Size s2 = bmp2.Size;

            //if the size is different, than return without need to search into the matrix
            if (s1 != s2) return false;

            //Searching into the image matrix the first different pixel
            for (int y = 0; y < s1.Height; y++)
                for (int x = 0; x < s1.Width; x++)
                {
                    Color c1 = bmp1.GetPixel(x, y);
                    Color c2 = bmp2.GetPixel(x, y);
                    if (c1 != c2)
                    {
                        numberOfDifferences++;
                        return areEqual;
                    }
                        
                        
                }
            return areEqual;
        }
        /// <summary>
        /// Method used to get a description of the provided enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
