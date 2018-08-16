using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMG : MonoBehaviour {

    private AudioSource sound;
    public GameObject MainSoundOB;
    public float MainVolume;


	// Use this for initialization
	void Start () {
        sound = MainSoundOB.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
