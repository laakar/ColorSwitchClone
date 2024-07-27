using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static Manager instance;
    public CamShake CamShake;

    [Header("Ui Properties")]
    public TextMeshProUGUI playText;
    public TextMeshProUGUI scoreText, scoreText2;
    public TextMeshProUGUI endScoreText;
    public Image gameOverImg;
    public Image restartImg;
    public Image Color_O, Color_O_2;
    public Button restartButton;
    
    [Header("Score Properties")] 
    public int score;

    [Header("Game Properties")] 
    public bool playing;
    public bool lose;
    public GameObject colorChanger;

    [Header("Player Properties")] 
    public Rigidbody2D playerRb;
    public SpriteRenderer playerRenderer;
    public ParticleSystem particle;

    private bool callOnce = true;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameOverImg.DOFade(0, 0.3f);
        Color_O.DOFade(1, 0.3f);
    }

    private void Update()
    {
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
        if (Input.GetButtonDown("Fire1") && !playing)
        {
            StartGame();
        }

        if (lose && callOnce)
        {
            callOnce = false;
            CamShake.Shake();
            playerRenderer.color = new Color(1, 1, 1, 0);
            particle.Play();
            Invoke("GameOver", 0.6f);
        }
    }
    void StartGame()
    {
        colorChanger.SetActive(true);
        Color_O.DOFade(0, 0.3f);
        scoreText.DOFade(1, 0.3f);
        playText.DOFade(0, 0.3f).OnComplete(() =>
        {
            playerRb.isKinematic = false;
            playing = true;
        });
    }
    void GameOver()
    {
        gameOverImg.DOFade(1, 0.3f);
        scoreText.DOFade(0, 0.3f).OnComplete((() =>
        {
            Color_O_2.DOFade(1, 0.3f);
            endScoreText.DOFade(1, 1f).OnComplete((() =>
            {
                scoreText2.DOFade(1, 0.3f);
                scoreText.DOFade(1, 1f).OnComplete((() =>
                {
                    restartImg.DOFade(1, 1f);
                    restartButton.interactable = true;
                }));
            }));;
        }));
    }

    public void RestartGame()
    {
        restartImg.DOFade(0, 1f);
        Color_O_2.DOFade(0, 1f);
        scoreText2.DOFade(0, 1f);
        endScoreText.DOFade(0, 1f);
        Color_O.DOFade(0, 1f);
        scoreText.DOFade(0, 1f).OnComplete((() => SceneManager.LoadScene(0)));
    }
}
