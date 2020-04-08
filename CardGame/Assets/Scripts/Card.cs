using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = " Card")]
public class Card : ScriptableObject /*: MonoBehaviour */
{
    public string title;
    //public int id;
    public int cost;
    public int damage;
    public int HP;
    Sprite photo;
    public string description;
    public int attackPower;
    public int heal;
    public int level;
    public string type;
    public bool shield;
    public bool armor;
}