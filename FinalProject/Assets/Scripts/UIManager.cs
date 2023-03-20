using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] Text score;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(this);
    }

    public void ChangeScore(int newScore)
    {
        score.text = "Score: " + newScore;
    }
}
