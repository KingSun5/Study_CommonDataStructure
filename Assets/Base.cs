
#region ------------------------固定长度的顺序存储结构-------------------------

/// <summary>
/// 固定长度的顺序存储结构
/// </summary>
/// <typeparam name="T"></typeparam>
public class SeqStructure<T>
{
    private T[] _data;
    private int _i;

    public SeqStructure(int size)
    {
        _data = new T[size];
    }

    public void AddData(T var)
    {
        _data[_i++] = var;
    }
}

#endregion -----------------------------------------------------------------

#region ----------------------------单向链式结构-----------------------------


/// <summary>
/// 单向链式结构基础元素
/// </summary>
/// <typeparam name="T"></typeparam>
public class LinkedNode<T>
{
    private T _data;


    private LinkedNode<T> _next;

    public LinkedNode()
    {
        _data = default(T);
        _next = null;
    }

    public LinkedNode(T val)
    {
        _data = val;
        _next = null;
    }

    public T Data
    {
        get { return _data; }
        set { _data = value; }
    }

    public LinkedNode<T> Next
    {
        get { return _next; }
        set { _next = value; }
    }
}

class LinkedStructure<T>
{
    private LinkedNode<T> _first;
    private LinkedNode<T> _current;

    public LinkedStructure()
    {
        _first = null;
    }

    public void AddData(LinkedNode<T> var)
    {
        if (_first==null)
        {
            _first = var;
            _current = var;
        }
        else
        {
            _current.Next = var;
            _current = var;
        }
    }
}


#endregion -----------------------------------------------------------------

#region ----------------------------双向链式结构-----------------------------

public class DbNode<T>
{
    private T _data;//数据

    private DbNode<T> _prev;//前驱引用域
    private DbNode<T> _next;//后驱引用域

    public DbNode(T val, DbNode<T> p)
    {
        _data = val;
        _next = p;
    }

    public DbNode(DbNode<T> p)
    {
        _next = p;
    }

    public DbNode(T val)
    {
        _data = val;
        _next = null;
    }

    public DbNode()
    {
        _data = default(T);
        _next = null;
    }

    public T Data
    {
        get { return _data; }
        set { _data = value; }
    }


    public DbNode<T> Prev
    {
        get { return _prev; }
        set { _prev = value; }
    }

    public DbNode<T> Next
    {
        get { return _next; }
        set { _next = value; }
    }
}



#endregion -----------------------------------------------------------------



























