using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Image[] _healthBars;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is NULL");
            }

            return _instance;
        }
    }

    public Text playerGemCountText;
    public Image _selectionImg;
    public Text gemCountText;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gems)
    {
        playerGemCountText.text = gems + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        _selectionImg.rectTransform.anchoredPosition = new Vector2(_selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {


        for (int i = 0; i <= livesRemaining; i++)
        {
           if (i == livesRemaining)
            {
                _healthBars[i].enabled = false;
            }
        }

    }
}
