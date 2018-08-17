using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPrefab : MonoBehaviour
{
    private Object[] mapObject;
    private GameObject go;
    public GameObject parent;

    public Shader Guardrail;
    public Shader Road;
    public Shader transhadowMarker;

    public List<GameObject> list = new List<GameObject>();

    public string folder;
    void Start()
    {
        mapObject = Resources.LoadAll(folder, typeof(GameObject));
        foreach (var t in mapObject)
        {
            Object temp = Instantiate(t, parent.transform);
        }
        Debug.Log(parent.transform.childCount);
        for (int i = 0; i < parent.transform.childCount; i++)
        {
            if (parent.transform.GetChild(i).childCount != 0)
                list.Add(parent.transform.GetChild(i).GetChild(0).gameObject);
        }
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].name == "Pavement")
                list[i].GetComponent<Renderer>().material.shader = Road;
            else if (string.Compare(list[i].name, 0, "SCut", 0, 4) == 0)
                list[i].GetComponent<Renderer>().material.shader = Road;
            else if (string.Compare(list[i].name, 0, "RoadCut", 0, 7) == 0)
                list[i].GetComponent<Renderer>().material.shader = Road;
            else if (string.Compare(list[i].name, 0, "GSDAtten_Static", 0, 15) == 0)
                list[i].GetComponent<Renderer>().material.shader = Guardrail;
            else if (string.Compare(list[i].name, 0, "GSDWBeam", 0, 8) == 0)
                list[i].GetComponent<Renderer>().material.shader = Guardrail;
            else if (string.Compare(list[i].name, 0, "Markers", 0, 7) == 0)
                list[i].GetComponent<Renderer>().material.shader = transhadowMarker;
            else if (string.Compare(list[i].name, 0, "RoadMesh", 0, 8) == 0)
                list[i].GetComponent<Renderer>().material.shader = transhadowMarker;

        }

    }
}
