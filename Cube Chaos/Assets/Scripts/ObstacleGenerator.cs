using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    private static string SIMPLE_CUBE = "SimpleCube";
    private static string SIMPLE_RECTANGLE = "SimpleRectangle";
    private static string BIG_RECTANGLE = "BigRectangle";

    [Range(1, 100)]
    public int percentOfObstacles = 1;

    public void RefreshObstacle()
    {
        EnableObstacle(getChildWithTag(SIMPLE_CUBE));
        EnableObstacle(getChildWithTag(SIMPLE_RECTANGLE));
        EnableObstacle(getChildWithTag(BIG_RECTANGLE));
    }

    private void EnableObstacle(List<GameObject> obstacles)
    {
        int totalObstacle = obstacles.Count;
        List<int> listIndexOfObstacles = new List<int>();
        int numberRandomized;
        int numberOfObstaclesWillBeGenerated = Convert.ToInt32((totalObstacle * percentOfObstacles) / 100);
        System.Random rand = new System.Random();

        DisableObstacles(obstacles);

        for (int i = 0; i < numberOfObstaclesWillBeGenerated; i++)
        {
            do
            {
                numberRandomized = rand.Next(0, totalObstacle);
            } while (listIndexOfObstacles.Contains(numberRandomized));
            listIndexOfObstacles.Add(numberRandomized);
        }

        foreach (var indexObstacle in listIndexOfObstacles)
        {
            obstacles[indexObstacle].SetActive(true);
        }

    }

    private void DisableObstacles(List<GameObject> obstacles)
    {
        foreach (var obstacle in obstacles)
        {
            obstacle.SetActive(false);
        }
    }

    private List<GameObject> getChildWithTag(string tagName)
    {
        List<GameObject> childs = new List<GameObject>();

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject childGameObject = gameObject.transform.GetChild(i).gameObject;
            if (childGameObject.tag.Equals(tagName))
            {
                for (int j = 0; j < childGameObject.transform.childCount; j++)
                {
                    childs.Add(childGameObject.transform.GetChild(j).gameObject);
                }
            }
        }

        return childs;
    }
}
