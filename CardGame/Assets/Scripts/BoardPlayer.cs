using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardPlayer : MonoBehaviour
{
    public List<Card> Board = new List<Card>();
    public List<Unit> units = new List<Unit>();
    public GameObject unit;
    public GameObject parent;

    public void AddCard(Card card)
    {
        Board.Add(card);
        CreateToUnit(card);
    }

    void CreateToUnit(Card card)
    {
        GameObject go = Instantiate(unit, transform.position, Quaternion.identity);
        go.GetComponent<Unit>().maxHP = card.HP;
        go.GetComponent<Unit>().currentHP = card.HP;
        go.GetComponent<Unit>().damage = card.damage;
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
