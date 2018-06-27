using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRap : MonoBehaviour {

    public GameObject Someting;
    public Text Tx;
    public int i;

    GameObject Car;
	void Start () {
        i = 0;
        Tx.text = "Rap:" + i;
	}
	
	// Update is called once per frame
	void Update () {
        Tx.text = "Rap:" + i;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Someting.GetComponent<Something>().Ch = false;
        Debug.LogFormat("other.tag : {0}, Ch : {1}", other.tag, Someting.GetComponent<Something>().Ch );
        if (other.tag == "Player"&& Someting.GetComponent<Something>().Ch == true)
        {
            Debug.Log("check");
            i++;
            Someting.GetComponent<Something>().Ch = false;
      
        }
    }
}
