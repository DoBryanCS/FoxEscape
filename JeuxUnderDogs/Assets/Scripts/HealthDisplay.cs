using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private float health;
    private float maxHealth;

    public Sprite emptyHeart;
    public Sprite fullHeart;
    public Image[] hearts;

    //Linking PlayerHealth script
    public Player player;


    // Update is called once per frame
    void Update()
    {
        //Make health and maxHealth same as in PlayerHealth script
        health = player.health;
        maxHealth = player.maxHealth;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void setEmpty()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = emptyHeart;
        }
    }
}
