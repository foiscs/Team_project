using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class option : MonoBehaviour {
    public int NowNum=1;
    public int NowNum_master = 1;
    public int NowNum_music= 1;
    public int NowNum_engine = 1;
    public int NowNum_fx = 1;
    public GameObject master;
    public GameObject music;
    public GameObject engine;
    public GameObject FX;
    public GameObject[] underline = new GameObject[4];
    public GameObject[] master_num = new GameObject[10];
    public GameObject[] music_num = new GameObject[10];
    public GameObject[] engine_num = new GameObject[10];
    public GameObject[] FX_num = new GameObject[10];

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        select_underline();
        Debug.Log(NowNum);
        master


    }
    public void select_underline()
    {
        if(NowNum==1)
        {
            underline[0].SetActive(true);
            underline[1].SetActive(false);
            underline[2].SetActive(false);
            underline[3].SetActive(false);
            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {

            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {

            }
            else if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }

        }
        else if (NowNum == 2)
        {
            underline[0].SetActive(false);
            underline[1].SetActive(true);
            underline[2].SetActive(false);
            underline[3].SetActive(false);
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
            }

        }
        else if (NowNum == 3)
        {
            underline[0].SetActive(false);
            underline[1].SetActive(false);
            underline[2].SetActive(true);
            underline[3].SetActive(false);
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
            }
        }
        else if (NowNum == 4)
        {
            underline[0].SetActive(false);
            underline[1].SetActive(false);
            underline[2].SetActive(false);
            underline[3].SetActive(true);
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
                
            }
        }
    }
}
