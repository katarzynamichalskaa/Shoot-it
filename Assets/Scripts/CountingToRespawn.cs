using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CountingToRespawn : MonoBehaviour
{
    public float RespawnTime = 2f;
    private float TimeUntilRespawn;
    private bool isVisible;
    public Text CountingText;
    public Text YouDead;
    public Image image;

    void Start()
    {
        TimeUntilRespawn = RespawnTime;
        SetVisibility(false);
    }

    void Update()
    {
        if (isVisible)
        {
            TimeUntilRespawn -= Time.deltaTime;

            if (TimeUntilRespawn <= 0f)
            {
                SetVisibility(false);
            }

            UpdateText();
        }
    }

    void SetVisibility(bool visibility)
    {
        isVisible = visibility;
        image.gameObject.SetActive(visibility);
        CountingText.gameObject.SetActive(visibility);
        YouDead.gameObject.SetActive(visibility);

    }

    void UpdateText()
    {
        int roundedTime = Mathf.RoundToInt(TimeUntilRespawn);
        CountingText.text = "Respawn in: " + roundedTime.ToString("F1") + "s";
    }

    public void ShowCounting()
    {
        TimeUntilRespawn = RespawnTime;
        SetVisibility(true);
        UpdateText();
    }

}
