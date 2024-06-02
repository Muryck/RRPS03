using System;
using System.Collections;

public interface IIterator
{
    bool HasNext();
    object Next();
}

public class Iterator : IIterator
{
    private ArrayList _collection;
    private int _index = 0;

    public Iterator(ArrayList collection)
    {
        _collection = collection;
    }

    public bool HasNext()
    {
        return _index < _collection.Count;
    }

    public object Next()
    {
        if (HasNext())
        {
            object next = _collection[_index];
            _index++;
            return next;
        }
        else
        {
            throw new InvalidOperationException("No more elements");
        }
    }
}

public class Collection
{
    private ArrayList _items = new ArrayList();

    public void AddItem(object item)
    {
        _items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new Iterator(_items);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Collection collection = new Collection();
        collection.AddItem("Item 1");
        collection.AddItem("Item 2");
        collection.AddItem("Item 3");

        IIterator iterator = collection.CreateIterator();

        while (iterator.HasNext())
        {
            string item = (string)iterator.Next();
            Console.WriteLine(item);
        }
    }
}
