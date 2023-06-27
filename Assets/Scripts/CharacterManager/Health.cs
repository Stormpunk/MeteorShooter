using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    #region For Health and Healing
    public int health;
    public int maxHealth = 3;
    #endregion
    #region For Health Display
    public Image[] hearts = new Image[3];
    private int currentHeart;
    #endregion
    #region For Death
    [SerializeField]
    private GameObject player;
    public GameObject deathScreen;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        player = GameObject.FindWithTag("Player");
        //deathScreen = GameObject.FindWithTag("DeathScreen");
    }

    // Update is called once per frame
    void Update()
    {
        currentHeart = health - 1;
        if(health <= 0)
        {
            EnableDeathScreen();
        }
    }
    public void DamagePlayer(int damage)
    {
        health -= damage;
        UpdateHealth(true);
    }
    public void HealPlayer(int healAmount)
    {
        if(health < maxHealth)
        {
            health += healAmount;
            UpdateHealth(false);
            //will only update the health display if the player's health has been changed
        }
        else { health = maxHealth;}
    }
   public void UpdateHealth(bool isDamaged)
    {
        if(isDamaged == true)
        {
            hearts[currentHeart].gameObject.SetActive(false);
            //disables the current "newest" heart 
            currentHeart--;
            //sets the next heart down as the "newest heart"
        }
        else
        {
            hearts[currentHeart + 1].gameObject.SetActive(true);
            //enables the heart that comes after the current heart
            currentHeart++;
            //adjusts the current heart's order
        }
    }
    public void EnableDeathScreen()
    {
        player.GetComponent<Movement>().enabled = false;
        deathScreen.SetActive(true);
    }
}
