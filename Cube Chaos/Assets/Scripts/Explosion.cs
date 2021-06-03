using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject cubeDestroyed;

    public void Explode()
    {
        gameObject.SetActive(false);

        GameObject cube = Instantiate(cubeDestroyed, gameObject.transform.position, Quaternion.identity);

        for (int i = 0; i < cube.transform.childCount; i++)
        {
            GameObject childGameObject = cube.transform.GetChild(i).gameObject;

            childGameObject.gameObject.GetComponent<Rigidbody>().AddForce(0, 0, 0.0005f, ForceMode.Impulse);
        }
    }
}