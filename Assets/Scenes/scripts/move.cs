using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;

public class move : MonoBehaviour
{
    //public Transform _target;
    public float speed = 3f;
    public float speedRotation = 1.5f;
    public GameObject player; 

    void Start()
    {
        player = (GameObject) this.gameObject;
    }

    void FixedUpdate()
    {
        MovementLogic();
    }
    private void MovementLogic()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        { 
            player.transform.position += player.transform.forward * speed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        { 
            player.transform.position -= player.transform.forward * speed * Time.deltaTime; 
        } 
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        { 
            player.transform.Rotate(Vector3.down * speedRotation); 
        } 
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        { 
            player.transform.Rotate(Vector3.up * speedRotation); 
        } 
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 rot = transform.eulerAngles;
                transform.LookAt(hit.point);
                transform.eulerAngles = new Vector3(rot.x, transform.eulerAngles.y - 90, rot.z);
            }
        }
    }
}
