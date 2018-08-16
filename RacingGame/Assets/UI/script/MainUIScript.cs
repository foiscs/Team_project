using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIScript : MonoBehaviour {
    public int NowNum = 1;
    public int[] BtnNum = new int[3];
    public GameObject[] Btnbar = new GameObject[4];
    public GameObject After_P;
    public GameObject[] PlayBtnbar = new GameObject[3];

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        First_btn();
        Debug.Log(NowNum);
	}
    public void First_btn()
    {
        if (NowNum == 1)
        {
            After_P.SetActive(false);
            if (Input.GetKeyUp(KeyCode.Space))
            {
                NowNum += 4;
                After_P.SetActive(true);
                

            }

            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            Btnbar[0].SetActive(true);
            Btnbar[1].SetActive(false);
            Btnbar[2].SetActive(false);
            Btnbar[3].SetActive(false);
            PlayBtnbar[0].SetActive(false);
            PlayBtnbar[1].SetActive(false);
            PlayBtnbar[2].SetActive(false);

        }
        else if (NowNum == 2)
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
            }
            Btnbar[0].SetActive(false);
            Btnbar[1].SetActive(true);
            Btnbar[2].SetActive(false);
            Btnbar[3].SetActive(false);
        }
        else if (NowNum == 3)
        {
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
            }
            Btnbar[0].SetActive(false);
            Btnbar[1].SetActive(false);
            Btnbar[2].SetActive(true);
            Btnbar[3].SetActive(false);
        }
        else if (NowNum == 4)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
            }
            Btnbar[0].SetActive(false);
            Btnbar[1].SetActive(false);
            Btnbar[2].SetActive(false);
            Btnbar[3].SetActive(true);
        }
        else if (NowNum == 5)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                NowNum = 1;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            PlayBtnbar[0].SetActive(true);
            PlayBtnbar[1].SetActive(false);
            PlayBtnbar[2].SetActive(false);
            Btnbar[0].SetActive(false);
            Btnbar[1].SetActive(false);
            Btnbar[2].SetActive(false);
            Btnbar[3].SetActive(false);
        }
        else if(NowNum==6)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                NowNum = 1;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
            }
            PlayBtnbar[0].SetActive(false);
            PlayBtnbar[1].SetActive(true);
            PlayBtnbar[2].SetActive(false);
        }
        else if(NowNum==7)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                NowNum = 1;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
            }
            PlayBtnbar[0].SetActive(false);
            PlayBtnbar[1].SetActive(false);
            PlayBtnbar[2].SetActive(true);

        }
            
        }
    }