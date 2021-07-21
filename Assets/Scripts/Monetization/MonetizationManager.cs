using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

namespace Monetization
{
    /// <summary>
    /// This class mananges the Unity ads
    /// </summary>
    public class MonetizationManager : MonoBehaviour, IUnityAdsListener
    {
        public static MonetizationManager monetizationManagerInstance;

        private void Awake()
        {
            monetizationManagerInstance = this;

            DontDestroyOnLoad(this);

            var gameId = "";

#if UNITY_IOS
gameId = "4147426";
#elif UNITY_ANDROID
            gameId = "4147427";
#endif

            Advertisement.AddListener(this);

            if (HasInternetConnection())
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
            HideBanner();
        }

        public void OnUnityAdsReady(string placementId)
        {
            if (!placementId.Equals("Banner_Android")) return;
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            ShowBanner();
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
        public void HideBanner()
        {
            if (Advertisement.isInitialized)
            {
                Advertisement.Banner.Hide();
            }
        }

        //used to check if your smartphone has a network.
        private bool HasInternetConnection()
        {
            return Application.internetReachability != NetworkReachability.NotReachable;
        }
    }
}
