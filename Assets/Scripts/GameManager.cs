using Level.CheckPoint;
using Level.Collectables;
using Level.TimeScore;
using Player.Movement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManagerInstance;

    public ICheckPointManager checkPointManager;
    public ICollectable collectableManager;

    private void Awake()
    {
        gameManagerInstance = this;
    }
    private void Start()
    {
        checkPointManager = GetComponent<ICheckPointManager>();
        collectableManager = GetComponent<ICollectable>();
    }

    public void RespawnPlayer()
    {
        Timer.timeInstance.ContinueTime();
        var player = FindObjectOfType<PlayerMovement>();
        player.AnimationParameter.SetAnimationParameterBool("IsDead", false);

        checkPointManager.SendObjectToLastCheckPoint(player.gameObject.transform);
        UiGame.uiInstance.LoseOut();
    }
}

