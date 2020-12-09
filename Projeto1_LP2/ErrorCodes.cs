namespace Projeto1_LP2
{
    /// <summary>
    /// Lists all identified possible exceptions
    /// </summary>
    public enum ErrorCodes
    {
        // Main Attributes are Missing
        AttribsMissing,
        // Line(s) in the csv file don't share the same size as header
        AttribNumFluct,
        IncompatibleOptions,
        NoSearchOption,
        NoDataFound,
    }
}