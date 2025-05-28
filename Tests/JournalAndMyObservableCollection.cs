namespace Tests;

using Lab13;
using Lab12;
using Lab10;

[TestClass]
public class EventTests
{
    private MyObservableCollection<int, MusicalInstrument> collection;
    private Journal journal;
    
    [TestInitialize]
    public void Initialize()
    {
        journal = new Journal();
        collection = new MyObservableCollection<int, MusicalInstrument>("Коллекция");

        collection.CollectionCountChanged += journal.CollectionCountChanged;
        collection.CollectionReferenceChanged += journal.CollectionReferenceChanged;
    }
    
    [TestMethod]
    public void TestAddICollection()
    {
        MusicalInstrument instrument1 = new Guitar(8, 18);
        collection.Add(instrument1.Id.Id, instrument1);
        
        Assert.IsTrue(collection.Count == 1);
        Assert.IsTrue(collection.ContainsKey(instrument1.Id.Id));
    }

    [TestMethod]
    public void TestAddIDictionary()
    {
        MusicalInstrument instrument1 = new Guitar(8, 18);
        collection.Add(new KeyValuePair<int, MusicalInstrument>(instrument1.Id.Id, instrument1));
        
        Assert.IsTrue(collection.Count == 1);
        Assert.IsTrue(collection.ContainsKey(instrument1.Id.Id));
    }

    [TestMethod]
    public void TestRemoveIDictionary()
    {
        MusicalInstrument instrument1 = new MusicalInstrument { Name = "Гитара", Id = new IdNumber(101) };
        MusicalInstrument instrument2 = new MusicalInstrument { Name = "Барабан", Id = new IdNumber(102) };
        
        collection.Add(instrument1.Id.Id, instrument1);
        collection.Add(instrument2.Id.Id, instrument2);

        KeyValuePair<int, MusicalInstrument> itemToRemove = new KeyValuePair<int, MusicalInstrument>(instrument1.Id.Id, instrument1);
        bool removed = collection.Remove(itemToRemove);
        
        Assert.IsTrue(removed);
        Assert.AreEqual(1, collection.Count);
        Assert.IsFalse(collection.ContainsKey(instrument1.Id.Id));
        Assert.IsTrue(collection.ContainsKey(instrument2.Id.Id));

        JournalEntry entry = journal[journal.NumberEntries-1];
        Assert.AreEqual("Коллекция", entry.CollectionName);
        Assert.AreEqual("Удален элемент", entry.CollectionChangeType);
        var loggedPair = (KeyValuePair<int, MusicalInstrument>)entry.CollectionChangeData;
        Assert.AreEqual(itemToRemove.Key, loggedPair.Key);
        Assert.AreEqual(itemToRemove.Value.Name, loggedPair.Value.Name);
    }

    [TestMethod]
    public void TestRemoveICollection()
    {
        MusicalInstrument instrument1 = new MusicalInstrument();
            instrument1.Name = "ГитараУдалитьПарой"; 
            instrument1.Id = new IdNumber(101);

            MusicalInstrument instrument2 = new MusicalInstrument();
            instrument2.Name = "БарабанОстанется"; 
            instrument2.Id = new IdNumber(102);

            collection.Add(instrument1.Id.Id, instrument1);
            collection.Add(instrument2.Id.Id, instrument2);
            
            int initialJournalEntries = journal.NumberEntries; 

            KeyValuePair<int, MusicalInstrument> itemToRemove = new KeyValuePair<int, MusicalInstrument>(instrument1.Id.Id, instrument1);
            bool removed = collection.Remove(itemToRemove);

            Assert.IsTrue(removed);
            Assert.AreEqual(1, collection.Count);
            Assert.IsFalse(collection.ContainsKey(instrument1.Id.Id));
            Assert.IsTrue(collection.ContainsKey(instrument2.Id.Id));

            Assert.AreEqual(initialJournalEntries + 1, journal.NumberEntries);
            JournalEntry entry = journal[journal.NumberEntries - 1];
            Assert.AreEqual("Коллекция", entry.CollectionName);
            Assert.AreEqual("Удален элемент", entry.CollectionChangeType);

            object changeData = entry.CollectionChangeData;
            Assert.IsTrue(changeData is KeyValuePair<int, MusicalInstrument>);
            KeyValuePair<int, MusicalInstrument> loggedPair = (KeyValuePair<int, MusicalInstrument>)changeData;
            Assert.AreEqual(itemToRemove.Key, loggedPair.Key);
            Assert.IsTrue(itemToRemove.Value.Equals(loggedPair.Value));
    }

