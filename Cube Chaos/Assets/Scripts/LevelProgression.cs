using UnityEngine;
using UnityEngine.UI;

public class LevelProgression : MonoBehaviour
{

    public Image uiFillImage;

    private GameObject player;
    private GameObject endPoint;

    private Vector3 endPointPosition;

    private float fullDistance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        endPoint = GameObject.FindGameObjectWithTag("EndPoint");
        endPointPosition = endPoint.transform.position;
        fullDistance = GetDistance();
    }

    void Update()
    {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(fullDistance, 0f, newDistance);

        UpdateProgress(progressValue);
    }

    private float GetDistance()
    {
        return Vector3.Distance(player.transform.position, endPointPosition);
    } 

    public void UpdateProgress (float value)
    {
        uiFillImage.fillAmount = value;
    }
}
