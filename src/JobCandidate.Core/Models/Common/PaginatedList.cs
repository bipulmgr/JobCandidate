namespace JobCandidate.Core.Models.Common;

/// <summary>
/// Represents a paginated list of items.
/// </summary>
/// <typeparam name="T">The type of the items.</typeparam>
public class PaginatedList<T>
{
    /// <summary>
    /// The list of items.
    /// </summary>
    public List<T> Items { get; set; } = new List<T>();

    /// <summary>
    /// The page index.
    /// </summary>
    public int PageIndex { get; set; }

    /// <summary>
    /// The total number of pages.
    /// </summary>
    public int TotalPages { get; set; }

    /// <summary>
    /// The total number of items.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
    /// </summary>
    public PaginatedList()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
    /// </summary>
    /// <param name="items">The list of items.</param>
    /// <param name="count">The total number of items.</param>
    /// <param name="pageIndex">The page index.</param>
    /// <param name="pageSize">The page size.</param>
    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        TotalCount = count;
        Items = items;
    }

    /// <summary>
    /// Indicates whether the previous page exists.
    /// </summary>
    public bool HasPreviousPage => PageIndex > 1;

    /// <summary>
    /// Indicates whether the next page exists.
    /// </summary>
    public bool HasNextPage => PageIndex < TotalPages;
}
