using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogOpen : MonoBehaviour
{

    public string dialog;
    public GameObject interfaceManager;
    public PlayerHolding pHolding;
    public bool begin = true;
    public bool end = false;
    private string[] collectibles;
    private int clue;

    private AudioSource greeting;

    // Start is called before the first frame update
    void Start()
    {
        greeting = GetComponent<AudioSource>();
        collectibles = new string[] { "film", "balloons", "life saver", "bull's eye", "pipe", "key", "fish", "birdhouse", "red airhorn", "magic hat" };
        createClue();

    }

    public void createClue()
    {
        clue = Random.Range(0, 9);
        searchDialog();
    }

    public void searchDialog()
    {
        dialog = "Hi! Can you help me find my " + collectibles[clue] + "?";

        if (collectibles[clue] == "film")
        {
            dialog += "\n It was my favorite movie!";
        }

        if (collectibles[clue] == "balloons")
        {
            dialog += "\n My friend is having a party today!";
        }

        if (collectibles[clue] == "life saver")
        {
            dialog += "\n I have swim practice later today.";
        }

        if (collectibles[clue] == "bull's eye")
        {
            dialog += "\n We have archery practice later today!";
        }

        if (collectibles[clue] == "pipe")
        {
            dialog = "\n My grandfather was looking for it earlier.";
        }

        if (collectibles[clue] == "key")
        {
            dialog = "\n I was locked out of my house!";
        }

        if (collectibles[clue] == "fish")
        {
            dialog = "\n I need to feed it still!";
        }

        if (collectibles[clue] == "birdhouse")
        {
            dialog = "\n The birds will be waiting for me to give them food!";
        }

        if (collectibles[clue] == "red airhorn")
        {
            dialog = "\n I want to use it at the festival tonight!";
        }

        if (collectibles[clue] == "magic hat")
        {
            dialog = "\n I am performing at the magic show tonight!";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!begin && pHolding.Verify())
        {
            checkClue();
        }
        greeting.Play();
        InterfaceManager im = interfaceManager.GetComponent<InterfaceManager>();
        im.ShowBox(dialog, clue);
    }

    private void checkClue()
    {
        if (pHolding.holdValue == clue)
        {
            dialog = "You found my " + collectibles[clue] + "! Hooray!";
            end = true;
        }
        else
        {
            dialog = "No, that's not my " + collectibles[clue] + ".";
        }
    }

    public void coinsScattered()
    {
        begin = false;
    }

}
