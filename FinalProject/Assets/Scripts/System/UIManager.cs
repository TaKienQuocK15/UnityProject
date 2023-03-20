using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Text score;

    [SerializeField] Text bulletNum;
    [SerializeField] Image gunSprite;
    [SerializeField] Sprite glockSprite, gatlingSprite, shotgunSprite;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text gameOverText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    private void OnEnable()
    {
        EventManager.GameOverEvent.AddListener(OnGameOver);
    }

    private void OnDisable()
    {
		EventManager.GameOverEvent.RemoveListener(OnGameOver);
	}

    public void ChangeScore(int newScore)
    {
        score.text = "Score: " + newScore;
    }

    public void ChangeBulletNum(int num)
    {
        bulletNum.text = num.ToString();
    }

    public void ChangeToGlock()
    {
        gunSprite.sprite = glockSprite;
        bulletNum.text = "Åá";
	}

    public void ChangeToGatling()
    {
        gunSprite.sprite = gatlingSprite;
    }

    public void ChangeToShotgun()
    {
        gunSprite.sprite = shotgunSprite;
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        gameOverText.text = score.text;
    }
}
