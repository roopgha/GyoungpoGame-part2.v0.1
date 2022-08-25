using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public GameObject flash_light;
    Transform tr;
    GameObject player;

    private void Awake()
    {
        flash_light = GameObject.Find("Flashlight");
        player = GameObject.FindGameObjectWithTag("Player");
        tr = this.transform;
    }
}
