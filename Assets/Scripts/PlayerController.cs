using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;

    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup")){
            other.gameObject.SetActive(false);
            count++;
            setCountText();

        }
    }

    private void setCountText() {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "You Win";
        }
    }
}
