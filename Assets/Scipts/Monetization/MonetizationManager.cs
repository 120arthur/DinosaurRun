using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

/// <summary>
/// This class mananges the Unity ads
/// </summary>
public class MonetizationManager : MonoBehaviour, IUnityAdsListener
{
    public static MonetizationManager monetizationManagerInstance;

    void Awake()
    {
        monetizationManagerInstance = this;

        DontDestroyOnLoad(this);

        string gameId = "";

#if UNITY_IOS
gameId = "4147426";
#elif UNITY_ANDROID
        gameId = "4147427";
#endif

        Advertisement.AddListener(this);

        if (HasInternetConnection() == true)
        {
            Advertisement.Initialize(gameId, Debug.isDebugBuild);
        }

    }
    private void Start()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnUnityAdsDidError(string message)
    {
        GameManager.gameManagerInstance.RespawnPlayer();
        ShowBanner();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == "Rewarded_Android" && showResult == ShowResult.Finished)
        {

            GameManager.gameManagerInstance.RespawnPlayer();
            ShowBanner();
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        HideBaner();
    }

    public void OnUnityAdsReady(string placementId)
    {
        if (placementId.Equals("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            ShowBanner();
        }
    }

    // Rewarded funcions.
    public void ShowRewarded()
    {
        Advertisement.Show("Rewarded_Android");
    }
    public bool RewardedIsReady()
    {
        return Advertisement.IsReady("Rewarded_Android");
    }

    // Banner functions.
    public void ShowBanner()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Banner.Show("Banner_Android");
        }
    }
    public void HideBaner()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Banner.Hide();
        }
    }

    //used to check if your smartphone has a network.
    public bool HasInternetConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
