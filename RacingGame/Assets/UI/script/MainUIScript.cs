﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIScript : MonoBehaviour {
    public int NowNum = 1;
    public int[] BtnNum = new int[3];
    public GameObject[] Btnbar = new GameObject[4];
    public GameObject After_P;
    public GameObject[] PlayBtnbar = new GameObject[3];
    public GameObject option_canvas;
    public GameObject mainmenu_canvas;
    public GameObject CarSelect_canvas;
    public GameObject upgrade_canvas;

<<<<<<< HEAD
    // Use this for initialization
    void Start()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        
=======
	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
>>>>>>> parent of 3c3dbee... 서버 업뎃
        First_btn();
        Debug.Log(NowNum);
	}
    public void First_btn()
    {
        if (NowNum == 1)
        {
            After_P.SetActive(false);
            if (Input.GetKeyUp(KeyCode.Return))
            {
                NowNum += 4;
                option_canvas.SetActive(false);
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
            if(Input.GetKeyUp(KeyCode.Return))
            {
                upgrade_canvas.SetActive(true);
                mainmenu_canvas.SetActive(false);
                option_canvas.SetActive(false);
            }
            
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
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
            if (Input.GetKeyUp(KeyCode.Return))
            {
                option_canvas.SetActive(true);
                mainmenu_canvas.SetActive(false);
            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
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
            else if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                NowNum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                mainmenu_canvas.SetActive(false);
                CarSelect_canvas.SetActive(true);
                
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
<<<<<<< HEAD
            //else if (Input.GetKeyUp(KeyCode.Return))
            //{
            //    mainmenu_canvas.SetActive(false);
            //    CarSelect_canvas.SetActive(true);

            //}

            PlayBtnbar[0].SetActive(false);
            PlayBtnbar[1].SetActive(true);
            PlayBtnbar[2].SetActive(false);
            PlayerPrefs.SetInt("car",0);
            if (Input.GetKey(KeyCode.Return))
                PhotonNetwork.JoinRandomRoom();
=======
            PlayBtnbar[0].SetActive(false);
            PlayBtnbar[1].SetActive(true);
            PlayBtnbar[2].SetActive(false);
>>>>>>> parent of 3c3dbee... 서버 업뎃
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
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                mainmenu_canvas.SetActive(false);
                CarSelect_canvas.SetActive(true);

            }
            PlayBtnbar[0].SetActive(false);
            PlayBtnbar[1].SetActive(false);
            PlayBtnbar[2].SetActive(true);

        }
            
        }
    }