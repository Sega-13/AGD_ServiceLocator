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
        [SerializeField] private string mapName;
        private EventService eventService;
        private void Start() => GetComponent<Button>().onClick.AddListener(OnMapButtonClicked);
        public void Init(EventService eventService)
        {
            this.eventService = eventService;
        }

        // To Learn more about Events and Observer Pattern, check out the course list here: https://outscal.com/courses
        private void OnMapButtonClicked()
        {
            MapStatus status = MapManager.Instance.GetMapSatus(mapName);
            switch (status)
            {
                case MapStatus.Locked:
                    Debug.Log("Map is Locked");
                    break;
                case MapStatus.UnLocked:
                    eventService.OnMapSelected.InvokeEvent(MapId);
                    break;
                case MapStatus.Completed:
                    eventService.OnMapSelected.InvokeEvent(MapId);
                    break;


            }

        }
    }
}