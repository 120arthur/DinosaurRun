using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Mananges the Game Ui.
/// </summary>
public class UiGame : Ui
{
    public static UiGame uiInstance;

    [Header("HUD")]

    [SerializeField]
    private TextMeshProUGUI _TimeText;
    [SerializeField]
    private TextMeshProUGUI _CollectablesText;

    [Header("Win Container")]
    [Space(10)]

    [SerializeField]
    private Animator _WinContainer;
    [SerializeField]
    private Text _WinRecordTime;
    [SerializeField]
    private Text _WinCollectableTotal;

    [Header("Lose Container")]
    [Space(10)]

    [SerializeField]
    private Animator _loseContainer;
    [SerializeField]
    private Button _AdvertiseButton;

    [Header("Transition")]
    [Space(10)]

    [SerializeField]
    private Animator _Transition;

    private void Awake()
    {
        uiInstance = this;
    }

    private void Start()
    {
        StartCoroutine(Transition(0.5f));
    }

    private void Update()
    {
        UpdateTextTimer();
    }

    private void UpdateTextTimer()
    {
        _TimeText.text = Timer.timeInstnce.CurrentTimeText();
    }
    public void UpdateCollectables()
    {
        _CollectablesText.text = (GameManager.gameManagerInstance.CollectableManager.GetStoredCollectablesValue().ToString());
    }

    public void WinIn()
    {
        ActivateUi(_WinContainer.gameObject);
        UpdateWinUi();
    }
    private void UpdateWinUi()
    {
        _WinRecordTime.text = ("YOUR TIME IS : " + Timer.timeInstnce.CurrentTimeText());
        _WinCollectableTotal.text = (GameManager.gameManagerInstance.CollectableManager.GetStoredCollectablesValue().ToString());
    }

    public void LoseIn()
    {
        // if the ad was loaded makes the button interactive.
        _AdvertiseButton.interactable = MonetizationManager.monetizationManagerInstance.RewardedIsReady();
        ActivateUi(_loseContainer.gameObject);
    }
    public void OnAdvertiseButtonClick()
    {
        MonetizationManager.monetizationManagerInstance.ShowRewarded();
        DeactivateUi(_AdvertiseButton.gameObject);
    }
    public void LoseOut()
    {
        DeactivateUi(_loseContainer.gameObject);
    }

    private IEnumerator Transition(float timeToDisable)
    {
        _Transition.Play("TransitionIn");
        // Hides the banner so that it does not appear in front of the transition.
        MonetizationManager.monetizationManagerInstance.HideBaner();
        yield return new WaitForSeconds(timeToDisable);
        MonetizationManager.monetizationManagerInstance.ShowBanner();
    }
}
