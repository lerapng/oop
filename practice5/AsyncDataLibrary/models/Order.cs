using System.Text.Json.Serialization;

namespace AsyncDataLibrary.Models;

public enum OrderStatus { Pending, Processing, Completed, Cancelled }

public class Order
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderStatus Status { get; set; } = OrderStatus.Pending;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}