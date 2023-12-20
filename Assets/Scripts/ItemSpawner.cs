using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSpawner : MonoBehaviour
{
   [SerializeField] private Grid _grid;
   [SerializeField] private Item _itemPrefab;
   [SerializeField] private int _itemCountHorizontal;
   [SerializeField] private int _itemCountVertical;
   [SerializeField] private float _spawnTime;
   [SerializeField] private UnityEvent<Item> _onItemSpawned;

   private void Awake()
   {
      StartCoroutine(CreateItems());
   }
   
   

   private IEnumerator CreateItems()
   {
      for (int z = _itemCountVertical; z > 0; z--)
      {
         for (int x = 0; x < _itemCountHorizontal; x++)
         {
            var item = Instantiate(_itemPrefab, transform);
            item.transform.position = _grid.CellToWorld(new Vector3Int(x, 0, z));
            _onItemSpawned.Invoke(item);
            
            yield return new WaitForSeconds(_spawnTime);
         }
      }
      
   }
}
