namespace SSS.Domain.BillAggregate;

/// <summary>
/// Represents the status of a bill.
/// </summary>
public enum BillStatus
{
    /// <summary>
    /// The bill is pending payment.
    /// </summary>
    Pending,

    /// <summary>
    /// The bill has been paid.
    /// </summary>
    Paid,

    /// <summary>
    /// The bill is in the process of being shipped.
    /// </summary>
    Shipping,

    /// <summary>
    /// The bill has been successfully delivered.
    /// </summary>
    Delivered,

    /// <summary>
    /// The bill was cancelled by the user or system.
    /// </summary>
    Cancelled,
}