using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootArrow : MonoBehaviour
{
    public GameObject Arrow;
    public float ShootForce;

    public Image ShootBar;


    GameManager gm;
    Transform Cam;

    void Start()
    {
        Cam = GameObject.Find("Main Camera").transform;
        gm = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        ShootingArrow();
    }

    void ShootingArrow()
    {
        if (Input.GetMouseButtonUp(0) && gm.canShoot == true)
        {
            GameObject NewArrow = Instantiate(Arrow, Cam.position, Cam.transform.rotation);

            float ShootPower = ShootBar.fillAmount;

            NewArrow.GetComponent<Rigidbody>().AddForce(NewArrow.transform.forward * ShootPower * ShootForce);

            ShootForce = 4500;

            gm.maxBowCount -= 1;
        }
    }
}
