namespace CSVDataIntegrationApp.Application.Models;

public class EmployeeQueryModel
{
    /// <summary>
    /// Search term to filter employees by surname, forenames, or email.
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// The column name to sort by (e.g., "Surname", "DateOfBirth").
    /// </summary>
    public string? SortColumn { get; set; } = "Surname";

    /// <summary>
    /// Indicates whether the sorting should be ascending.
    /// </summary>
    public bool SortAscending { get; set; } = true;
}
