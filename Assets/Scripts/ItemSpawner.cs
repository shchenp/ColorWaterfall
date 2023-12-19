using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
   [SerializeField] private Grid _grid;
   [SerializeField] private GameObject _itemPrefab;
   [SerializeField] private int _itemCountHorizontal;
   [SerializeField] private int _itemCountVertical;
   [SerializeField] private float _spawnTime;

   private List<GameObject> _items = new();

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
            _items.Add(item);
            
            yield return new WaitForSeconds(_spawnTime);
         }
      }
      
   }
}