    [TestMethod]
    public void TestIndexerToAdd()
    {
        int initialJournalEntries = journal.NumberEntries;
        MusicalInstrument newInstrument = new MusicalInstrument();
        newInstrument.Name = "НоваяФлейта";
        newInstrument.Id = new IdNumber(301);
            
        collection[newInstrument.Id.Id] = newInstrument; 
            
        Assert.AreEqual(1, collection.Count);
        Assert.IsTrue(collection.ContainsKey(newInstrument.Id.Id));
        Assert.IsTrue(newInstrument.Equals(collection[newInstrument.Id.Id]));

        Assert.AreEqual(initialJournalEntries + 1, journal.NumberEntries);
        JournalEntry entry = journal[journal.NumberEntries - 1];
        Assert.AreEqual("Коллекция", entry.CollectionName);
        Assert.AreEqual("Добавлен элемент", entry.CollectionChangeType);

        object changeData = entry.CollectionChangeData;
        Assert.IsTrue(changeData is KeyValuePair<int, MusicalInstrument>);
        KeyValuePair<int, MusicalInstrument> loggedPair = (KeyValuePair<int, MusicalInstrument>)changeData;
        Assert.AreEqual(newInstrument.Id.Id, loggedPair.Key);
        Assert.IsTrue(newInstrument.Equals(loggedPair.Value));
    }

    [TestMethod]
    public void TestIndexerToUpdate()
    {
        MusicalInstrument originalInstrument = new MusicalInstrument();
        originalInstrument.Name = "СтараяВиолончель";
        originalInstrument.Id = new IdNumber(401);
        collection.Add(originalInstrument.Id.Id, originalInstrument);
            
        int initialJournalEntriesAfterAdd = journal.NumberEntries;

        MusicalInstrument updatedInstrument = new MusicalInstrument();
        updatedInstrument.Name = "НоваяВиолончель блеск";
        updatedInstrument.Id = new IdNumber(401); 
            
        collection[originalInstrument.Id.Id] = updatedInstrument; 
            
        Assert.AreEqual(1, collection.Count);
        Assert.IsTrue(collection.ContainsKey(originalInstrument.Id.Id));
        Assert.IsTrue(updatedInstrument.Equals(collection[originalInstrument.Id.Id]));

        Assert.AreEqual(initialJournalEntriesAfterAdd + 1, journal.NumberEntries);
        JournalEntry entry = journal[journal.NumberEntries - 1];
        Assert.AreEqual("Коллекция", entry.CollectionName);
        Assert.AreEqual("Элемент изменен", entry.CollectionChangeType);

        object changeData = entry.CollectionChangeData;
        Assert.IsTrue(changeData is KeyValuePair<int, MusicalInstrument>);
        KeyValuePair<int, MusicalInstrument> loggedPair = (KeyValuePair<int, MusicalInstrument>)changeData;
        Assert.AreEqual(updatedInstrument.Id.Id, loggedPair.Key);
        Assert.IsTrue(updatedInstrument.Equals(loggedPair.Value));
    }

    [TestMethod]
    public void TestClear()
    {
        MusicalInstrument instrument1 = new MusicalInstrument();
        instrument1.Name = "Саксофон1";
        instrument1.Id = new IdNumber(501);

        MusicalInstrument instrument2 = new MusicalInstrument();
        instrument2.Name = "Труба2";
        instrument2.Id = new IdNumber(502);
        
        collection.Add(instrument1.Id.Id, instrument1);
        collection.Add(instrument2.Id.Id, instrument2);
        
        int initialJournalEntriesAfterAdds = journal.NumberEntries;
        int itemsInCollectionBeforeClear = collection.Count;
        
        collection.Clear();
        
        Assert.AreEqual(0, collection.Count);
        Assert.AreEqual(initialJournalEntriesAfterAdds + itemsInCollectionBeforeClear, journal.NumberEntries);
        
        JournalEntry entry1 = journal[journal.NumberEntries - itemsInCollectionBeforeClear]; 
        JournalEntry entry2 = journal[journal.NumberEntries - 1];
        
        Assert.AreEqual("Коллекция", entry1.CollectionName);
        Assert.AreEqual("Удален элемент", entry1.CollectionChangeType);
        Assert.AreEqual("Коллекция", entry2.CollectionName);
        Assert.AreEqual("Удален элемент", entry2.CollectionChangeType);
        
        bool foundLogForInstrument1 = false;
        bool foundLogForInstrument2 = false;
        for(int i = initialJournalEntriesAfterAdds; i < journal.NumberEntries; i++)
        {
            JournalEntry currentEntry = journal[i];
             object changeData = currentEntry.CollectionChangeData;
            if(changeData is KeyValuePair<int, MusicalInstrument> pair)
            {
                if(pair.Key == instrument1.Id.Id && instrument1.Equals(pair.Value)) foundLogForInstrument1 = true;
                if(pair.Key == instrument2.Id.Id && instrument2.Equals(pair.Value)) foundLogForInstrument2 = true;
            }
        }
        Assert.IsTrue(foundLogForInstrument1, "Запись об удалении Саксофон1 не найдена или некорректна.");
        Assert.IsTrue(foundLogForInstrument2, "Запись об удалении Труба2 не найдена или некорректна.");
    }
}