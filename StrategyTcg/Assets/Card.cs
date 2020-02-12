using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Card", menuName = "Common Card")]
public abstract class Card: ScriptableObject /*: MonoBehaviour */
{
    public string title;
    public int id;
    public int cost;
    Sprite photo;
    public string description;
}

[CreateAssetMenu(fileName = "New Spell Card", menuName = "Spell Card")]
public class SpellCard : Card
{
    public int attackPower;
    public int heal;
    public void CardSpellInit(string title, string description, int cost ,int attack, int heal)
    {

        this.title = title;
        this.description = description;
        this.cost = cost;
        this.attackPower = attack;
        this.heal = heal;
    }
    public static SpellCard CardInstance(string title, string description, int cost, int attack, int heal)
    {
        var card = ScriptableObject.CreateInstance<SpellCard>();
        card.CardSpellInit(title, description, cost,attack,heal);
        return card;
    }

}

[CreateAssetMenu(fileName = "New Soldier Card", menuName = "Soldier Card")]
public class SoldierCard : Card
{
    public int attackPower;
    public int defense;


    public void CardSoldierInit(string title, string description, int cost ,int attack, int defense)
    {

        this.title = title;
        this.description = description;
        this.cost = cost;
        this.attackPower = attack;
        this.defense = defense;
    }

    public static SoldierCard CardInstance(string title, string description, int cost, int attack, int defense)
    {
        var card = ScriptableObject.CreateInstance<SoldierCard>();
        card.CardSoldierInit(title, description, cost,attack,defense);
        return card;
    }
}


