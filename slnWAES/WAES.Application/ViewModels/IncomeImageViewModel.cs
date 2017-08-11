namespace WAES.Application.ViewModels
{
    /// <summary>
    /// Model that will be provided in the method signature for sending images
    /// </summary>
    public class IncomeImageViewModel
    {
        /// <summary>
        /// base64 encoded binary data
        /// </summary>
        public string Base64Image { get; set; }
    }
}
