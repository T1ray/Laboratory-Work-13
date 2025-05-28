namespace Lab13;

using Lab12;
using Lab10;
public class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();
    public int NumberEntries => entries.Count;
    
    public Journal() {}
    
    private string GetCollectionNameFromSource(object source)
    {
        if (source is MyObservableCollection<int, MusicalInstrument> collection)
        {
            return collection.Name;
        }
        return "Неизвестная Коллекция";
    }
    
    public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
    {
        string collectionName = GetCollectionNameFromSource(source);
        JournalEntry entry = new JournalEntry(collectionName, args.ChangeType, args.ChangedItem);
        entries.Add(entry);
    }
    
    public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
    {
        string collectionName = GetCollectionNameFromSource(source);
        JournalEntry entry = new JournalEntry(collectionName, args.ChangeType, args.ChangedItem);
        entries.Add(entry);
    }
    
    public void PrintJournal()
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("Нет записей");
        }
        else
        {
            foreach (JournalEntry entry in entries)
            {
                Console.WriteLine(entry.ToString());
            }
        }
    }
    
    public JournalEntry this [int key]
    {
        get
        {
            return entries[key];
        }
    }
}