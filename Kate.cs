using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kate : MonoBehaviour
{

    [SerializeField] public float ResetXpos;
    [SerializeField] public float ResetYpos;
    [SerializeField] public float DestXpos;
    [SerializeField] public float DestYpos;

    bool Fright;

    int standpara;

    Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();

        standpara = Animator.StringToHash("Stood");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Fright= true;


        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Fright = false;

        if (collision.CompareTag("Player"))
        {
            Fright = false;


        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Fright == true)
        {
            anim.SetBool(standpara, true);
            movement();
        }
        else
        {
            anim.SetBool(standpara, false);
            reset();
        }
    }


    public void movement()
    {
        if (this.transform.position.x > DestXpos)
        {
           
            transform.position += new Vector3(-0.5f * Time.deltaTime, 0f);
        }
        else if (this.transform.position.x < DestXpos)
        {
           
            transform.position += new Vector3(0.5f * Time.deltaTime, 0f);
        }
      
        if (this.transform.position.y > DestYpos)
        {
         transform.position += new Vector3(0f, -0.5f * Time.deltaTime);
        }
         else if (transform.position.y < DestYpos)
        {
          transform.position += new Vector3(0f, 0.5f * Time.deltaTime);
        }
        }


    public void reset()
    {
        if (this.transform.position.x > ResetXpos)
        {

            transform.position += new Vector3(-0.5f * Time.deltaTime, 0f);
        }
        else if (this.transform.position.x < ResetXpos)
        {

            transform.position += new Vector3(0.5f * Time.deltaTime, 0f);
        }

        if (this.transform.position.y > ResetYpos)
        {
            transform.position += new Vector3(0f, -0.5f * Time.deltaTime);
        }
        else if (transform.position.y < ResetYpos)
        {
            transform.position += new Vector3(0f, 0.5f * Time.deltaTime);
        }
    }

}

