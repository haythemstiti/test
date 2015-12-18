using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    
    float maxSpeed =100f;
    float forwardSpeed = 1f;
    Rigidbody2D rb;
    Animator anim;
    bool didFlap = false;
    bool dead = false;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)||(Input.GetMouseButtonDown(0)))
            didFlap = true;

        else if (Input.anyKeyDown)
        {
            Time.timeScale = 1;
            GameObject.Find("Popup").SetActive(false);
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        

        if (dead)
        {
            Invoke("Restart", 2f);
            return;
        }
            

        rb.AddForce(Vector2.right * forwardSpeed);
        if (didFlap)
        {
            rb.AddForce(Vector2.up * maxSpeed);
            anim.SetTrigger("flap");
            didFlap = false;
        }
        if (rb.velocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
          else
        {
            float angle = Mathf.Lerp(0, -90, -rb.velocity.y / 4f);
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        anim.SetTrigger("die");
        dead = true;
    }

    void Restart()
    {
        Manage.score = 0;
        Application.LoadLevel(Application.loadedLevel);
    }
}
