using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public ICheckPointManager CheckPointManager;
    public ICollectable CollectableManager;

    private void Awake()
    {
        gameManagerInstance = this;
    }
    private void Start()
    {
        CheckPointManager = GetComponent<ICheckPointManager>();
        CollectableManager = GetComponent<ICollectable>();
    }

    public void RespawnPlayer()
    {
        Timer.timeInstnce.ContinueTime();
        PlayerMovment Player = FindObjectOfType<PlayerMovment>();
        Player.AnimationParameter.SetAnimationParameterBool("IsDead", false);

        CheckPointManager.SendObjectToLastCheckPoint(Player.gameObject.transform);
        UiGame.uiInstance.LoseOut();
    }
}

