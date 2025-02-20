using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GachaMachine : MonoBehaviour
{
    // Enum 定義獎品類型
    private enum Prize { Gold, Purple, Blue, Consolation }

    [Header("🎬 Video Clips")]
    public VideoPlayer videoPlayer;
    public VideoClip goldClip;
    public VideoClip purpleClip;
    public VideoClip blueClip;

    [Header("🖼️ Prize Images")]
    public Image prizeImage;
    public Sprite goldPrize;
    public Sprite purplePrize;
    public Sprite bluePrize;
    public Sprite consolationPrize;

    [Header("🕹️ UI Elements")]
    public Button drawButton;
    public Button returnButton;

    private Prize selectedPrize;

    void Start()
    {
        // 初始化 UI
        prizeImage.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        drawButton.interactable = true;
    }

    public void DrawPrize()
    {
        drawButton.interactable = false;
        prizeImage.gameObject.SetActive(false);

        float randomValue = UnityEngine.Random.value * 100f;

        if (randomValue <= 5)
        {
            selectedPrize = Prize.Gold;
            videoPlayer.clip = goldClip;
        }
        else if (randomValue <= 20)
        {
            selectedPrize = Prize.Purple;
            videoPlayer.clip = purpleClip;
        }
        else if (randomValue <= 30)
        {
            selectedPrize = Prize.Blue;
            videoPlayer.clip = blueClip;
        }
        else
        {
            selectedPrize = Prize.Consolation;
            videoPlayer.clip = blueClip;
        }

        videoPlayer.gameObject.SetActive(true);
        videoPlayer.Play();
        
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer source)
    {
        switch (selectedPrize)
        {
            case Prize.Gold:
                prizeImage.sprite = goldPrize;
                break;
            case Prize.Purple:
                prizeImage.sprite = purplePrize;
                break;
            case Prize.Blue:
                prizeImage.sprite = bluePrize;
                break;
            case Prize.Consolation:
                prizeImage.sprite = consolationPrize;
                break;
        }

        prizeImage.gameObject.SetActive(true);
        returnButton.gameObject.SetActive(true);
        videoPlayer.loopPointReached -= OnVideoFinished;
        videoPlayer.gameObject.SetActive(false);
    }

    public void ResetGacha()
    {
        prizeImage.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        videoPlayer.gameObject.SetActive(false);
        drawButton.interactable = true;
    }
}
