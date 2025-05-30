using System;
using System.Collections.Generic;

public class BinaryTree<T> where T : IComparable<T>
{
    public class Node
    {
        public T Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(T data)
        {
            Data = data;
            Left = null;
            Right = null;
        }
    }

    public Node Root { get; private set; }

    // Создание идеально сбалансированного дерева
    public void CreateBalancedTree(List<T> items)
    {
        items.Sort();
        Root = CreateBalancedTreeHelper(items, 0, items.Count - 1);
    }

    private Node CreateBalancedTreeHelper(List<T> items, int start, int end)
    {
        if (start > end) return null;

        int mid = (start + end) / 2;
        var node = new Node(items[mid]);

        node.Left = CreateBalancedTreeHelper(items, start, mid - 1);
        node.Right = CreateBalancedTreeHelper(items, mid + 1, end);

        return node;
    }

    // Вывод дерева по уровням
    public void PrintByLevels()
    {
        if (Root == null) return;

        Queue<Node> queue = new Queue<Node>();
        queue.Enqueue(Root);

        Console.WriteLine("Дерево по уровням:");
        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            Console.WriteLine(current.Data);

            if (current.Left != null) queue.Enqueue(current.Left);
            if (current.Right != null) queue.Enqueue(current.Right);
        }
    }

    // Удаление элемента по ключу
    public bool Remove(T key)
    {
        Root = RemoveHelper(Root, key);
        return true;
    }

    private Node RemoveHelper(Node node, T key)
    {
        if (node == null) return null;

        if (key.CompareTo(node.Data) < 0)
            node.Left = RemoveHelper(node.Left, key);
        else if (key.CompareTo(node.Data) > 0)
            node.Right = RemoveHelper(node.Right, key);
        else
        {
            if (node.Left == null) return node.Right;
            if (node.Right == null) return node.Left;

            node.Data = FindMin(node.Right).Data;
            node.Right = RemoveHelper(node.Right, node.Data);
        }

        return node;
    }

    private Node FindMin(Node node)
    {
        while (node.Left != null)
            node = node.Left;
        return node;
    }

    // Поиск минимального элемента
    public T FindMinimum()
    {
        if (Root == null) throw new InvalidOperationException("Дерево пустое.");
        return FindMin(Root).Data;
    }

    // Очистка дерева
    public void Clear()
    {
        Root = null;
    }
}