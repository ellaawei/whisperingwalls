//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class SlidingPuzzleScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] TileScript[] tiles;
    private int emptySpaceIndex = 8;
    public bool hasWon;

    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
        hasWon = false;
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                Debug.Log(hit.transform.name);
                if (Vector2.Distance(emptySpace.position, hit.transform.position) < 0.25f)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TileScript thisTile = hit.transform.GetComponent<TileScript>();
                    emptySpace.position = hit.transform.position;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileIndex = FindIndex(thisTile);
                    Debug.Log(emptySpaceIndex + " " + tileIndex);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                }
            }
        }
        int correctTiles = 0;
        foreach(var a in tiles)
        {
            if (a != null)
            {
                if (a.inRightPlace)
                    correctTiles++;
            }
        }
        if(correctTiles == tiles.Length - 1)
        {
            Debug.Log("won");
            hasWon = true;
        }

        if (hasWon)
        {
            //change the scene here
            MainGameManager.instance.addKey(1);
            MainGameManager.instance.NextLevel(0);
        }
    }
    public void Shuffle()
    {
        if(emptySpaceIndex != 8)
        {
            var tileOn9LastPos = tiles[8].targetPosition;
            tiles[8].targetPosition = emptySpace.position;
            emptySpace.position = tileOn9LastPos;
            tiles[emptySpaceIndex] = tiles[8];
            tiles[8] = null;
            emptySpaceIndex = 9;
        }
        int invertion;
        do
        {
            for (int i = 0; i < 9; i++)
            {
                Debug.Log(i);
                if (tiles[i] != null)
                {
                    var lastPos = tiles[i].targetPosition;
                    int randomIndex = Random.Range(0, 7);
                    tiles[i].targetPosition = tiles[randomIndex].targetPosition;
                    tiles[randomIndex].targetPosition = lastPos;
                    var tile = tiles[i];
                    tiles[i] = tiles[randomIndex];
                    tiles[randomIndex] = tile;
                }
            }
            invertion = GetInversions();
            Debug.Log("Puzzle Shuffled");
        } while (invertion % 2 != 0);
    }
    public int FindIndex(TileScript ts)
    {
        for(int i  = 0; i < tiles.Length;i++)
        {
            Debug.Log(tiles[i]);
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }
    int GetInversions()
    {
        int inversionsSum = 0;
        for(int i = 0; i < tiles.Length;i++)
        {
            int thisTileInvertion = 0;
            for(int j = i; j < tiles.Length; j++){
                if (tiles[j] != null)
                {
                    if (tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }
}
