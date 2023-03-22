using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    [SerializeField] int tileRows;
    [SerializeField] int tileColumns;
    [SerializeField] GameObject[,] tileMap;
    [SerializeField] List<GameObject> tilePrefabs;

    public enum tileType { Cube, Capsule }

    private GameObject initTile(tileType _tileType, int _rowPos, int _colPos)
    {
        GameObject newTileGo = Instantiate(tilePrefabs[(int)_tileType],
                                    new Vector3(1.5f * _colPos, 1.5f * _rowPos, 0.0f),
                                    new Quaternion(0, 0, 0, 0), transform);

        newTileGo.GetComponent<Tile>().rowPos = _rowPos;
        newTileGo.GetComponent<Tile>().colPos = _colPos;
        newTileGo.GetComponent<Tile>().tileType = _tileType.ToString();

        return newTileGo;
    }

    private void LoadTileMap(int _rows = 0, int _cols = 0)
    {
        if ((_rows == 0) || (_cols == 0))
        {
            throw new System.Exception("Wrong tileMap size");
        }

        if (tileMap is not null)
        {
            Tile[] _tile = FindObjectsOfType<Tile>();
            for (int i = 0; i < _tile.Length; i++)
            {
                Destroy(_tile[i].gameObject);
            }

            System.Array.Clear(tileMap, 0, tileMap.Length);
        }

        tileMap = new GameObject[_rows, _cols];

        for (int i = 0; i < tileColumns; i++)
        {
            for (int j = 0; j < tileRows; j++)
            {
                tileMap[j, i] = initTile(tileType.Cube, j, i);
            }
        }
    }

    private void Awake()
    {
        LoadTileMap(tileRows, tileColumns);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            LoadTileMap(tileRows, tileColumns);
        }
    }
}