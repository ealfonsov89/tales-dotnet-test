namespace Customer.DataTransferObjects;

public class CustomerDto
{
    public int? Id { get; set; }
    public string First { get; set; }
    public string Last { get; set; }
    public DateTime CreatedAt { get; set; }

    public CustomerDto()
    {
        CreatedAt = DateTime.Now;
        First = string.Empty;
        Last = string.Empty;
    }
}