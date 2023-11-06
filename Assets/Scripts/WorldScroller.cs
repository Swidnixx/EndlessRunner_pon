using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroller : MonoBehaviour
{
    public Transform left, right; //Currently spawned in the Scene

    public Transform[] segmentPrefabs;

    private void Update()
    {
        float speed = GameManager.Instance.worldSpeed;
        Vector3 deltaPos = new Vector3( -speed * Time.deltaTime, 0, 0);
        left.position += deltaPos;
        right.Translate( deltaPos );

        if(right.position.x <= 0)
        {
            //swap tiles
            Destroy(left.gameObject);
            Vector3 spawnPos = right.position + new Vector3(18.47f, 0, 0);
            left = right;

            int randIndx = Random.Range(0, segmentPrefabs.Length);
            Transform newSegment = Instantiate(segmentPrefabs[randIndx], transform);
            newSegment.position = spawnPos;

            right = newSegment;
        }
    }
}
