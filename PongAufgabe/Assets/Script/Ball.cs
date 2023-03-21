using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{


    private Vector3 velocity;
    public float maxX;
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, maxZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("paddle"))
        {
            float maxDist = other.transform.localScale.x * 0.5f + transform.localScale.x * 0.5f;
            float dist = transform.position.x - other.transform.position.x;
            float nDist = dist / maxDist;
            velocity = new Vector3(nDist * maxX, velocity.y, -velocity.z);
        }
        else if (other.CompareTag("wall"))
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
        }
        gameObject.GetComponent<AudioSource>().Play();
        }
    }
