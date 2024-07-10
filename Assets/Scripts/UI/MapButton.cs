using UnityEngine;
using UnityEngine.UI;
using ServiceLocator.Main;
using ServiceLocator.Events;
using ServiceLocator.Wave;

namespace ServiceLocator.UI
{
    public class MapButton : MonoBehaviour
    {
        [SerializeField] private int MapId;
        [SerializeField] private Button mapButton;
        private EventService eventService;
        private void Start() => GetComponent<Button>().onClick.AddListener(OnMapButtonClicked);
        public void Init(EventService eventService)
        {
            this.eventService = eventService;
        }

        // To Learn more about Events and Observer Pattern, check out the course list here: https://outscal.com/courses
        private void OnMapButtonClicked()
        {
            if (MapId == 2 && WaveService.isLevelWon== false)
            {
                mapButton.enabled = false;
            }
            else
            {
                eventService.OnMapSelected.InvokeEvent(MapId);
            }
            
        }
    }
}