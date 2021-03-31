using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guy : MonoBehaviour
{
    public GameObject Head;
    public GameObject Arms;
    public GameObject Hand;
    public GameObject Torso;
    public GameObject Legs;
    public GameObject ShoePrefab;
    public GameObject GunPrefab;

    public Vector3 BSpawnLocal;

    public Vector3 facingH = Vector3.one;
    public Vector3 facingV = Vector3.one;

    Rigidbody2D RB;
    bool Grounded;

    ShoeBase feetinstance;

    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
        Grounded = false;
        feetinstance = ShoePrefab.GetComponent<ShoeBase>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateArmsandFacing();

        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            RB.AddForce(new Vector2(0, 200));
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

    }

    public void UpdateArmsandFacing()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Arms.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        BSpawnLocal = Hand.transform.position - Arms.transform.position;
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
        Grounded = true;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
    }


}
