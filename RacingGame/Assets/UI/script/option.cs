using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class option : MonoBehaviour {
    private AudioSource sound;
    public GameObject MainSoundOB;
    public float MusicVolume;
    public int NowNum=1;
    public int NowNum_master = 9;
    public int NowNum_music = 9;
    public int NowNum_engine = 9;
    public int NowNum_fx = 9;
    public GameObject master;
    public GameObject music;
    public GameObject engine;
    public GameObject FX;
    public GameObject[] underline = new GameObject[4];
    public GameObject[] master_num = new GameObject[10];
    public GameObject[] music_num = new GameObject[10];
    public GameObject[] engine_num = new GameObject[10];
    public GameObject[] FX_num = new GameObject[10];
    public GameObject option_canvas;
    public GameObject mainmenu_canvas;

    // Use this for initialization
    void Start () {
        NowNum_master=PlayerPrefs.GetInt("master", 0);
        NowNum_music=PlayerPrefs.GetInt("music", 0);
        NowNum_engine=PlayerPrefs.GetInt("engine", 0);
        NowNum_fx=PlayerPrefs.GetInt("FX", 0);
        sound = MainSoundOB.GetComponent<AudioSource>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            mainmenu_canvas.SetActive(true);
            option_canvas.SetActive(false);
        }
        select_underline();
        master = master_num[NowNum_master];
        music = music_num[NowNum_music];
        engine = engine_num[NowNum_engine];
        FX = FX_num[NowNum_fx];
        master.SetActive(true);
        music.SetActive(true);
        engine.SetActive(true);
        FX.SetActive(true);
        volume_control();
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
                if(NowNum_master!=0)
                {
                    master.SetActive(false);
                    NowNum_master -= 1;
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (NowNum_master != 9)
                {
                    master.SetActive(false);
                    NowNum_master += 1;
                }
                
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
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if (NowNum_music != 0)
                {
                    music.SetActive(false);
                    NowNum_music -= 1;
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (NowNum_music != 9)
                {
                    music.SetActive(false);
                    NowNum_music += 1;
                }

            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
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
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if (NowNum_engine != 0)
                {
                    engine.SetActive(false);
                    NowNum_engine -= 1;
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (NowNum_engine != 9)
                {
                    engine.SetActive(false);
                    NowNum_engine += 1;
                }

            }
            else if (Input.GetKeyUp(KeyCode.DownArrow))
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
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                if (NowNum_fx != 0)
                {
                    FX.SetActive(false);
                    NowNum_fx -= 1;
                }
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                if (NowNum_fx != 9)
                {
                    FX.SetActive(false);
                    NowNum_fx += 1;
                }

            }
            else if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                NowNum -= 1;
            }
        }
    }
    public void volume_control()
    {
        PlayerPrefs.SetInt("master", NowNum_master);
        PlayerPrefs.SetInt("music", NowNum_music);
        PlayerPrefs.SetInt("engine", NowNum_engine);
        PlayerPrefs.SetInt("FX", NowNum_fx);
        MusicVolume = (float)NowNum_music / 9;



        sound.volume = MusicVolume;
    }
    
}
