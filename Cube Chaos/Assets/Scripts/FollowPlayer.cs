using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset;

    private Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
