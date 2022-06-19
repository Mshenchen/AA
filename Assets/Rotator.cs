using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Rotator : MonoBehaviour
{
    public float rotatoSpeed;
    public bool isRotating;
    public Text scoreText;
    int score;
    public GameObject losePanel;
    public Text finalScoreText;
    int currentLevel=-1;
    int remainStings;
    public int[] levelStingAmount;
    int finalScore;
    private void Start()
    {
        losePanel.SetActive(false);
        SetupLevel();
    }
    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0, 0, rotatoSpeed * Time.deltaTime);
        }
    }
    public void SetupLevel()
    {
        foreach(Transform sting in transform)
        {
            Destroy(sting.gameObject);
        }
        currentLevel++;
        remainStings = levelStingAmount[currentLevel];
        score = remainStings;
        scoreText.text = score.ToString();
    }
    public void GetHit()
    {
        int dir = Random.Range(0, 1f) > 0.6f ? 1 : -1;
        rotatoSpeed *= Random.Range(0.95f, 1.05f)*dir;
        score--;
        scoreText.text = score.ToString();
        finalScore++;
        remainStings--;
        if (remainStings <= 0)
        {
            SetupLevel();
        }
    }
    public void GameOver()
    {
        losePanel.SetActive(true);
        finalScoreText.text = "YOUR FINAL SCORE: " + finalScore;
        scoreText.text = "";
        Camera.main.GetComponent<Animator>().SetTrigger("Lose");
        FindObjectOfType<StingShooter>().canShoot = false;
        FindObjectOfType<Rotator>().isRotating = false;
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
