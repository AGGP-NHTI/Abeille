using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Guy : MonoBehaviour
{
    public bool UsingMouse;
    public bool Dummy;
    public bool Player2;

    public float maxHealth = 100;
    public float currentHealth;
    public int lives = 3;

    public SpawnManager spawner;

    public Text healthDisplay;

    public GameObject Head;
    public GameObject Arms;
    public GameObject Hand;
    public GameObject Torso;
    public GameObject Legs;
    public GameObject legaimer;
    public GameObject ShoePrefab;
    ShoeBase Shoes;
    public GameObject GunPrefab;


    public GameObject GunHolder;
    public List<GameObject> guns;
    public GameObject activegun;
    Pistol Gun;
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

    ShoeBase feetinstance;

    public float JumpHeight;
    public float MoveSpeed;
    public float KickKnockback;


    bool Jump;
    bool Shoot;
    bool Kick;
    bool SwitchGun;
    bool SwitchShoe;
    float Movement;
    float MouseX;
    float MouseY;


    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<CapsuleCollider2D>();
        feetinstance = ShoePrefab.GetComponent<ShoeBase>();
    }

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateDisplay();
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        col.enabled = true;
        Gun = activegun.GetComponent<Pistol>();
        Shoes = ShoePrefab.GetComponent<ShoeBase>();


        if(!Dummy)
        {
            getInputs();
            UpdateArmsandFacing();
            updateHolding();
            UpdateMovement();

            if (Shoot)
            {
                Debug.Log(gameObject.name + " :: is Player 2 = " + Player2 + " :: Shoot =  " + Shoot);
                Gun.Fire();
            }

            if (Kick)
            {
                Shoes.Kick();
            }
        }

    }


    //HANDLES EQUIPMENT SWITCH
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
    public void updateHolding()
    {
        //UPDATE EQUIPMENT
        if (SwitchGun)
        {
            if (shoeindex < 2)
            {
                shoeindex += 1;
            }
            else
            {
                shoeindex = 0;
            }

            updateShoe();
        }
        if (SwitchShoe)
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

    public void UpdateMovement()
    {
        if (Jump && IsGrounded())
        {
            RB.AddForce(new Vector2(0, JumpHeight));
        }

        RB.AddForce(new Vector2(MoveSpeed * Movement, 0));
        if (Movement != 0)
        {
            feetinstance.Walk(ShoePrefab, 1 * facingH.x);
        }
    }


    public void getInputs()
    {
        if(!Player2)
        {
            Shoot = Input.GetButtonDown("Fire1");
            if (Shoot)
            {
                Debug.Log(gameObject.name + " :: Player 1 shoot");
            }
            Kick = Input.GetButtonDown("Fire2");
            SwitchGun = Input.GetButtonDown("Button1");
            SwitchShoe = Input.GetButtonDown("Button2");
            Jump = Input.GetButtonDown("Jump");
            Movement = Input.GetAxis("Horizontal");
            MouseX = Input.GetAxis("Mouse X");
            MouseY = Input.GetAxis("Mouse Y");
        }

        if(Player2)
        {
            Shoot = Input.GetButtonDown("P2Fire1");
            if(Shoot)
            {
                Debug.Log(gameObject.name + " :: Player 2 shoot");
            }
            Kick = Input.GetButtonDown("P2Fire2");
            SwitchGun = Input.GetButtonDown("P2Button1");
            SwitchShoe = Input.GetButtonDown("P2Button2");
            Jump = Input.GetButtonDown("P2Jump");
            Movement = Input.GetAxis("P2Horizontal");
            MouseX = Input.GetAxis("P2Mouse X");
            MouseY = Input.GetAxis("P2Mouse Y");
        }
    }





    public void UpdateArmsandFacing()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir;
        if(UsingMouse)
        {
            dir = Input.mousePosition - pos;
        }
        else
        {
            dir = new Vector3(MouseY, -MouseX, 0);
        }

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;


        //update legs
        legaimer.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        //update arms
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

    public void TakeDamage(float damage, float knockback, Vector2 direction)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        UpdateDisplay();
        CheckDeath();
        if (knockback != 0)
        {
            // apply force to rigidbody
            RB.AddForce(direction * knockback);
        }
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(col.bounds.center, Vector2.down, col.bounds.extents.y + 0.1f, groundLayer);
        Debug.DrawRay(col.bounds.center, Vector2.down * (col.bounds.extents.y + 0.1f), rayColor);
        return hit.collider != null;
    }

    void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            lives -= 1;
            UpdateDisplay();
            Destroy(gameObject);

            if (lives > 0)
            {
                spawner.Respawn(gameObject);
                currentHealth = maxHealth;
            }
        }
    }

    void UpdateDisplay()
    {
        healthDisplay.text = "Lives: " + lives.ToString() + "\nHP: " + currentHealth.ToString();
    }
}
