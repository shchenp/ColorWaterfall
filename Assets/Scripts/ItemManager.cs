using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private float _timeBeforeColorizing;
    [SerializeField] private float _colorizingTime;
    
    private List<Item> _items = new();

    public void AddItem(Item item)
    {
        _items.Add(item);
    }

    public void StartChangeItemsColor()
    {
        StartCoroutine(ChangeItemsColor());
    }

    private IEnumerator ChangeItemsColor()
    {
        var color = Colorizer.GetColor();

        foreach (var item in _items)
        {
            item.StartChangeColor(color, _colorizingTime);
            yield return new WaitForSeconds(_timeBeforeColorizing);
        }
    }
}
