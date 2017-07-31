using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveScript : MonoBehaviour {
    public float speed;
    public Text countText;
    public Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountString(count);
    }
    
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountString(count);
        }
    }

    void SetCountString(int count)
    {
        countText.text = count.ToString();
    }
}
