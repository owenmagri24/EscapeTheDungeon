using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] heartSprites;
    public Image HeartUI;

    public Sprite[] keySprites;

    public Image KeyUI;

    private PlayerController player;

    void Start()
    {
        //get player script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    void Update()
    {
        HeartUI.sprite = heartSprites[player.health];
        KeyUI.sprite = keySprites[player.keyAmount];
    }
}
