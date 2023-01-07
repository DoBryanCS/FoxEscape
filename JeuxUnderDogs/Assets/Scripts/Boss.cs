using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public Transform bulletPos1;
    public Transform bulletPos2;
    public Transform bulletPos3;
    public float bulletForce = 15f;

    private float timer = 0;
    Animation anim;

    public GameObject bulletPreFab;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 2f)
        {
            timer = 0f;
            Shoot();
        }
    }

    void Shoot()
    {
        anim.Play("ShotGun_Recoil");
        GameObject b1 = Instantiate(bulletPreFab, bulletPos1.position, Quaternion.Euler(0,0,90));
        GameObject b2 = Instantiate(bulletPreFab, bulletPos2.position, Quaternion.Euler(0, 0, 90));
        GameObject b3 = Instantiate(bulletPreFab, bulletPos3.position, Quaternion.Euler(0, 0, 90));
        b1.transform.localScale = new Vector3(3, 3, 0);
        b2.transform.localScale = new Vector3(3, 3, 0);
        b3.transform.localScale = new Vector3(3, 3, 0);
        Rigidbody2D rb1 = b1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = b2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = b3.GetComponent<Rigidbody2D>();
        rb1.AddForce(bulletPos1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(bulletPos2.up * bulletForce, ForceMode2D.Impulse);
        rb3.AddForce(bulletPos3.up * bulletForce, ForceMode2D.Impulse);

    }
}
