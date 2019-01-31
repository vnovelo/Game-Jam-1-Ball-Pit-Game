using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public GameObject Bubble;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    private float canSpUpTime; // added by mykenzie
    private float spIncrease; // added by mykenzie. value to multiply speed by
    Vector3 growthRate = new Vector3(0.045f, 0.03f, 0.045f);
    Vector3 maxSize = new Vector3(9f, 6f, 9f);
    Vector3 minSize = new Vector3(4.5f, 3f, 4.5f);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
        canSpUpTime = 0.0f; // added by mykenzie
        spIncrease = 1.5f; // added by mykenzie

    }

    // Update is called once per frame
    void Update()
    {
        canSpUpTime -= Time.deltaTime; // added by mykenzie. Timer for speed pad trigger

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if(Input.GetKey("space") & Bubble.GetComponent<Transform>().localScale.magnitude < maxSize.magnitude)
        {
            Bubble.GetComponent<Transform>().localScale += growthRate;
        }
        else if (!Input.GetKey("space") & Bubble.GetComponent<Transform>().localScale.magnitude > minSize.magnitude)
        {
            Bubble.GetComponent<Transform>().localScale -= growthRate;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count++;
            setCountText();

        }
    }

    private void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win";
        }
    }

    /*added by mykenzie*/
    /*Causes ball to speed up on contact with speed pad. Can only be triggered every 2 seconds*/
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Speed Pad") && canSpUpTime <= 0.0f)
        {
            speed *= spIncrease;
            canSpUpTime = 2.0f;
        }
    }
}
