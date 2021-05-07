using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //where the data from the tiles is kept
    Transform[] tiles;
    int index=1;
    //main object used to detect tiles
    public GameObject tilesParent;
    //used to see whether or not the tile puzzle is active
    bool mover=true;
    void Start()
    {
        tiles = tilesParent.GetComponentsInChildren<Transform>();
    }
    //Arch movement
    IEnumerator FollowArc(
        Transform mover,
        Vector2 start,
        Vector2 end,
        float radius, // Set this to negative if you want to flip the arc.
        float duration)
    {

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

        //
        if (mover)
        {
            if (Input.GetKeyDown(GameManager.Rkey) && tiles != null)
            {
                index++;
                if (index >= tiles.Length)
                    index = 0;//replace this with moving to a different scene or activate the tile stuff later on

                doJump(index);
                
            }
        }

        if(tiles[index].GetComponent<AccessPuzzle>()!=null)
        {
            tiles[index].GetComponent<AccessPuzzle>().SetChoice(true);
            mover = false;
        }
       
    }
    public void setPuzzleState(bool v)
    {
        mover =v;
    }
    public void doJump(int inde)
    {
        StartCoroutine(FollowArc(transform, transform.position, tiles[inde].position, (transform.position.x - tiles[inde].position.x) / 2, 1));

    }

}
