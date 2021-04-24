using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Platform: MonoBehaviour
{
   [SerializeField] public bool Grip = false;
    [SerializeField] public string grabObject = "Player";
    public bool grabbed = false;
    public bool wasgrabbed = false;

    public GameObject player;

    public BoxCollider2D box;
    public Rigidbody2D rig;
    public float throwYvel;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find(grabObject);
    }

    public void Grabbed(GameObject Grabber)
    {
        if (grabbed == true && Grip == true)
        {
            this.transform.position = new Vector2(Grabber.transform.position.x, Grabber.transform.position.y + box.bounds.extents.y);
            wasgrabbed = true;
        }else if (grabbed == true && Grip == false)
        {
            Debug.LogError("Grabbed Ungrabble Object");
            grabbed = false;
        }

        if ( wasgrabbed == true)
        {

            //this.transform.position += new Vector2(0,0)
            //rig.velocity.y += throwYvel;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Grabbed(player);
    }
}
