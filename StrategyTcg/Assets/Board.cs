using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Board : MonoBehaviour
{
    public static Board boardIns;
    //the battle
    public List<Card> board = new List<Card>();

    public List<SoldierCard[]> mesa = new List<SoldierCard[]>();

    public List<Unit> p0;

    public List<Unit> p1;

    public BattleSystem bs;

    public Player[] players;

    public void AddCardToBoard(Card card)
    {
        board.Add(card);
    }

    public void Combat()
    {
        StartCoroutine(combatCo());
    }



    IEnumerator combatCo()
    { 
        while (true)
        {
            yield return new WaitForSeconds(1f);
            
            if (p0.Count == 0 || p1.Count == 0)
            {
                Debug.Log("Won! team ");
                TeamWinner();
                break;
            } else
            {
                bs.BattleMultiple(p0[Random.Range(0, p0.Count)],
                 p1[Random.Range(0, p1.Count)]);
            }
        }
       
    }

    public int TeamWinner()
    {
        int result = 0;
        if (p0.Count == 0)
        {
            result = p1.Sum((r)=> r.damage);
           // PlayerTakeDamage(1, result);
            Debug.Log("Team 1! damage to hero:"+result);
        } else { result = p0.Sum((r) => r.damage);
            //PlayerTakeDamage(0, result);
            Debug.Log("Team 0! damage to hero:" + result);
        }

        return result;
    }

    public void PlayerTakeDamage(int index, int damage)
    {
        players[index].health -= damage;
    }


    private void Update()
    {
        for (int i = 0; i < p0.Count; i++)
        {
            if (p0[i].currentHP <= 0)
            {
                p0.RemoveAt(i);
            }
        }

        for (int i = 0; i < p1.Count; i++)
        {
            if (p1[i].currentHP <= 0)
            {
                p1.RemoveAt(i);
            }
        }
    }

}
