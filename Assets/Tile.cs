using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool mouseOver;
    [SerializeField] GameObject tileBuilding;
    public int rowPos;
    public int colPos;

    private void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    private void OnMouseDown()
    {
        Vector3 position = transform.position;
        position.z -= 1.5f;

        Instantiate(tileBuilding, position, transform.rotation, transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
