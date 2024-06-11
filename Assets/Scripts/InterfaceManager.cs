﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class InterfaceManager : MonoBehaviour
{
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public Image seekImage;
    public GameObject npc;
    public GameObject randomSpawn;

    public Image collectible;
    public GameObject showSprite;

    [SerializeField]
    private Sprite[] collectibleSource;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        showSprite.SetActive(false);
        dialogText.text = "Find this ";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Submit") && dialogBox.activeInHierarchy == true)
        {
            dialogBox.SetActive(false);

            if (npc.GetComponent<DialogOpen>().end)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void CollectibleUpdate(int item)
    {
        showSprite.SetActive(true);
        collectible.GetComponent<Image>().sprite = collectibleSource[item];
    }

    public void ShowBox(string dialog, int item)
    {
        dialogBox.SetActive(true);
        dialogText.text = dialog;
        seekImage.GetComponent<Image>().sprite = collectibleSource[item];

        if (npc.GetComponent<DialogOpen>().begin)
        {
            scatterCoins();
        }
    }

    public void scatterCoins()
    {
        randomSpawn.GetComponent<RandomSpawn>().DistributeCollectibles();
        npc.GetComponent<DialogOpen>().coinsScattered();
    }
}
