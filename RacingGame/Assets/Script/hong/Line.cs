using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public Color lineColor;

    private List<Transform> line= new List<Transform>();

    private void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        Transform[] path = GetComponentsInChildren<Transform>(); //자기자신까지 집어넣음
        line = new List<Transform>();

        for (int i = 0; i < path.Length; i++)
        {
            if (path[i] != transform) //자기 자신 제외
            {
                line.Add(path[i]);
            }
        }

        for (int i = 0; i < line.Count; i++)
        {
            Vector3 current = line[i].position;
            Vector3 previous = line[line.Count-1].position;

            if (i > 0)
            {
                previous = line[i - 1].position;
            }
            Gizmos.DrawLine(previous, current);
        }
    }
}