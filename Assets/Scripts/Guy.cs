using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    public float health;
    public bool dummy;

    public GameObject Head;
    public GameObject Arms;
    public GameObject Hand;
    public GameObject Torso;
    public GameObject Legs;
    public GameObject legaimer;
    public GameObject ShoePrefab;
    public GameObject GunPrefab;


    public GameObject GunHolder;
    public List<GameObject> guns;
    public GameObject activegun;
    public int gunindex;

    public GameObject ShoeHolderL;
    public GameObject ShoeHolderR;
    public List<GameObject> shoes;
    public GameObject activeshoesL;
    public GameObject activeshoesR;
    public int shoeindex;

    public LayerMask groundLayer;
    public Color rayColor;

    CapsuleCollider2D col;

    public Vector3 BSpawnLocal;

    Vector3 facingH = Vector3.one;
    public Vector3 facingV = Vector3.one;

    Rigidbody2D RB;
    bool Grounded;

    ShoeBase feetinstance;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        RB = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<CapsuleCollider2D>();
        Grounded = false;
        feetinstance = ShoePrefab.GetComponent<ShoeBase>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = IsGrounded();

        if(!dummy)
        {
            UpdateArmsandFacing();
            getInputs();
        }



    }

    public void updateGun()
    {
        Destroy(activegun);
        activegun = Instantiate(guns[gunindex], GunHolder.transform.position, GunHolder.transform.rotation);
        activegun.transform.parent = GunHolder.transform;
        activegun.transform.localScale = new Vector3(1, 1, 1);
    }
    public void updateShoe()
    {
        Destroy(activeshoesL);
        Destroy(activeshoesR);
        activeshoesL = Instantiate(shoes[shoeindex], ShoeHolderL.transform.position, ShoeHolderL.transform.rotation);
        activeshoesR = Instantiate(shoes[shoeindex], ShoeHolderR.transform.position, ShoeHolderR.transform.rotation);
        activeshoesL.transform.parent = ShoeHolderL.transform;
        activeshoesR.transform.parent = ShoeHolderR.transform;
        activeshoesL.transform.localScale = new Vector3(5, 5, 1);
        activeshoesR.transform.localScale = new Vector3(5, 5, 1);

        SpriteRenderer SR;
        SR = activeshoesL.GetComponent<SpriteRenderer>();
        SR.sortingOrder = 1;
        SR = activeshoesL.GetComponent<SpriteRenderer>();
        SR.sortingOrder = 3;
    }


    public void getInputs()
    {
        //MOVEMENT
        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            RB.AddForce(new Vector2(0, 300));
            Grounded = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            RB.AddForce(new Vector2(2, 0));
            feetinstance.Walk(ShoePrefab, -1 * facingH.x);
        }
        if (Input.GetKey(KeyCode.A))
        {
            RB.AddForce(new Vector2(-2, 0));
            feetinstance.Walk(ShoePrefab, 1 * facingH.x);
        }



        //UPDATE EQUIPMENT
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(shoeindex < 2)
            {
                shoeindex += 1;
            }
            else
            {
                shoeindex = 0;
            }

            updateShoe();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gunindex < 3)
            {
                gunindex += 1;
            }
            else
            {
                gunindex = 0;
            }


            updateGun();
        }
    }

    public void UpdateArmsandFacing()
    {
        //update legs
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        legaimer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //update arms
        Vector3 pos2 = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir2 = Input.mousePosition - pos;
        float angle2 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Arms.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        BSpawnLocal = Hand.transform.position - Arms.transform.position;

        //facing
        facingH.x = GetSign(BSpawnLocal.x);
        facingV.y = GetSign(BSpawnLocal.x);
        Head.transform.localScale = facingH;
        Legs.transform.localScale = facingH;
        Torso.transform.localScale = facingH;
        Hand.transform.localScale = facingV;
    }

    public float GetSign(float f)
    {
        if(f == 0){
            return 1;
        }

        return (Mathf.Abs(f)/f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>())
        {
            health -= 5;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + 0.1f, groundLayer);
        Debug.DrawRay(col.bounds.center, Vector2.down * (col.bounds.extents.y + 0.1f), rayColor);
        return hit.collider != null;
    }
}
