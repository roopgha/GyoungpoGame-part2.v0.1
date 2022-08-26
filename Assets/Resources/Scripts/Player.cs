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
    public GameObject lookAt;
    public GameObject pos;
    public GameObject playerRotate;
    public float lookSpeed = 5;


    private void Start()
    {
        GetGameobject();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Flash_Light();
        LookAt();
        LookAtPos();
        MovePos();
    }

    private void Move()
    {


        if (Input.GetKeyDown(KeyCode.LeftArrow) && flag > 0 && Light)
        {
            flag--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && flag < 2 && Light)
        {
            flag++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && flag == 1 && SeeToward == true)
        {
            Light = !Light;
            flashLight.flash_light.SetActive(Light);
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
                    transform.localPosition = new Vector3(-4, 0, 0);
                    SeeToward = false;
                }
                else if (SeeToward == false)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    SeeToward = true;
                }
            }              
            else if(flag == 1)
            {
                if (SeeToward == true && flag3 == true)
                {
                    transform.localPosition = new Vector3(0, 0, 2.3f);
                    SeeToward = false;
                }
                else if (SeeToward == false)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    SeeToward = true;
                }
            }
            else if(flag == 2)
            {
                if (SeeToward == true)
                {
                    transform.localPosition = new Vector3(4, 0, 0);
                    SeeToward = false;
                }
                else if (SeeToward == false)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    SeeToward = true;
                }
            }
        }

        
    }

    private void Flash_Light()
    {

    }

    void LookAt()
    {
        Quaternion rotation; 
         rotation = Quaternion.LookRotation(lookAt.transform.position, playerRotate.transform.position);

        playerRotate.transform.rotation = Quaternion.Lerp(playerRotate.transform.rotation, rotation, lookSpeed * Time.deltaTime);
    }

    void LookAtPos()
    {
        if(flag == 0)
        {
            lookAt.transform.position = new Vector3(-5, 0, 1.3f);
        }
        else if(flag == 1 && flag3 == true)
        {
            lookAt.transform.position = new Vector3(0, 0, 4.5f);
        }
        else if(flag == 2)
        {
            lookAt.transform.position = new Vector3(5, 0, 1.3f);
        }
        if(flag3 == false)
        {
            lookAt.transform.position = new Vector3(0, 0, -4.5f);
        }
    }

    void MovePos()
    {
        //transform.position 
    }

    void GetGameobject()
    {
        flashLight = GameObject.Find("Flashlight").GetComponent<FlashLight>();
        lookAt = GameObject.Find("LookAt");
        pos = GameObject.Find("Pos");
        playerRotate = GameObject.Find("Rotate");
    }
}
