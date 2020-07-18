using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitingTargets : MonoBehaviour
{
    public static bool hitBuff = false;
    public static bool hitDebuff = false;
    public static int pointsOnPos = 10;
    public static int pointsOnNeg = -50;
    public static int pointsSkipPos = -10;
    public static int pointsSkipNeg = 10;
    public static int pointsOnInstantLose = -500;
    public AudioSource PosHit;
    public AudioSource NegHit;
    public AudioSource BonHit;
    public AudioSource DebHit;
    public AudioSource LosHit;
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "TargetPositive")
        {
            ScoreScript.scoreValue += pointsOnPos;
            PosHit.Play();
        }
        else if (coll.gameObject.tag == "TargetNegative")
        {
            ScoreScript.scoreValue += pointsOnNeg;
            NegHit.Play();
        }
        else if (coll.gameObject.tag == "TargetBonus")
        {
            BonusPointsController.checkPos = true;
            if (BonusPointsController.bonusRunning == true)
            {
                hitBuff = true;
            }
            BonHit.Play();
        }
        else if (coll.gameObject.tag == "TargetDebuff")
        {
            BonusPointsController.checkNeg = true;

            if (BonusPointsController.debuffRunning == true)
            {
                hitDebuff = true;
            }
            DebHit.Play();
        }
        else if (coll.gameObject.tag == "InstantLose")
        {
            LosHit.Play();
            ScoreScript.scoreValue += pointsOnInstantLose;
        }
        if (gameObject.tag == "Player")
        {
            Destroy(coll.gameObject);
        } 
        if (ScoreScript.scoreValue / 100 > 1)
        {
            FallingTargets.fallingSpeed += 0.05f;
            BarriersFalling.fallingSpeed += 0.05f;
            SpawningTargets.lowEdgePos -= 0.00002f;
            SpawningTargets.highEdgePos -= 0.00001f;
            SpawningTargets.lowEdgeNeg -= 0.00002f;
            SpawningTargets.highEdgeNeg -= 0.00001f;
            pointsOnInstantLose -= 50;
        }
    }
}