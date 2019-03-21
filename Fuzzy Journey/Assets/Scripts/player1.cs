using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class player1 : MonoBehaviour
{
    public Text healthText;
    private Rigidbody rb;
    private Animator anim;
    private float speed = 10;
    public int health = 15;
    private GameObject sword;
    public GameObject lose;
    public GameObject menu;
    public GameObject again;
    public GameObject quit;
    private bool isgrounded = true;
    private int chargecool = 5;
    private float down;
    private int freeze = 0;
    private bool ice = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        healthText.text = "Player1\n" + "Health: " + health.ToString();
        sword = transform.Find("Sword").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * 10);
        anim.Play("Idles.Idle");
        if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
        {
            anim.Play("Jumping.Standing_Jump");
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            isgrounded = false;
        }
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.z += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            pos.z -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }

        transform.position = pos;

        if (health == 0)
        {
            death();
        }

        if (Input.GetKeyDown("j") && Time.time>down)
        {
            down = Time.time + chargecool;
            rb.AddForce(transform.forward*10, ForceMode.Impulse);        
        }

        if (freeze == 3 && !ice)
        {
            ice = true;
            speed = 1;
            StartCoroutine(wai());

        }

    }

    void death()
    {
        Destroy(gameObject);
        rb.constraints = RigidbodyConstraints.FreezePosition;
        menu.SetActive(true);
        lose.SetActive(true);
        again.SetActive(true);
        quit.SetActive(true);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Fireball" && !ice)
        {
            freeze++;
            health--;
            healthText.text = "Player1\n" + "Health: " + health.ToString();
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            isgrounded = true;
        }
    }

    IEnumerator wai()
    {
        yield return new WaitForSecondsRealtime(3);
        ice = false;
        speed = 10;
        freeze = 0;
    }
}
