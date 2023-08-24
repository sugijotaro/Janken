using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Hand
{
    Rock,
    Scissors,
    Paper
}

public class Janken : MonoBehaviour
{
    public Button rockButton;
    public Button scissorsButton;
    public Button paperButton;

    public Image opponentHand;
    public Text resultText;

    public Sprite rockSprite;
    public Sprite scissorsSprite;
    public Sprite paperSprite;

    private Dictionary<Hand, Sprite> handToSprite = new Dictionary<Hand, Sprite>();

    private void Start()
    {
        rockButton.onClick.AddListener(OnRockClick);
        scissorsButton.onClick.AddListener(OnScissorsClick);
        paperButton.onClick.AddListener(OnPaperClick);

        handToSprite.Add(Hand.Rock, rockSprite);
        handToSprite.Add(Hand.Scissors, scissorsSprite);
        handToSprite.Add(Hand.Paper, paperSprite);
    }

    private void OnRockClick()
    {
        Play(Hand.Rock);
    }

    private void OnScissorsClick()
    {
        Play(Hand.Scissors);
    }

    private void OnPaperClick()
    {
        Play(Hand.Paper);
    }

    private void Play(Hand playerHand)
    {
        Hand opponentHandValue = (Hand)Random.Range(0, 3);
        ShowOpponentHand(opponentHandValue);
        ShowResult(playerHand, opponentHandValue);
    }

    private void ShowOpponentHand(Hand hand)
    {
        opponentHand.sprite = handToSprite[hand];
    }

    private void ShowResult(Hand playerHand, Hand opponentHand)
    {
        if (playerHand == opponentHand)
        {
            resultText.text = "Draw!";
        }
        else if ((playerHand == Hand.Rock && opponentHand == Hand.Scissors) ||
                 (playerHand == Hand.Scissors && opponentHand == Hand.Paper) ||
                 (playerHand == Hand.Paper && opponentHand == Hand.Rock))
        {
            resultText.text = "You Win!";
        }
        else
        {
            resultText.text = "You Lose!";
        }
    }
}
