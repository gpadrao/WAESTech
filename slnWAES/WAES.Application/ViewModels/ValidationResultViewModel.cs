namespace WAES.Application.ViewModels
{
    /// <summary>
    /// Class that will provide final information about the result of the operation
    /// </summary>
    public class ValidationResultViewModel
    {
        /// <summary>
        /// Code resulting from operation.
        /// Possible values:
        /// FILE_NOT_FOUND = 0
        /// INVALID_BASE64_PARAMETER = 1
        /// NO_FILES = 2
        /// EQUAL_FILES = 3
        /// DIFFERENT_FILES = 4
        /// SAME_SIZE_DIFFERENT = 5
        /// SUCCESSFULLY_SAVED = 6
        /// ERROR = 7
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// Contains the text resulting from operation
        /// </summary>
        public string Message { get; set; }
    }
}
