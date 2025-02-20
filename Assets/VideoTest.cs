using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoTest : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage videoDisplay;
    public RenderTexture renderTexture;

    void Start()
    {
        videoPlayer.targetTexture = renderTexture;
        videoDisplay.texture = renderTexture;
        videoPlayer.Play();
    }
}