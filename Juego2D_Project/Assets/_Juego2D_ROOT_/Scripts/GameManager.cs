using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class CollectibleSceneChange : MonoBehaviour
{
    public string sceneToLoad;
    public VideoPlayer videoPlayer;
    public GameObject videoCanvas;

    private bool isPlaying = false;
    private AudioSource backgroundMusic;

    void Start()
    {
        // Busca la música de fondo por tag
        GameObject musicObj = GameObject.FindGameObjectWithTag("Music");
        if (musicObj != null)
            backgroundMusic = musicObj.GetComponent<AudioSource>();
    }

    public void StartTransition()
    {
        if (isPlaying) return;
        isPlaying = true;

        // ⏸️ Pausar música de fondo
        if (backgroundMusic != null)
            backgroundMusic.Pause();

        videoCanvas.SetActive(true);
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
            yield return null;

        videoPlayer.loopPointReached += OnVideoFinished;
        videoPlayer.Play();
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

