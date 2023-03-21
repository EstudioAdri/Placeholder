using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int tileRows;
    [SerializeField] int tileColumns;
    [SerializeField] GameObject surfaceTile;
    [SerializeField] GameObject[,] tileMap;

    private void LoadTileMap(int _rows=0, int _cols=0)
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
                GameObject surfaceCube = Instantiate(surfaceTile, new Vector3(1.5f * i, 1.5f * j, 0.0f), new Quaternion(0, 0, 0, 0), transform);
                surfaceCube.GetComponent<Tile>().rowPos = j;
                surfaceCube.GetComponent<Tile>().colPos = i;

                tileMap[j, i] = surfaceCube;
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
