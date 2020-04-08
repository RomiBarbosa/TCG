using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPlayer : MonoBehaviour
{
    public List<Card> Board = new List<Card>();
    public List<Unit> units = new List<Unit>();
    public GameObject unit;
    public GameObject parent;

    public void AddCard(Card card, Player player)
    {
        Board.Add(card);
        CreateToUnit(card, player);
    }

    void CreateToUnit(Card card, Player player)
    {
        GameObject go = Instantiate(unit, transform.position, Quaternion.identity);
        go.GetComponent<Unit>().maxHP = card.HP;
        go.GetComponent<Unit>().currentHP = card.HP;
        go.GetComponent<Unit>().damage = card.damage;
        go.GetComponent<Unit>().cardInfo = card;
        go.GetComponent<Unit>().myPlayer = player;
        go.transform.SetParent(parent.transform);
        var myunit = go.GetComponent<Unit>();
        units.Add(myunit);

    }

    private void Update()
    {
        for (int i = 0; i < units.Count; i++)
        {
            if (units[i].currentHP <= 0)
            {
                
                units.RemoveAt(i);
            }
        }
    }
}
