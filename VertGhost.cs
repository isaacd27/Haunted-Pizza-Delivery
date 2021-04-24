using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertGhost : MonoBehaviour
{

    GameObject player;


    [SerializeField]
    public float startX;
    [SerializeField]
    public float startY;

    [SerializeField] public float ResetXpos;
    [SerializeField] public float ResetYpos;


    // Start is called before the first frame update
    protected void Awake()
    {
        player = GameObject.Find("Player");
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            SoundScript.playeffect("Playerdeath");
            player.transform.position = new Vector2(startX, startY);
            this.transform.position = new Vector2(ResetXpos, ResetYpos);

        }
    }
    // Update is called once per frame
    public void Update()
    {
        movement();
    }

    public void movement()
    {
        if (this.transform.position.y > player.transform.position.y)
        {
           
            transform.position += new Vector3( 0f, -0.5f * Time.deltaTime);
        }
        else if (this.transform.position.y < player.transform.position.y)
        {
           
            transform.position += new Vector3( 0f, 0.5f * Time.deltaTime);
        }
        else if (this.transform.position.y == player.transform.position.y)
        {
            if (this.transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3((float)-1.943782, transform.localScale.y);
                transform.position += new Vector3(-0.3f * Time.deltaTime,0f);
            }
            else if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3((float)1.943782, transform.localScale.y);
                transform.position += new Vector3(0.3f*Time.deltaTime,0f);
            }
        }

    }
}
