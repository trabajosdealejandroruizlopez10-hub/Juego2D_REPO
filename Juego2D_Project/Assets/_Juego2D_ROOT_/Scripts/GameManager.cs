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
    private GameObject healthUI;

    void Start()
    {
        // Música de fondo
        GameObject musicObj = GameObject.FindGameObjectWithTag("Music");
        if (musicObj != null)
            backgroundMusic = musicObj.GetComponent<AudioSource>();

        // Barra de vida (Canvas)
        healthUI = GameObject.FindGameObjectWithTag("HealthUI");
    }

    public void StartTransition()
    {
        if (isPlaying) return;
        isPlaying = true;

        // ⏸️ Pausar música
        if (backgroundMusic != null)
            backgroundMusic.Pause();

        // ❌ Ocultar barra de vida
        if (healthUI != null)
            healthUI.SetActive(false);

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

