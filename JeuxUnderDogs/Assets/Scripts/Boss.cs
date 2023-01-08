using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    //public GameObject bullet3;
    public Transform bulletPos1;
    public Transform bulletPos2;
    //public Transform bulletPos3;
    public float bulletForce = 15f;
    public Sprite akSprite;
    public Sprite shotgunSprite;
    public SpriteRenderer spriteRenderer;
    public int maxHealth = 100;
    public int currentHealth;
    private float timer = 0;
    public HealthBar healthBar;
    Animation anim;

    public GameObject bulletPreFab;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        System.Random r = new System.Random();
        int rInt = r.Next(1, 3);
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            timer = 0f;
            if(rInt == 1)
                Shotgun();

            if (rInt == 2)
                AK();
        }

        if(currentHealth <= 0)
        {
            int x = 1;
        }
            

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("ALLO");

        if (collision.gameObject.CompareTag("bullets"))
        {
            takeDamage(5);
            Destroy(collision.gameObject);
        }
    }

    void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void Shotgun()
    {
        spriteRenderer.sprite = shotgunSprite;
        anim.Play("ShotGun_Recoil");
        GameObject b1 = Instantiate(bulletPreFab, bulletPos1.position, Quaternion.Euler(0, 0, 90));
        GameObject b2 = Instantiate(bulletPreFab, bulletPos2.position, Quaternion.Euler(0, 0, 90));
        //GameObject b3 = Instantiate(bulletPreFab, bulletPos3.position, Quaternion.Euler(0, 0, 90));
        b1.transform.localScale = new Vector3(3, 3, 0);
        b2.transform.localScale = new Vector3(3, 3, 0);
        //b3.transform.localScale = new Vector3(3, 3, 0);
        Rigidbody2D rb1 = b1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = b2.GetComponent<Rigidbody2D>();
        //Rigidbody2D rb3 = b3.GetComponent<Rigidbody2D>();
        rb1.AddForce(bulletPos1.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(bulletPos2.up * bulletForce, ForceMode2D.Impulse);
        //rb3.AddForce(bulletPos3.up * bulletForce, ForceMode2D.Impulse);

    }


    void AK()
    {
        StartCoroutine(WaitAndPrint());

    }

    IEnumerator WaitAndPrint()
    {
        int nbrBul = 3;
        while (nbrBul > 0)
        {
            spriteRenderer.sprite = akSprite;
            anim.Play("ShotGun_Recoil");
            GameObject b1 = Instantiate(bulletPreFab, bulletPos1.position, Quaternion.Euler(0, 0, 90));
            b1.transform.localScale = new Vector3(3, 3, 0);
            Rigidbody2D rb1 = b1.GetComponent<Rigidbody2D>();
            rb1.AddForce(bulletPos1.up * bulletForce, ForceMode2D.Impulse);
            nbrBul = nbrBul - 1;

            yield return new WaitForSeconds(0.2f);
        }
        
    }

}