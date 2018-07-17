using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScp : MonoBehaviour {
    public GameObject target;
    // Update is called once per frame
    void Update () {
        transform.position = target.transform.position;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x,target.transform.localEulerAngles.y,transform.eulerAngles.z);
	}
}
