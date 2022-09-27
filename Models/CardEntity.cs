using Azure;
using Azure.Data.Tables;

namespace TripleTriad.Api.Models;

public class CardEntity : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    
    public string Id => RowKey;
    
    public string Name { get; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
    public string ImageUrl { get; set; }
    
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    
    public CardEntity()
    {
    }
    
    public CardEntity(string partitionKey, string rowKey, string name, int top, int right, int bottom, int left, string imageUrl)
    {
        PartitionKey = partitionKey;
        RowKey = rowKey;
        Name = name;
        Top = top;
        Right = right;
        Bottom = bottom;
        Left = left;
        ImageUrl = imageUrl;
    }
}
