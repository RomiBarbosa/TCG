using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int maxHP;
    public int currentHP;
    public int damage;

    public Text hpText;
    public Text attackText;
    public string title;
    public Card cardInfo;
    public Player myPlayer;
    //public Image imageSprite;

    private void Start()
    {
        currentHP = maxHP;
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }

    private void Update()
    {
        hpText.text = currentHP.ToString();
        attackText.text = damage.ToString();
        if (currentHP <= 0)
        {
            Destroy();
        }
    }

     void Destroy()
    {
        Destroy(this.gameObject, 0.1f);
    }

    public void SellCard()
    {
        myPlayer.store.SellCards(cardInfo);
        Destroy();
    }
}
