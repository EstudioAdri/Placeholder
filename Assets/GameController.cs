using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int tileColumns;
    [SerializeField] int tileRows;
    [SerializeField] GameObject surfaceTile;
    [SerializeField] GameObject[,] tileMap;

    private void LoadTileMap(int _cols=0, int _rows=0)
    {
        if ((_cols == 0) || (_rows == 0))
        {
            throw new System.Exception("Wrong tileMap size");
        }

        if (tileMap is not null)
        {
            Tile[] _tileMap = FindObjectsOfType<Tile>();
            for (int i = 0; i < _tileMap.Length; i++)
            {
                Destroy(_tileMap[i].gameObject);
            }

            System.Array.Clear(tileMap, 0, tileMap.Length);
        }

        tileMap = new GameObject[_rows, _cols];

        for (int i = 0; i < tileColumns; i++)
        {
            for (int j = 0; j < tileRows; j++)
            {
                GameObject surfaceCube = Instantiate(surfaceTile, new Vector3(-1.5f * j, -1.5f * i, 0.0f), new Quaternion(0, 0, 0, 0));
                tileMap[j, i] = surfaceCube;
            }
        }
    }

    private void Awake()
    {
        LoadTileMap(tileColumns, tileRows);
    }

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            LoadTileMap(tileColumns, tileRows);
        }
    }
}
