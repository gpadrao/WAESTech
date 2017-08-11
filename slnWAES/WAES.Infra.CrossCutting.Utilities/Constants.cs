using System.ComponentModel;

namespace WAES.Infra.CrossCutting.Utilities
{
    /// <summary>
    /// Class that centralizes all Enums and Structs used in the application
    /// </summary>
    public class Constants
    {
        public const string WAESLogRegister = "WAESLogRegister";
        /// <summary>
        /// Values of valid sides, to insert images
        /// </summary>
        public enum ImageSide
        {
            [Description("Left")]
            Left = 0,
            [Description("Right")]
            Right = 1
        }
        /// <summary>
        /// Enum that contains the possible returns for each type of operation
        /// </summary>
        public enum PossibleReturns
        {
            [Description("'{0}' file not found.")]
            FILE_NOT_FOUND = 0,
            [Description("Invalid Base64 parameter.")]
            INVALID_BASE64_PARAMETER = 1,
            [Description("There are no files of ID '{0}' to compare.")]
            NO_FILES = 2,
            [Description("Files of ID '{0}' are equal.")]
            EQUAL_FILES = 3,
            [Description("Files of ID '{0}' are differents")]
            DIFFERENT_FILES = 4,
            [Description("Files of ID '{0}' have the same size, but they differ at least one pixel.")]
            SAME_SIZE_DIFFERENT = 5,
            [Description("File of ID '{0}' saved successfully.")]
            SUCCESSFULLY_SAVED = 6,
            [Description("Error trying to save.")]
            ERROR = 7
        }
    }
}
