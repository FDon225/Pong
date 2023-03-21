using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddelscript : MonoBehaviour
{

    public float speed;
    public Transform playArea;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float dir = Input.GetAxis("Horizontal");
        float newPosX = transform.position.x + dir * speed * Time.deltaTime;
        float maxX = playArea.localScale.x*10*0.5f - transform.localScale.x*0.5f;
        float clampedX = Mathf.Clamp(newPosX, -maxX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}
