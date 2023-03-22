using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject tileBuilding;
    private MeshRenderer meshRenderer;
    private Color originalColor;
    private Color mouseOverColor = Color.red;
    public int rowPos;
    public int colPos;

    private void OnMouseOver()
    {
        //  Vector3[] _vertices = GetComponent<MeshFilter>().mesh.vertices;
        if (meshRenderer.isVisible)
        {
            meshRenderer.material.color = mouseOverColor;
        }
        
    }

    private void OnMouseExit()
    {
        meshRenderer.material.color = originalColor;
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
        meshRenderer = GetComponent<MeshRenderer>();
        originalColor = meshRenderer.material.color;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
