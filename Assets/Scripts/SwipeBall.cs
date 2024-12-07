using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeBall : MonoBehaviour
{
    private Vector3 startPos, endPos;
    private float touchStart, touchFinish;
    Vector3 throwForce;
    private Rigidbody myBody;
    private AudioSource audioFX;
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        audioFX = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Time.time;
            startPos = Input.mousePosition;

        }
        if (Input.GetMouseButtonUp(0))
        {
            touchFinish = Time.time;
            endPos = Input.mousePosition;

            float totalTime = touchFinish - touchStart;

            Vector3 distance = endPos - startPos;

            distance.z = distance.magnitude;

            throwForce = distance/totalTime;

            myBody.AddForce(throwForce);
        }
    }
    void OnCollisionEnter(Collision target)
    {
        if(target.gameObject.tag == "Cans")
        {
            audioFX.Play();
        }
    }
}
