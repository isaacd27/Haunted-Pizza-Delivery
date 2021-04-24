using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour { 

     GameObject player;
    

[SerializeField]
public float startX;
[SerializeField]
public float startY;

    [SerializeField] float LeftXpos;
    [SerializeField] float RightXpos;

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

    public void movement()
    {
        if (hitleft == false)
        {
            if (this.transform.position.x > LeftXpos)
            {

                transform.localScale = new Vector3((float)3.38921, transform.localScale.y);

                transform.position += new Vector3(-1f * Time.deltaTime, 0f, 0f);
                Debug.Log("Left");
            }
            else if (this.transform.position.x <= LeftXpos)
            {
                hitleft = true;
            }
        }
        else
        {
            if (this.transform.position.x < RightXpos)
            {

                transform.localScale = new Vector3((float)-3.38921, transform.localScale.y);

                transform.position += new Vector3(1f * Time.deltaTime, 0f, 0f);

                Debug.Log("right");


            }
            else if (this.transform.position.x >= RightXpos) 
            {
                hitleft = false;
            }
        }
    }
}
