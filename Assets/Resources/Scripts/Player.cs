using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FlashLight flashLight;
    public int flag = 1;
    public bool Light = true;
    public bool SeeToward = true;
    bool flag3 = true;
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    private void Move()
    {


        if (Input.GetKeyDown(KeyCode.LeftArrow) && flag > 0 && Light)
        {
            transform.localRotation *= Quaternion.Euler(0, -60, 0);
            flag--;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && flag < 2 && Light)
        {
            transform.localRotation *= Quaternion.Euler(0, 60, 0);
            flag++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && flag == 1 && SeeToward == true)
        {
            Light = !Light;
            flashLight.flash_light.SetActive(Light);
            transform.localRotation *= Quaternion.Euler(0, 180, 0);
            flag3 = !flag3;
        }

        
        if (Input.GetKey(KeyCode.UpArrow) && !Light)
        {
            flashLight.flash_light.SetActive(true);
        }
        else if (!Light)
        {
            flashLight.flash_light.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && flag3)
        {
            Light = !Light;
            flashLight.flash_light.SetActive(Light);
            if (flag == 0)
            {
                if (SeeToward == true)
                {
                    transform.localPosition = new Vector3(-4, 1.25f, 0);
                    SeeToward = false;
                }
                else if (SeeToward == false)
                {
                    transform.localPosition = new Vector3(0, 1.25f, 0);
                    SeeToward = true;
                }
            }              
            else if(flag == 1)
            {
                if (SeeToward == true && flag3 == true)
                {
                    transform.localPosition = new Vector3(0, 1.25f, 2.7f);
                    SeeToward = false;
                }
                else if (SeeToward == false)
                {
                    transform.localPosition = new Vector3(0, 1.25f, 0);
                    SeeToward = true;
                }
            }
            else if(flag == 2)
            {
                if (SeeToward == true)
                {
                    transform.localPosition = new Vector3(4, 1.25f, 0);
                    SeeToward = false;
                }
                else if (SeeToward == false)
                {
                    transform.localPosition = new Vector3(0, 1.25f, 0);
                    SeeToward = true;
                }
            }
        }

        
    }
}
