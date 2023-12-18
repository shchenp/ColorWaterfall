using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
   [SerializeField] private Grid _grid;
   [SerializeField] private GameObject _itemPrefab;
   [SerializeField] private int _itemCountHorizontal;
   [SerializeField] private int _itemCountVertical;
   [SerializeField] private float _spawnTime;

   private List<GameObject> _items;

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
            Debug.Log(item.transform.position);
            yield return new WaitForSeconds(_spawnTime);
         }
      }
      
   }

   private void OnDrawGizmos()
   {
      var cellSize = _grid.cellSize;
      var cellGap = _grid.cellGap;
      var origin = _grid.transform.position;
      
      Gizmos.color = Color.yellow;
      
      for (int x = 0; x < _itemCountHorizontal; x++)
      {
         for (int z = 0; z < _itemCountVertical; z++)
         {
            var position = origin + new Vector3(x * (cellSize.x + cellGap.x), 0, z * (cellSize.z + cellGap.z));
            
            Gizmos.DrawLine(position, position + new Vector3(cellSize.x, 0, 0));
            Gizmos.DrawLine(position, position + new Vector3(0, 0, cellSize.z));
            Gizmos.DrawLine(position + new Vector3(cellSize.x, 0, 0), position + new Vector3(cellSize.x, 0, cellSize.z));
            Gizmos.DrawLine(position + new Vector3(0, 0, cellSize.z), position + new Vector3(cellSize.x, 0, cellSize.z));
         }
      }
   }
}
