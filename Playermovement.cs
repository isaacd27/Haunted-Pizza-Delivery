using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Playermovement : MonoBehaviour
{
    [SerializeField] private LayerMask PlatformLayerMask;
    // Start is called before the first frame update
    [SerializeField]
    public float moveSpeed = 5f;
    [SerializeField]
    public float jumpforce = 5f;

     int jumppara, walkpara;
   // public Tilemap tilemap;

   // public PopulatedTilemap script;

    public BoxCollider2D box;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
      // tilemap = script.gettilemap();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();

        jumppara = Animator.StringToHash("Ongroud");
        walkpara = Animator.StringToHash("Walking");
        
    }
    // Update is called once per frame
    void Update()
    {
        Jump();
        grab();
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        // Debug.Log(IsGrounded());

        // if (tilemap.ContainsTile(tilemap.name("Player")))
        // {

        //  }

        if (IsGrounded())
        {
            anim.SetBool(jumppara, true);


        }
        else
        {
            anim.SetBool(jumppara, false);
        }

        if (Input.GetAxis("Horizontal") < 0f)
        {
            transform.localScale = new Vector3((float)-3.38921, transform.localScale.y);
            anim.SetBool(walkpara, true);

        }
        else if (Input.GetAxis("Horizontal") > 0f)
        {
            transform.localScale = new Vector3((float)3.38921, transform.localScale.y);
            anim.SetBool(walkpara, true);
        }
        else
        {
            anim.SetBool(walkpara, false);
        }

            transform.position += movement * Time.deltaTime * moveSpeed;
    }

    public bool IsGrounded()
    {
        float extra = 0.5f;
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center, box.bounds.size, 0f, Vector2.down, extra, PlatformLayerMask); //box.bounds.extents.y + extra);
        Color raycolor;
        if (hit.collider != null)
        {
            raycolor = Color.green;

        }
        else
        {
            raycolor = Color.red;

        }

        Debug.DrawRay(box.bounds.center, Vector2.down, raycolor);
        // Debug.Log(hit.collider);
        return hit.collider != null;

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump")&& IsGrounded())
        {
            SoundScript.playeffect("PlayerJumpSound");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }
    }

    void grab()
    {
        if (Input.GetButtonDown("Grip"))
        {

        }
    }

    
}
