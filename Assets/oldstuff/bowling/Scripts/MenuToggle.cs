using UnityEngine;

public class MenuToggle : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject pauseButton;
    public GameObject resumeButton;
    public Transform playerHead;
    public float distanceFromPlayer = 2f;
    public AudioClip pauseSound;
    public AudioClip resumeSound;
    private AudioSource audioSource;
    private bool gamePaused = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        menuCanvas.SetActive(false);
        resumeButton.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (gamePaused)
        {
            PositionMenuInFrontOfPlayer();
        }
    }

    void PositionMenuInFrontOfPlayer()
    {
        Vector3 forward = playerHead.forward;
        forward.y = 0f;
        menuCanvas.transform.position = playerHead.position + forward.normalized * distanceFromPlayer;
        menuCanvas.transform.rotation = Quaternion.LookRotation(forward);
    }

    public void PauseGame()
    {
        gamePaused = !gamePaused;
        menuCanvas.SetActive(gamePaused);
        resumeButton.SetActive(gamePaused);
        Time.timeScale = gamePaused ? 0f : 1f;
        pauseButton.SetActive(!gamePaused);
        if (gamePaused)
        {
            PositionMenuInFrontOfPlayer();
            audioSource.PlayOneShot(pauseSound);
        }
        else
        {
            audioSource.PlayOneShot(resumeSound);
        }
    }
}
