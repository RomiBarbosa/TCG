using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPlayer : MonoBehaviour
{
    public Card cardInfo;
    public Text attackTxt, defenseTxt, costTxt, descriptionTxt, titleTxt;
    public Image cardImage;
    public Sprite frontCard, backCard;
    public GameObject containerInfo;
    public bool showCard = false;
    SpriteRenderer spriteRend;
    public int indexHand;
    public Player myPlayer;

    void Start()
    {
        //  cardInfo = GetComponent<Card>();
        spriteRend = GetComponent<SpriteRenderer>();
        UpdateData();
        ChangeCardSide();
    }

    void ChangeCardSide()
    {
        if (!showCard)
        {
            containerInfo.SetActive(false);
            //spriteRend.sprite = backCard;
            gameObject.GetComponent<Image>().sprite = backCard;
        }
        else
        {
            containerInfo.SetActive(true);
            //spriteRend.sprite = frontCard;
            gameObject.GetComponent<Image>().sprite = frontCard;
        }
    }


    void Update()
    {
        ChangeCardSide();
    }

    public void UpdateData()
    {
        attackTxt.text = cardInfo.damage.ToString();
        defenseTxt.text = cardInfo.HP.ToString();
        costTxt.text = cardInfo.cost.ToString();
        descriptionTxt.text = cardInfo.description.ToString();
        titleTxt.text = cardInfo.title.ToString();
    }

    public Card GetCardInfo()
    {
        return cardInfo;
    }

    public void PlayCard()
    {
        myPlayer.PlayCard(this);

    }

    public void Destroy()
    {
        Destroy(gameObject, 0.5f);

    }
}