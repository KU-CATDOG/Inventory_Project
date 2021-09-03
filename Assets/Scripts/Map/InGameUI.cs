using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject gameScreen;
    public GameObject pauseScreen;
    public GameObject settingScreen;
    public GameObject exitScreen;
    public GameObject itemSelectScreen;
    public GameObject gameOverScreen;
    public ItemDropSelect itemDropSelect;
    public ClearJudge clearJudge;
    public testInvCon invCon;

    void Update()
    {
        if (clearJudge.GameOver|| invCon.playerPosition==36)
        {
            gameScreen.SetActive(false);
            pauseScreen.SetActive(false);
            settingScreen.SetActive(false);
            exitScreen.SetActive(false);
            itemSelectScreen.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }
    public void PauseButton()
    {
        pauseScreen.SetActive(true);
        gameScreen.SetActive(false);
    }
    public void ContinueButton()
    {
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
    }

    public void SettingButton()
    {
        settingScreen.SetActive(true);
        pauseScreen.SetActive(false);
    }
    public void SettingOutButton()
    {
        settingScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void ExitQuestionButton()
    {
        exitScreen.SetActive(true);
        pauseScreen.SetActive(false);
        gameOverScreen.SetActive(false);
    }
    public void ExitYesButton()
    {
        Application.Quit();
    }
    public void ExitNoButton()
    {
        exitScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void goItemSelectScreen()
    {
        itemSelectScreen.SetActive(true);
    }
    
    public void itemSelectButton()
    {
        gameScreen.SetActive(true);
        itemSelectScreen.SetActive(false);
    }
   
    public void gameRestartButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void item1Button()
    {
        switch (itemDropSelect.Item1)
        {
            case 1:
                if (invCon.SpawnShield(itemDropSelect.shieldSpawnCount))
                {
                    itemDropSelect.shieldSpawnCount++;
                    Debug.Log("规菩 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;

            case 2:
                if (invCon.SpawnSword(itemDropSelect.swordSpawnCount))
                {
                    itemDropSelect.swordSpawnCount++;
                    Debug.Log("八 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;

            case 3:
                if (invCon.SpawnShoe(itemDropSelect.shoesSpawnCount))
                {
                    itemDropSelect.shoesSpawnCount++;
                    Debug.Log("八 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;
            case 4:
                if (invCon.SpawnArmor(itemDropSelect.armorSpawnCount))
                {
                    itemDropSelect.armorSpawnCount++;
                    Debug.Log("癌渴 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;
            case 5:
                if (invCon.SpawnRing(itemDropSelect.accessorySpawnCount))
                {
                    itemDropSelect.accessorySpawnCount++;
                    Debug.Log("厘脚备 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;
        }
        itemSelectButton();

    }
    public void item2Button()
    {
        switch (itemDropSelect.Item2)
        {
            case 1:
                if (invCon.SpawnShield(itemDropSelect.shieldSpawnCount))
                {
                    itemDropSelect.shieldSpawnCount++;
                    Debug.Log("规菩 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;
            case 2:
                if (invCon.SpawnSword(itemDropSelect.swordSpawnCount))
                {
                    itemDropSelect.swordSpawnCount++;
                    Debug.Log("八 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;
            case 3:
                if (invCon.SpawnShoe(itemDropSelect.shoesSpawnCount))
                {
                    itemDropSelect.shoesSpawnCount++;
                    Debug.Log("八 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;
            case 4:
                if (invCon.SpawnArmor(itemDropSelect.armorSpawnCount))
                {
                    itemDropSelect.armorSpawnCount++;
                    Debug.Log("癌渴 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;
            case 5:
                if (invCon.SpawnRing(itemDropSelect.accessorySpawnCount))
                {
                    itemDropSelect.accessorySpawnCount++;
                    Debug.Log("厘脚备 积己");
                }
                else
                {
                    Debug.Log("磊府 何练");
                }
                break;
        }
        itemSelectButton();

    }
}
