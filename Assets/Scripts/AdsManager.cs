using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    /* string gameID = "4094103";
     string myPlacementId = "rewardedVideo";
     bool testMode = true;
    */

    private string gameID = "4094103";

    [SerializeField]
    private Button myButton;
    public string mySurfacingId = "rewardedVideo";

    private void Start()
    {

        myButton.interactable = Advertisement.IsReady(mySurfacingId);

        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, true);
    }

    void ShowRewardedVideo()
    {
        Advertisement.Show(mySurfacingId);
    }

    public void OnUnityAdsReady (string surfacingId)
    {
        if (surfacingId == mySurfacingId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish (string surfacingId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            GameManager.Instance.Player.AddGems(100);
            UIManager.Instance.OpenShop(GameManager.Instance.Player.diamond);
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("You skipped the ad! Nothing for you!");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("The video failed, probably wasn't ready.");
        }
    }

    public void OnUnityAdsDidError (string message)
    {
        Debug.LogError("Ad Error");
    }

    public void OnUnityAdsDidStart (string surfacingId)
    {
        //Optional
    }

}
    /*
    private void PlayAd()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameID, testMode);
    }


    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        Debug.Log("Showing Rewarded Ad");

        if (showResult == ShowResult.Finished)
        {
            //award 100 gems to player
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.Log("You skipped the ad! Nothing for you.");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.Log("The video failed");
        }

    }

    public void OnUnityAdsReady (string placementId)
    {
        if (placementId == myPlacementId)
        {
            Advertisement.Show(myPlacementId);
        }
    }

    public void OnUnityAdsDidError (string message)
    {
        Debug.Log("Ad Error");
    }

    public void OnUnityAdsDidStart (string placementId)
    {
        //Optional
    }

    */


