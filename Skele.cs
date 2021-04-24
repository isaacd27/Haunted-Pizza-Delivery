using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skele : MonoBehaviour
{
    GameObject player;


    [SerializeField]
    public float startX;
    [SerializeField]
    public float startY;

    [SerializeField] float LeftXpos;
    [SerializeField] float RightXpos;
    Animator anim;
    int guardpara;

    bool hitleft = false;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();

        guardpara = Animator.StringToHash("Guard");
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
        Debug.Log(this.transform.position.y - 0.045f);
        Debug.Log(player.transform.position.y);

        Debug.Log(anim.GetBool("Guard"));

        movement();
    }

    public void movement()
    {
        if (this.transform.position.y + 3f > player.transform.position.y && this.transform.position.y - 3f < player.transform.position.y)
        {
            anim.SetBool(guardpara, true);
            if (this.transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3((float)3.374629, transform.localScale.y);
            }else if (this.transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3((float)-3.374629, transform.localScale.y);
            }
        }
        else
        {
            anim.SetBool(guardpara, false);
        }

        if (hitleft == false&& anim.GetBool("Guard") == false)
        {
            if (this.transform.position.x > LeftXpos)
            {

                transform.localScale = new Vector3((float)3.374629, transform.localScale.y);

                transform.position += new Vector3(-1f * Time.deltaTime, 0f, 0f);
               // Debug.Log("Left");
            }
            else if (this.transform.position.x <= LeftXpos)
            {
                hitleft = true;
            }
        }
        else if (hitleft == true && anim.GetBool("Guard") == false)
        {
            if (this.transform.position.x < RightXpos)
            {

                transform.localScale = new Vector3((float)-3.374629, transform.localScale.y);

                transform.position += new Vector3(1f * Time.deltaTime, 0f, 0f);

                //Debug.Log("right");


            }
            else if (this.transform.position.x >= RightXpos)
            {
                hitleft = false;
            }
        }
    }
}
