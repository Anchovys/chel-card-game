﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public enum CardPosition
{
    OnLeft,
    OnRight,
    Passive
}

public class GameManager : MonoBehaviour
{
    Deck deck = null;
    public ProgressManager progressManager;

    public Card currentCard;
    public CardPosition CardPos;
    private bool GameMode;

    public GameManager()
    {
        Defines.GameManager = this;
        

    }

    private void Start()
    {
        deck = DeckLoader.Load();
        progressManager = new ProgressManager();
        CardPos = CardPosition.Passive;
        GameMode = true; //ПОТОМ ПОМЕНЯТЬ

        if (deck == null)
            throw new System.Exception("Error while load deck");

        if (deck.CardList.Length == 0)
            throw new System.Exception("Error: empty deck");

        foreach (var item in deck.CardList)
        {
            Debug.Log(item.ToString()); ////// PRINT DECK
        }
        Debug.Log("-----------------------------");
    }

    private void Update()
    {
        if (CardPos != CardPosition.Passive)
                ExecuteChoice();
    }


    private void ExecuteChoice()
    {
        if (CardPos == CardPosition.OnLeft)
        {
            Debug.Log("Left Choice");
            progressManager.ApplyChanges(currentCard.Left);
        }
        else
        {
            Debug.Log("Right Choice");
            progressManager.ApplyChanges(currentCard.Right);
        }

        //добавить проверку на превышение параметров !!!
        if (GameMode)
            currentCard = deck.GetRandom();

        Defines.VisManager.UpdateMainCard(currentCard.Icon, currentCard.Text);
        CardPos = CardPosition.Passive;
    }

    //из сложного: добавить начало игры
}
