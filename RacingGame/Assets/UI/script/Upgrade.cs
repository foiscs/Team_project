using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Upgrade : MonoBehaviour {
    public GameObject Lines;
    public Text money;
    public Text CarName;
    public Text car_info;
    public int havemoney=0;
    public int carnum = 1;
    public GameObject[] car = new GameObject[4];
    public GameObject main_canvas;
    public GameObject upgrade_canvas;
    public int AV_H=0;
    public int AV_AC=0;
    public int AV_SP=0;
    public int LA_H=1;
    public int LA_AC=1;
    public int LA_SP=1;
    public int NS_H=2;
    public int NS_AC=2;
    public int NS_SP=2;
    public int VN_H=3;
    public int VN_AC=3;
    public int VN_SP = 3;
    public GameObject[] UP_circle= new GameObject[3];




    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Debug.Log(carnum);
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (carnum == 1 || carnum == 2 || carnum == 3 || carnum == 4)
            {
                carnum = 1;
                main_canvas.SetActive(true);
                upgrade_canvas.SetActive(false);
            }
        }
        if (carnum == 1)
        {
            Lines.SetActive(false);
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(false);
            car[1].SetActive(false);
            car[2].SetActive(false);
            car[3].SetActive(false);
            car[0].SetActive(true);
            if(Input.GetKeyUp(KeyCode.Return))
            {
                carnum = 5;
                Lines.SetActive(true);
            }
            CarName.text = "Aventador";
            car_info.text = "" + AV_H + "\n\n" + AV_AC+"\n\n"+AV_SP;
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
        }
        else if (carnum == 2)
        {
            Lines.SetActive(false);
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(false);
            car[2].SetActive(false);
            car[3].SetActive(false);
            car[0].SetActive(false);
            car[1].SetActive(true);
            CarName.text = "LaFerrari";
            car_info.text = "" + LA_H + "\n\n" + LA_AC + "\n\n" + LA_SP;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                carnum = 8;
                Lines.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }

            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
        }
        else if (carnum == 3)
        {
            Lines.SetActive(false);
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(false);
            car[3].SetActive(false);
            car[0].SetActive(false);
            car[1].SetActive(false);
            car[2].SetActive(true);
            CarName.text = "NissanGTR";
            car_info.text = "" + NS_H + "\n\n" + NS_AC + "\n\n" + NS_SP;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                carnum = 11;
                Lines.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
        }

        else if (carnum == 4)
        {
            Lines.SetActive(false);
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(false);
            car[3].SetActive(true);
            car[0].SetActive(false);
            car[1].SetActive(false);
            car[2].SetActive(false);
            CarName.text = "VenomGT";
            car_info.text = "" + VN_H + "\n\n" + VN_AC + "\n\n" + VN_SP;
            if (Input.GetKeyUp(KeyCode.Return))
            {
                carnum = 8;
                Lines.SetActive(true);
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
        }
        else if(carnum==5)//아반테 업글 5~7
        {
            UP_circle[0].SetActive(true);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(false);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 1;
            }
            else if(Input.GetKeyUp(KeyCode.Return))
            {
                AV_H += 1;
            }
        }
        else if (carnum == 6)
        {
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(true);
            UP_circle[2].SetActive(false);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 1;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                AV_AC += 1;
            }
        }
        else if (carnum == 7)
        {
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(true);

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 1;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                AV_SP += 1;
            }
        }
        else if (carnum == 8)//라페라리 업글 8~10
        {
            UP_circle[0].SetActive(true);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(false);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 2;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                LA_H += 1;
            }
        }
        else if (carnum == 9)
        {
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(true);
            UP_circle[2].SetActive(false);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 2;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                LA_AC += 1;
            }
        }
        else if (carnum == 10)
        {
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(true);

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 2;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                LA_SP += 1;
            }
        }
        else if (carnum == 11)//니산 업글 11~13
        {
            UP_circle[0].SetActive(true);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(false);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 3;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                NS_H += 1;
            }
        }
        else if (carnum == 12)
        {
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(true);
            UP_circle[2].SetActive(false);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 3;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                NS_AC += 1;
            }
        }
        else if (carnum == 13)
        {
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(true);

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 3;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                NS_SP += 1;
            }
        }
        else if (carnum == 14)//베놈 업글 14~16
        {
            UP_circle[0].SetActive(true);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(false);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 4;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                VN_H += 1;
            }
        }
        else if (carnum == 15)
        {
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(true);
            UP_circle[2].SetActive(false);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 4;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                VN_AC += 1;
            }
        }
        else if (carnum == 16)
        {
            UP_circle[0].SetActive(false);
            UP_circle[1].SetActive(false);
            UP_circle[2].SetActive(true);

            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                carnum = 4;
            }
            else if (Input.GetKeyUp(KeyCode.Return))
            {
                VN_SP += 1;
            }
        }
        money.text = ""+havemoney;
        if(carnum==5|| carnum == 6 || carnum == 7)
        {
            car_info.text = "" + AV_H + "\n\n" + AV_AC + "\n\n" + AV_SP;
        }
        if (carnum == 8 || carnum == 9 || carnum == 10)
        {
            car_info.text = "" + LA_H + "\n\n" + LA_AC + "\n\n" + LA_SP;
        }
        if (carnum == 11 || carnum == 12 || carnum == 13)
        {
            car_info.text = "" + NS_H + "\n\n" + NS_AC + "\n\n" + NS_SP;
        }
        if (carnum == 14 || carnum == 15 || carnum == 16)
        {
            car_info.text = "" + VN_H + "\n\n" + VN_AC + "\n\n" + VN_SP;
        }
    }
}
