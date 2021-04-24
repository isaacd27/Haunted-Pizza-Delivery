using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger : MonoBehaviour
{
    GameObject player;


    [SerializeField]
    public float startX;
    [SerializeField]
    public float startY;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            //SoundScript.playeffect("Playerdeath");
            player.transform.position = new Vector2(startX, startY);

        }
    }
    // Update is called once per frame
    
}
