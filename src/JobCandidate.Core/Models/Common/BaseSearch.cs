namespace JobCandidate.Core.Models.Common;

/// <summary>
/// Represents a base search model.
/// </summary>
public class BaseSearch
{
    /// <summary>
    /// The page index. Defaults to 1.
    /// </summary>
    public int PageIndex { get; set; } = 1;

    /// <summary>
    /// The page size. Defaults to 10.
    /// </summary>
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// The sort by property.
    /// </summary>
    public string? SortBy { get; set; }

    /// <summary>
    /// Indicates whether to sort the results in descending order. Defaults to true.
    /// </summary>
    public bool SortDescending { get; set; } = true;

    /// <summary>
    /// The search term.
    /// </summary>
    public string? SearchTerm { get; set; }
}
