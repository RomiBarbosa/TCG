using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitToBoard : MonoBehaviour
{
    public GameObject newUnit;
    public SoldierCard stats;
    public GameObject panel;

    public void AddToBoard()
    {
        GameObject go = Instantiate(newUnit, transform.position, transform.rotation);
      //  go.AddComponent<Unit>();
        go.GetComponent<Unit>().damage = stats.attackPower;
        go.GetComponent<Unit>().maxHP = stats.defense;
       // Board.boardIns.p0.Add(go.GetComponent<Unit>());
        go.transform.parent =panel.transform;

    }


}
