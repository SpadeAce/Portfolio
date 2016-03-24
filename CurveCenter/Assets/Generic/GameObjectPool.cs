using System.Collections;
using System.Collections.Generic;

/* 
 * Usage 
 *  
 * GameObjectPool<GameObject> monster_pool; 
 * ... 
 *  
 * // Create monsters. 
 * this.monster_pool = new GameObjectPool<GameObject>(5, () =>  
    {  
        GameObject obj = new GameObject("monster"); 
        return obj; 
    }); 
    ... 
    // Get from pool 
    GameObject obj = this.monster_pool.pop(); 
    ... 
    // Return to pool 
    this.monster_pool.push(obj); 
 * */

public class ObjectPoolDictionary<T,K> where K : class
{
    protected Dictionary<T, K> dictObject = new Dictionary<T,K>();
    public int Count { get { return dictObject.Count; } }
    public Dictionary<T, K>.ValueCollection Values { get { return dictObject.Values; } }
    public void Add(T _key, K _object)
    {
        dictObject[_key] = _object;
    }

    public void Remove(T _key)
    {
        if(dictObject.ContainsKey(_key))
            dictObject.Remove(_key);
    }

    public K Find(T _key)
    {
        K _findResult = default(K);
        if(dictObject.TryGetValue(_key, out _findResult) == true)
        {
            return _findResult;
        }

        return default(K);
    }

    public bool Contains(T _key)
    {
        return dictObject.ContainsKey(_key);
    }

    public bool ContainsObject(K _object)
    {
        return dictObject.ContainsValue(_object);
    }

    public void RefineNull()
    {
        List<T> listRemove = new List<T>();
        foreach(T _key in dictObject.Keys)
        {
            if(dictObject[_key] == null)
                listRemove.Add(_key);
        }

        for(int i=0;i<listRemove.Count;i++)
        {
            dictObject.Remove(listRemove[i]);
        }
    }
}

public class ObjectPool<T> where T : class
{
    // Instance count to create.  
    short count;

    public delegate T Func();
    Func create_fn;

    // Instances.  
    Stack<T> objects;

    // Construct  
    public ObjectPool(short count, Func fn)
    {
        this.count = count;
        this.create_fn = fn;
        this.objects = new Stack<T>(this.count);

        allocate();
    }

    void allocate()
    {
        for (int i = 0; i < this.count; ++i)
        {
            this.objects.Push(this.create_fn());
        }
    }

    public T pop()
    {
        if (this.objects.Count <= 0)
        {
            allocate();
        }

        return this.objects.Pop();
    }

    public void push(T obj)
    {
        this.objects.Push(obj);
    }
}