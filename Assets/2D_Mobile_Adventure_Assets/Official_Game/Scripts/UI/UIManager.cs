using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("UI Manager is Null");

            return _instance;
        }
        

    }

    public Text _playerGemCountText;

    public Image _selectionImage;

    public Text _gemCountText;

    public Image[] healthBars;

    private void Awake()
    {
        _instance = this;
    }

    public void UpdateShopSelection(int yPos)
    {
        _selectionImage.rectTransform.anchoredPosition = new Vector2(_selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void OpenShop(int playerGemCount)
    {
        _playerGemCountText.text = playerGemCount.ToString() + "G";

    }

    public void UpdateGemCountText(int count)
    {
        _gemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining)
    {
        for(int i=0; i <= livesRemaining; i++)
        {
            if(i == livesRemaining)
            {
                healthBars[i].enabled = false;
            }
        }
    }


}
