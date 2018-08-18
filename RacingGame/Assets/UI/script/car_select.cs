using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_select : MonoBehaviour
{
    public int carnum = 1;
    public GameObject[] car = new GameObject[4];
    public GameObject main_canvas;
    public GameObject select_canvas;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            carnum = 1;
            main_canvas.SetActive(true);
            select_canvas.SetActive(false);
        }
        if (carnum == 1)
        {
            car[1].SetActive(false);
            car[2].SetActive(false);
            car[3].SetActive(false);
            car[0].SetActive(true);

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                carnum += 1;
            }
        }
        else if (carnum == 2)
        {
            car[2].SetActive(false);
            car[3].SetActive(false);
            car[0].SetActive(false);
            car[1].SetActive(true);

            if (Input.GetKeyUp(KeyCode.LeftArrow))
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
            car[3].SetActive(false);
            car[0].SetActive(false);
            car[1].SetActive(false);
            car[2].SetActive(true);

            if (Input.GetKeyUp(KeyCode.LeftArrow))
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
            car[3].SetActive(true);
            car[0].SetActive(false);
            car[1].SetActive(false);
            car[2].SetActive(false);
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                carnum -= 1;
            }
        }
    }
}
