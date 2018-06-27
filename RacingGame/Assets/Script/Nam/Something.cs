using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Something : MonoBehaviour {

    public bool Ch;
    private void OnTriggerEnter(Collider other)
    {
        Debug.LogFormat("other.tag : {0}, Ch : {1}", other.tag, Ch);
        if(other.tag=="Player"&&Ch==false)
        {
            Ch = true;
        }
    }
}
