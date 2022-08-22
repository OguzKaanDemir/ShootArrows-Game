using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public int point, levelIndex, maxBowCount;
    [SerializeField] public int[] targetPoint, maxBow;
    [SerializeField] private TMP_Text currentPoint, tPoint, mBow, winText, loseText;
    [SerializeField] private GameObject winPanel, losePanel, shootBar;
    [HideInInspector] public bool canShoot = true, changedLevel = false;

    void Awake()
    {
        maxBowCount = maxBow[levelIndex];
    }

    void Update()
    {
        ChangeTexts();
        StartCoroutine(CheckWin());
        StartCoroutine(ChangedLevel());
    }

    void ChangeTexts()
    {
        tPoint.text = targetPoint[levelIndex].ToString();
        currentPoint.text = point.ToString();
        mBow.text = maxBowCount.ToString();
    }

    IEnumerator CheckWin()
    {
        if (maxBowCount == 0)
        {
            canShoot = false;

            shootBar.SetActive(false);

            maxBowCount = 1;

            mBow.enabled = false;

            yield return new WaitForSeconds(3);

            if (int.Parse(currentPoint.text) >= targetPoint[levelIndex])
            {
                winText.text = $"LEVEL {levelIndex+1} COMPLATED!";
                winPanel.SetActive(true);
                maxBowCount = maxBow[levelIndex + 1];
            }
            else
            {
                loseText.text = $"LEVEL {levelIndex+1} FAILED!";
                losePanel.SetActive(true);
                maxBowCount = maxBow[levelIndex];
            }
        }
    }

    public void Win()
    {
        LevelStuffs(); 
        levelIndex++;
        winPanel.SetActive(false);
    }

    public void ReStartLevel()
    {
        LevelStuffs();
        losePanel.SetActive(false);
    }

    IEnumerator ChangedLevel()
    {
        if (changedLevel == true)
        {
            yield return new WaitForSeconds(1f);
            canShoot = true;
            changedLevel = false;
        }
    }

    void LevelStuffs()
    {
        mBow.enabled = true;
        GameObject[] arw = GameObject.FindGameObjectsWithTag("Arrow");
        for (int i = 0; i < arw.Length; i++)
        {
            Destroy(arw[i]);
        }
        point = 0;
        shootBar.SetActive(true);
        changedLevel = true;
    }
}
