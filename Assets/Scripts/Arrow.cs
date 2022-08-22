using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody rb;
    BoxCollider bc;
    GameManager gm;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        gm = GameObject.Find("Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.LookAt(transform.position + GetComponent<Rigidbody>().velocity);

        RaycastHit rc;

        if (Physics.Raycast(transform.position, transform.forward, out rc, 6))
        {
            string name = rc.collider.gameObject.name;

            switch (name)
            {
                case "Yellow":
                    gm.point += 12;
                    break;
                case "Red":
                    gm.point += 10;
                    break;
                case "Blue":
                    gm.point += 8;
                    break;
                case "Black":
                    gm.point += 6;
                    break;
                case "Ground":
                    Destroy(this.gameObject, 2);
                    break;
            }

            Remove();
        }
    }

    void Remove()
    {
        Destroy(rb);
        Destroy(bc);
        Destroy(this);
    }
}
