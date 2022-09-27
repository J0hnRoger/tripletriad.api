using Azure;
using Azure.Data.Tables;

namespace TripleTriad.Api.Models;

public class GamingDataEntity : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    
    public string ScriptableObjects { get; set; }
    
    public GamingDataEntity()
    {
    }
    
    public GamingDataEntity(string partitionKey, string rowKey, string scriptableObjects)
    {
        PartitionKey = partitionKey;
        RowKey = rowKey;
        ScriptableObjects = scriptableObjects;
    }
}