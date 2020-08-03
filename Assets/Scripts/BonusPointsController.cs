using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BonusPointsController : MonoBehaviour
{
    public static int countdownTimePos = 5;

    public static int countdownTimeNeg = 5;

    public Text countdownDisplayPos;
    public Text countdownDisplayNeg;

    public static bool checkPos;
    public static bool checkNeg;

    public static bool bonusRunning = false;
    public static bool debuffRunning = false;

    public GameObject bonusTextUI;

    public IEnumerator buffCountdown()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        bonusRunning = true;
        if (debuffRunning == false)
        {
            HitingTargets.pointsOnPos *= 2;
            HitingTargets.pointsOnNeg /= 2;
            HitingTargets.pointsSkipPos /= 2;
            HitingTargets.pointsSkipNeg *= 2;
        }
        while (countdownTimePos > 0 && currentScene.name == "GameScene")
        {
            countdownDisplayPos.text = "x2 for " + countdownTimePos.ToString() + " sec";
            yield return new WaitForSeconds(1f);
            countdownTimePos--;
            if (HitingTargets.hitBuff == true && bonusRunning == true)
            {
                countdownTimePos += 5;
                HitingTargets.hitBuff = false;
            }
        }

        countdownDisplayPos.text = "";

        HitingTargets.pointsOnPos = 10;
        HitingTargets.pointsOnNeg = -50;
        HitingTargets.pointsSkipPos = -10;
        HitingTargets.pointsSkipNeg = 10;

        bonusRunning = false;
        if (bonusRunning == false)
        {
            countdownTimePos = 5;
            checkPos = false;

        }
    }


    public IEnumerator debuffCountdown()
    {

        debuffRunning = true;
        if (bonusRunning == false)
        {
            HitingTargets.pointsOnPos /= 2;
            HitingTargets.pointsOnNeg *= 2;
            HitingTargets.pointsSkipPos *= 2;
            HitingTargets.pointsSkipNeg /= 2;
        }

        while (countdownTimeNeg > 0)
        {
            countdownDisplayNeg.text = "x0.5 for " + countdownTimeNeg.ToString() + " sec";
            yield return new WaitForSeconds(1f);
            countdownTimeNeg--;
            if (HitingTargets.hitDebuff == true && debuffRunning == true)
            {
                countdownTimeNeg += 5;
                HitingTargets.hitDebuff = false;
            }
        }

        countdownDisplayNeg.text = "";


        HitingTargets.pointsOnPos = 10;
        HitingTargets.pointsOnNeg = -50;
        HitingTargets.pointsSkipPos = -10;
        HitingTargets.pointsSkipNeg = 10;

        debuffRunning = false;
        if (debuffRunning == false)
        {
            countdownTimeNeg = 5;
            checkNeg = false;
        }
    }
    void Update()
    {
        if (checkPos == true && bonusRunning == false)
        {
            bonusTextUI.SetActive(true);
            StartCoroutine(buffCountdown());
            checkPos = false;
        }
        if (checkNeg == true && debuffRunning == false)
        {
            bonusTextUI.SetActive(true);
            StartCoroutine(debuffCountdown());
            checkNeg = false;
        }
    }
}