using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 10.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    [SerializeField]
    public float startX;
    [SerializeField]
    public float startY;

    GameObject player;

    // Use this for initialization

     void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            SoundScript.playeffect("Playerdeath");
            player.transform.position = new Vector2(startX, startY);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -400f)
        {
           
            Destroy(this.gameObject);
        }
    }
}
