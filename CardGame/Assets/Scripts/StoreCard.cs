using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreCard : MonoBehaviour
{
    public Card cardInfo;
    public Text attackTxt, defenseTxt, costTxt, descriptionTxt, titleTxt;
    public Image cardImage;
    public Sprite frontCard, backCard;
    public GameObject containerInfo;
    public bool showCard = false;
    SpriteRenderer spriteRend;
    public Player myPlayer;

    private void Start()
    {
        UpdateData();
    }
    public void PlayCard()
    {
        Debug.Log("carta comprada");
       bool buy = myPlayer.BuyCard(this);
        if (buy)
        {
            gameObject.SetActive(false);
        }
        
    }

    public void Destroy()
    {
       // Destroy(gameObject, 0.5f);
    }

    public void UpdateData()
    {
        attackTxt.text = cardInfo.damage.ToString();
        defenseTxt.text = cardInfo.HP.ToString();
        costTxt.text = cardInfo.cost.ToString();
        descriptionTxt.text = cardInfo.description.ToString();
        titleTxt.text = cardInfo.title.ToString();
       // myPlayer = FindObjectOfType(Player);
    }
}
