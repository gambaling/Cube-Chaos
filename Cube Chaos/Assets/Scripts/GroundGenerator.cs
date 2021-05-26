
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject prefabGround;
    public int distanceToRespawnGround;

    private Transform player;
    private Vector3 endOfGround;
    private LinkedList<GameObject> groundsSpawned;

    // Start is called before the first frame update
    void Start()
    {
        groundsSpawned = new LinkedList<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        GenerateGround();
    }

    // Update is called once per frame
    void Update()
    {
        VerifiesDistanceAndGenerateGround();
    }

    void GenerateGround()
    {
        GameObject generatedGround;
        GameObject actualGround = null;
        GameObject lastGroundOfQueue = null;

        if (groundsSpawned.Count != 0)
        {
            actualGround = groundsSpawned.Last.Value;
            lastGroundOfQueue = GetLastGroundOfQueue();
        }

        if (groundsSpawned.Count == 3)
        {
            lastGroundOfQueue.transform.position = new Vector3(0, 0, Convert.ToInt64(actualGround.transform.position.z + prefabGround.transform.localScale.z));
            generatedGround = lastGroundOfQueue;
        } else
        {
            Vector3 positionOfGround;
            if (groundsSpawned.Count == 0)
            {
                positionOfGround = new Vector3(0, 0, Convert.ToInt64(prefabGround.transform.localScale.z / 2) - 3);
            } else
            {
                positionOfGround = new Vector3(0, 0, Convert.ToInt64(actualGround.transform.position.z + prefabGround.transform.localScale.z));
            }
            generatedGround = Instantiate(prefabGround, positionOfGround, Quaternion.identity);
            generatedGround.name = $"Ground {groundsSpawned.Count}";
            groundsSpawned.AddLast(generatedGround);
        }

        endOfGround = generatedGround.transform.GetChild(0).transform.position;

        generatedGround.GetComponent<ObstacleGenerator>().RefreshObstacle();
    }

    GameObject GetLastGroundOfQueue()
    {
        if (groundsSpawned.Count == 0) return null;

        GameObject seletedGround = groundsSpawned.Last.Value;

        if (groundsSpawned.Count == 3)
        {
            seletedGround = groundsSpawned.First.Value;
            groundsSpawned.RemoveFirst();
            groundsSpawned.AddLast(seletedGround);
        }

        return seletedGround;
    }

    void VerifiesDistanceAndGenerateGround()
    {
        int distance = Convert.ToInt32(Vector3.Distance(player.position, endOfGround));

        if (distance == distanceToRespawnGround)
        {
            GenerateGround();
        }
    }
}
