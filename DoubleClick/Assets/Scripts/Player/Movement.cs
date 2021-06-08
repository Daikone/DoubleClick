using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //where the data from the tiles is kept
    List<Transform> tiles;

    public Transform Path1;
    public Transform Path2;
    
    public int index=1;
    int pathIndex=1;
    bool pathselected = false;
    //main object used to detect tiles
    public GameObject tilesParent;
    //used to see whether or not the tile puzzle is active
    bool mover=true;
    //animator
    Animator anime;
    //click counter for triggering the puzzle
    int count=0;
    public float countSelect;
    float countSelectS;
    public Image dialogueBox;

    public SpriteRenderer p1Renderer;
    public SpriteRenderer p2Renderer;
    void Start()
    {
        tiles = new List<Transform>();
        foreach(Transform r in tilesParent.GetComponentsInChildren<Transform>())
        tiles.Add(r);

        anime = GetComponent<Animator>();
        GameManager.canMove = false;
        countSelectS = countSelect;
       
    }
    //Arch movement enumerator. DO NOT TOUCH
    IEnumerator FollowArc(Transform mover,Vector2 start,
        Vector2 end,float radius, // Set this to negative if you want to flip the arc.
        float duration)
    {
        anime.SetBool("isJumping", true);
        Vector2 difference = end - start;
        float span = difference.magnitude;

        // Override the radius if it's too small to bridge the points.
        float absRadius = Mathf.Abs(radius);
        if (span > 2f * absRadius)
            radius = absRadius = span / 2f;

        Vector2 perpendicular = new Vector2(difference.y, -difference.x) / span;
        perpendicular *= Mathf.Sign(radius) * Mathf.Sqrt(radius * radius - span * span / 4f);

        Vector2 center = start + difference / 2f + perpendicular;

        Vector2 toStart = start - center;
        float startAngle = Mathf.Atan2(toStart.y, toStart.x);

        Vector2 toEnd = end - center;
        float endAngle = Mathf.Atan2(toEnd.y, toEnd.x);

        // Choose the smaller of two angles separating the start & end
        float travel = (endAngle - startAngle + 5f * Mathf.PI) % (2f * Mathf.PI) - Mathf.PI;

        float progress = 0f;
        do
        {
            float angle = startAngle + progress * travel;
            mover.position = center + new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * absRadius;
            progress += Time.deltaTime / duration;
            yield return null;
        } while (progress < 1f);

        mover.position = end;
    }
    // Update is called once per frame
    void Update()
    {
       
        if (!pathselected)
        {
            if (pathIndex == 1)
            {
                p2Renderer.color = new Color(p2Renderer.color.r, p2Renderer.color.g, p2Renderer.color.b, 0.5f);
                p2Renderer.transform.localScale = new Vector3(1, 1, 1);
                
                p1Renderer.color = new Color(p1Renderer.color.r, p1Renderer.color.g, p1Renderer.color.b, 1f);
                p1Renderer.transform.localScale = new Vector3(1.4f, 1.4f, 1);
            }
            if(pathIndex==2)
            {
                p1Renderer.color = new Color(p1Renderer.color.r, p1Renderer.color.g, p1Renderer.color.b, 0.5f);
                p1Renderer.transform.localScale = new Vector3(1, 1, 1);

                p2Renderer.color = new Color(p2Renderer.color.r, p2Renderer.color.g, p2Renderer.color.b, 1f);
                p2Renderer.transform.localScale = new Vector3(1.4f, 1.4f, 1);
            }
            countSelect -= Time.deltaTime;
            if (countSelect <= 0)
            {
                if (pathIndex == 1)
                    pathIndex = 2;
                else
                    pathIndex = 1;
                countSelect = countSelectS;
            }
            if (Input.GetKeyDown(GameManager.Rkey))
            {
                if (pathIndex == 1)
                {
                    TakeOutofParent(Path1,Path2);
                    
                }
                if(pathIndex==2)
                {
                    TakeOutofParent(Path2, Path1);
                    
                }

                dialogueBox.transform.gameObject.SetActive(false);
                pathselected = true;

            }
            Debug.Log($"It's time for path no. {pathIndex}");
        }
        //jumping to the next tile
        if (GameManager.canMove)
        {
            if ( tiles != null)
            {
                index++;
                if (index >= tiles.Count)
                    index = 0;

                doJump(index);
                GameManager.canMove = false;
            }
            
        }
        //sets the animation from jumping to idle
        if(transform.position==tiles[index].position)
            anime.SetBool("isJumping", false);
        //Activation of the tiles
        if (tiles[index].GetComponent<AccessPuzzle>()!=null && transform.position==tiles[index].position)
        {
               tiles[index].GetComponent<AccessPuzzle>().StartPuzzle();
        }
        else
            mover = true;
        //activates the end sequence and save function
        if (tiles[index].GetComponent<WonTileScript>() != null && transform.position == tiles[index].position)
        {
            if (mover)
            {
                GameManager.canMove = false;
            }
            mover = false;
            if (Input.GetKeyDown(GameManager.Rkey))
                count++;
            if(count==0)
                tiles[index].GetComponent<WonTileScript>().ShowMessage();
            if (count == 1)
            {
                tiles[index].GetComponent<WonTileScript>().ClickSet(tiles[index].GetComponent<WonTileScript>().SaveIndex);
                tiles[index].GetComponent<WonTileScript>().SaveMethod();
                SceneManager.LoadScene("AdventureModeMenu");
                
            }
            
        }


    }
    public void setPuzzleState(bool v)
    {
        mover =v;
    }

    private void redoList()
    {
        tiles.Clear();
        foreach (Transform r in tilesParent.GetComponentsInChildren<Transform>())
        {
            if(r!=null)
                tiles.Add(r);
        }
            
    }
    //function used to jump to a new tile
    public void doJump(int inde)
    {
        StartCoroutine(FollowArc(transform, transform.position, tiles[inde].position, (transform.position.x - tiles[inde].position.x) / 2, 1));

    }
    void TakeOutofParent(Transform selected, Transform unselected)
    {   unselected.parent = null;
        unselected.gameObject.layer = 0;
        foreach (Transform t in selected.GetComponentsInChildren<Transform>())
        {
            t.parent = tilesParent.transform;
        }
        foreach (Transform t in unselected.GetComponentsInChildren<Transform>())
        {
            t.gameObject.layer=0;
            tiles.Remove(t);
        }
        tiles.Remove(selected);
        tiles.Remove(unselected);
        Destroy(selected.gameObject);

        GameManager.canMove = true;
    }

}
