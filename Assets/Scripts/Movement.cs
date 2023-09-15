using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        transform.position = startPosition + new Vector2(x, 0);

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Debug.Log("Player is reloading");
        }

        if (Input.GetButtonUp("Jump"))
        {
            Debug.Log("Player is jumping");
        }

    }
}
