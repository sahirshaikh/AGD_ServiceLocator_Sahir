using System.Collections;
using System.Collections.Generic;
using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService{ get; private set; }
    public SoundService soundService{ get; private set; }
    public MapService mapService{ get; private set; }
    public WaveService waveService{ get; private set; }
    public EventService eventService{ get; private set; }



    [SerializeField] private UIService uIService;
    public UIService UIService => uIService;

    [SerializeField] public PlayerScriptableObject playerScriptableObject;
    [SerializeField] public SoundScriptableObject soundScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
        [SerializeField] private AudioSource audioEffects;
        [SerializeField] private AudioSource backgroundMusic;

    public GameEventController<int> OnMapSelected { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            OnMapSelected = new GameEventController<int>();

        }



    void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject,audioEffects,backgroundMusic);
        mapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);

        
    }

    // Update is called once per frame
    void Update()
    {
        playerService.Update();
        
    }
}
