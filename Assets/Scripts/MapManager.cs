using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tile;

    public float tileSize
    {
        get { return tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x; }
    }

    public int xSize = 0;
    public int ySize = 0;

    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateLevel()
    {
        Vector3 worldOrigin = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height));

        for(int y = 0; y < ySize; ++y)
        {
            for(int x = 0; x < xSize; ++x)
            {
                PlaceTile(x, y, worldOrigin);
            }
        }
    }

    private void PlaceTile(int x, int y, Vector3 worldOrigin)
    {
        GameObject newTile = Instantiate(tile);
        newTile.transform.position = new Vector2(worldOrigin.x + (tileSize * x), worldOrigin.y - (tileSize * y));
    }
}
