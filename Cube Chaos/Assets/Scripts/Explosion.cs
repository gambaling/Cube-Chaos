using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject cubeDestroyed;

    public void Explode()
    {
        //make object disappear
        gameObject.SetActive(false);

        GameObject cube = Instantiate(cubeDestroyed, gameObject.transform.position, Quaternion.identity);
        float xVelocity = 0f;

        for (int i = 0; i < cube.transform.childCount; i++)
        {
            GameObject childGameObject = cube.transform.GetChild(i).gameObject;

            childGameObject.gameObject.GetComponent<Rigidbody>().AddForce(xVelocity, 0, 0.0005f, ForceMode.Impulse);
        }
    }
}