using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 模拟ArraryList接口
/// </summary>
/// <typeparam name="T"></typeparam>
public interface INArraryList<T> where T : Object
{
	
	LinkedNode<T> StartNode { get; set; } //起始数据
	
	int Count { get; set; } //数据长度

	void Add(T obj); //增加数据
	
	void AddRange(ICollection collection);//添加一堆

	void Remove(T obj); //删除数据

	void RemoveAt(int index); //删除指定数据

	void RemoveRange(int min, int max); //删除范围内的元素

	bool Contains(T obj);//是否包含数据

	void Insert(int index,T value);//插入元素

	void Clear();//清空
}


/// <summary>
/// time:2019/7/6
/// author:Sun
/// des:重写ArraryList
///
/// 特点：
/// 1、长度不限
/// 2、元素类型Object
/// 
/// github:https://github.com/KingSun5
/// csdn:https://blog.csdn.net/Mr_Sun88
/// </summary>
public class NArraryList<T>: INArraryList<T> where T : Object
{
	public LinkedNode<T> StartNode { get; set; }
	
	public int Count { get; set; }
	
	/// <summary>
	/// 想NarraryList内添加元素
	/// </summary>
	/// <param name="obj"></param>
	public void Add(T obj)
	{
		if (StartNode==null)
		{
			StartNode = new LinkedNode<T>(obj);
			Count++;
			return;
		}

		LinkedNode<T> current = StartNode;
		while (current.Next!=null)
		{
			current = current.Next;
		}
		current.Next = new LinkedNode<T>(obj);
		Count++;
	}

	/// <summary>
	/// 添加一个组的元素
	/// </summary>
	/// <param name="collection"></param>
	/// <exception cref="NotImplementedException"></exception>
	public void AddRange(ICollection collection)
	{
		LinkedNode<T> current = StartNode;
		
		while (current.Next!=null)
		{
			current = current.Next;
		}

		foreach (T child in collection)
		{
			current.Next = new LinkedNode<T>(child);
			current = current.Next;
		}

		Count += collection.Count;
	}

	public void Remove(T obj)
	{

		if (!Contains(obj))
		{
			Debug.Log("not contain this obj！");
			return;
		}
		
		LinkedNode<T> current = StartNode;
		
		if (current.Data==obj)
		{
			Clear();
			return;
		}

		int _lenght = 1;
		bool _isExist = false;

		while (_lenght<Count)
		{
			if (current.Next.Data==obj)
			{
				if (current.Next.Next != null)
				{
					current.Next = current.Next.Next;
				}
				else
				{
					current.Next = null;
				}
				break;
			}
			_lenght++;
		}
	}

	public void RemoveAt(int index)
	{
		if (index>Count)
		{
			Debug.Log("out of range!");
			return;
		}

		LinkedNode<T> current = StartNode;

		if (index==1)
		{
			if (current.Next==null)
			{
				Clear();
			}
			else
			{
				StartNode = current.Next;
			}
			return;
		}
		int currentIndex = 1;

		while (currentIndex<Count)
		{
			currentIndex++;
			if (currentIndex==index)
			{
				if (current.Next != null && current.Next.Next!=null)
				{
					current.Next = current.Next.Next;
				}
				else
				{
					current.Next = null;
				}
			}
		
		}
	}

	public void RemoveRange(int min, int max)
	{
		if (min<1||max>Count||min>=max)
		{
			Debug.Log("out of range!");
			return;
		}

		if (min==1)
		{
			int currentIndex = 0;
			while (currentIndex<max)
			{
				StartNode = StartNode.Next;
				currentIndex++;
			}
			return;
		}
		
		LinkedNode<T> current = StartNode;
		
		int currentIndex2 = 1;
		while (currentIndex2<max)
		{
			currentIndex2++;
			if (currentIndex2>=min)
			{
				if (current != null && current.Next.Next!=null)
				{
					current.Next = current.Next.Next;
				}
				else
				{
					if (current != null) current.Next = null;
				}
			}
			else
			{
				if (current != null) current = current.Next;
			}
		}

	}

	public bool Contains(T obj)
	{
		bool isExist = false;
		LinkedNode<T> current = StartNode;
		int currentIndex = 0;
		while (currentIndex<Count)
		{
			currentIndex++;
			if (current.Data==obj)
			{
				isExist = true;
				break;
			}
			else
			{
				current = current.Next;
				currentIndex++;
			}
		}
		return isExist;
	}

	public void Insert(int index, T value)
	{
		if (index>Count)
		{
			Debug.Log("out of range!");
			return;
		}
		LinkedNode<T> node = new LinkedNode<T>(value);
		LinkedNode<T> current = StartNode;
		if (index==1)
		{
			StartNode = node;
			StartNode.Next = current;
			return;
		}
		int currentIndex = 1;
		while (true)
		{
			currentIndex++;
			if (currentIndex==index)
			{
				node.Next = current.Next.Next;
				current.Next = node;
				break;
			}
			current = current.Next;
		}
		
	}


	public void Clear()
	{
		throw new System.NotImplementedException();
	}
}




















