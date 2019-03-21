using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player2 : MonoBehaviour
{
    public Text healthText;
    private Rigidbody rb;
    private Animator anim;
    private float speed = 10f;
    public int health = 10;
    public GameObject lose;
    public GameObject menu;
    public GameObject again;
    public GameObject quit;
    private float cool = 0.5f;
    private float down;
    public GameObject fireball;
    private GameObject staff;
    private bool isgrounded = true;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        healthText.text = "Player2\n" + "Health: " + health.ToString();
        staff = transform.Find("Staff").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * 10);
        anim.Play("Idles.Idle");
        if (Input.GetKeyDown(KeyCode.Keypad0) && isgrounded)
        {
            anim.Play("Jumping.Standing_Jump");
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            isgrounded = false;
        }
        Vector3 pos = transform.position;

        if (Input.GetKey("up"))
        {
            pos.z += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey("down"))
        {
            pos.z -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKey("right"))
        {
            pos.x += speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey("left"))
        {
            pos.x -= speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        transform.position = pos;

        if (health == 0)
        {
            death();
        }

        if (Input.GetMouseButtonDown(0) && Time.time > down)
        {
            down = Time.time + cool;
            Vector3 mousepos = Input.mousePosition;
            mousepos.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
            mousepos = Camera.main.ScreenToWorldPoint(mousepos);
            mousepos -= transform.position;
            mousepos = mousepos + transform.position;
            GameObject projectile = Instantiate(fireball) as GameObject;
            projectile.transform.position = staff.transform.position + new Vector3(0, 3f, 0);
            Rigidbody prorb = projectile.GetComponent<Rigidbody>();
            Vector3 screenpos = new Vector3(mousepos.x, transform.position.y, mousepos.z);
            projectile.transform.LookAt(screenpos);
            prorb.velocity = projectile.transform.forward * 50;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sword")
        {
            health--;
            healthText.text = "Player2\n" + "Health: " + health.ToString();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isgrounded = true;
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

}
