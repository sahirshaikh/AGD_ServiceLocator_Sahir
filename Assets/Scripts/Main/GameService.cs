using System.Collections;
using System.Collections.Generic;
using ServiceLocator.Player;
using ServiceLocator.Utilities;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService{ get; private set; }
    [SerializeField] public PlayerScriptableObject playerScriptableObject;

    void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        
    }

    // Update is called once per frame
    void Update()
    {
        playerService.Update();
        
    }
}
