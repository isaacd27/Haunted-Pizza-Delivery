using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;


    [SerializeField]
    public float startX;
    [SerializeField]
    public float startY;

    [SerializeField] float TopYpos;
    [SerializeField] float BotYpos;

    bool hitleft = false;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
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
        movement();
    }

    void movement()
    {
        if (hitleft == false)
        {
            if (this.transform.position.y > BotYpos)
            {

              

                transform.position += new Vector3(0f, -2f*Time.deltaTime, 0f);
               
            }
            else if (this.transform.position.y <= BotYpos)
            {
                hitleft = true;
            }
        }
        else
        {
            if (this.transform.position.y < TopYpos)
            {

                

                transform.position += new Vector3(0f, 1f*Time.deltaTime, 0f);
                
               ;


            }
            else if (this.transform.position.y >= TopYpos)
            {
                Debug.Log("what");
                hitleft = false;
            }
        }
    }

    // Update is called once per frame

}
