using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService {  get; private set; }
    public SoundService soundService { get; private set; }
    public MapService mapService { get; private set; }
    public WaveService waveService { get; private set; }
    public EventService eventService { get; private set; }

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private UIService uIService;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    public UIService UIService => uIService;

    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;
    void Start()
    {
        eventService = new EventService();
        UIService.SubscribeToEvents();
        mapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);
        soundService = new SoundService(soundScriptableObject,audioEffects,backgroundMusic);
        playerService = new PlayerService(playerScriptableObject);

    }

    void Update()
    {
        playerService.Update();   
    }
}
