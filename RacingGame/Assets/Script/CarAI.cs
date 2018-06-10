using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour {

    public Color lineColor;

    private List<Transform> Line= new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        Transform[] path = GetComponentsInChildren<Transform>();
        Line = new List<Transform>();

        for (int i = 0; i < path.Length; i++)
        {
            if (path[i] != transform)
                Line.Add(path[i]);
        }

        for (int i = 0; i < Line.Count-1; i++)
        {
            Vector3 current = path[i].position;
            Vector3 next = path[i + 1].position;

            //if()
            {

            }
            Gizmos.DrawLine(current,next);
        }
    }
}
