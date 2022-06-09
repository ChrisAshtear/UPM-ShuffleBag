using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System;
/**
 * @author Esko Luontola
 * @since 25.2.2008
 */
public class ShuffleBag<T>
{

    private System.Random random;

    /**
     * Unused values are in the range {@code 0 <= index < cursor}.
     * Used values are in the range {@code cursor <= index < values.size()}.
     */
    protected List<T> values = new List<T>();
    private int cursor = 0;

    public ShuffleBag()
    {
        System.Random random = new System.Random();
        this.random = random;
    }

    public ShuffleBag(System.Random random)
    {
        this.random = random;
    }

    public void add(T value)
    {
        values.Add(value);
    }

    public T get()
    {
        if (values.Count == 0)
        {
            Debug.Log("bag is empty");
        }
        int grab = randomUnused();
        T value = values[grab];
        markAsUsed(grab);
        return value;
    }

    private int randomUnused()
    {
        if (cursor <= 0)
        {
            cursor = values.Count;
        }

        return random.Next(cursor);
    }

    private void markAsUsed(int indexOfUsed)
    {
        cursor--;
        swap(values, indexOfUsed, cursor);
    }

    private static void swap(List<T> list, int x, int y)
    {
        T tmp = list[x];
        list[x] =  list[y];
        list[y] = tmp;
    }

    public void addMany(T value, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            add(value);
        }
    }

    public List<T> getMany(int quantity)
    {
        List<T> results = new List<T>(quantity);
        for (int i = 0; i < quantity; i++)
        {
            results.Add(get());
        }
        return results;
    }
}