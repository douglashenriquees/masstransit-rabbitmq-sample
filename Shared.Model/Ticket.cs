namespace Shared.Model;

public class Ticket
{
    public string UserName { get; set; } = string.Empty;

    public DateTime Booked { get; set; }

    public string Location { get; set; } = string.Empty;
}