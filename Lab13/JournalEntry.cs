namespace Lab13;

public class JournalEntry
{
    public string CollectionName { get; }
    public string CollectionChangeType { get; }
    public object CollectionChangeData { get; }

    public JournalEntry(string collectionName, string collectionChangeType, object collectionChangeData)
    {
        CollectionName = collectionName;
        CollectionChangeType = collectionChangeType;
        CollectionChangeData = collectionChangeData;
    }
    
    public override string ToString() => $"{CollectionName}, {CollectionChangeType} {CollectionChangeData}";
}