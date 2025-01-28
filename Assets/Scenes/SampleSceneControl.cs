using UnityEngine;
using UnityEngine.Video;

public class SampleSceneControl : MonoBehaviour
{
    public string videoPath;
    public VideoPlayer videoPlayer;

    private void OnEnable()
    {
        videoPlayer.errorReceived += OnVideoPlayerError;
    }

    private void OnDisable()
    {
        videoPlayer.errorReceived -= OnVideoPlayerError;
    }

    private void Start()
    {
        videoPlayer.url = $"{Application.dataPath}/{videoPath}";
        videoPlayer.Play();
    }

    private void OnVideoPlayerError(VideoPlayer source, string message)
    {
        // This callback method is never reached in Unity 6000,
        // although the VideoPlayer receives an error.

        // In contrast, it was working as expected (i.e. this callback method was entered) in Unity 2023.2.12f1

        Debug.LogError("VideoPlayer received error: " + message);
    }
}
