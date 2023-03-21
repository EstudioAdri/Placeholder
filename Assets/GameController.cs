using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] int rows;
    [SerializeField] int columns;
    [SerializeField] GameObject surface;

    void Start()
    {
        GameObject surfaceCube = Instantiate(surface, new Vector3(0.0f, 0.0f, 0.0f), new Quaternion(0, 0, 0, 0));
        surfaceCube.transform.localScale = new Vector3(1.0f, 1.0f, 0.1f);
    }

    void Update()
    {
        
    }
}
