using UnityEngine;
using UnityEngine.UI;
using ServiceLocator.Events;
using UnityEngine.SceneManagement;
using TMPro;

namespace ServiceLocator.UI
{
    public class MapButton : MonoBehaviour
    {
        [SerializeField] private int MapId;
        [SerializeField] private string LevelName;
        private EventService eventService;
        [SerializeField] private GameObject levelText;
        private bool textStatus=false;

        

        public void Init(EventService eventService)
        {
            this.eventService = eventService;
            GetComponent<Button>().onClick.AddListener(OnMapButtonClicked);
        }

        // To Learn more about Events and Observer Pattern, check out the course list here: https://outscal.com/courses
        private void OnMapButtonClicked() 
        {
            Debug.Log("Map Button Click");
            // eventService.OnMapSelected.InvokeEvent(MapId);

            LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus( LevelName );

        switch ( levelStatus )
        {
            case LevelStatus.Locked:
                
                Debug.Log( "This Level is Locked" );
                
                if(textStatus==false)
                {
                    textStatus=true;
                    levelText.SetActive(true);
                    Invoke("DeactiveStatus",3f);
                    
                }
                
                break;

            case LevelStatus.Unlocked:
                
                Debug.Log( "This Level is UnLocked" + LevelName );
                // SceneManager.LoadScene( LevelName );
                eventService.OnMapSelected.InvokeEvent(MapId);
                break;

            case LevelStatus.Completed:
                
                Debug.Log( "This Level is completed" + LevelName );
                // SceneManager.LoadScene( LevelName );
                eventService.OnMapSelected.InvokeEvent(MapId);
                break;
        }

        }

        private void DeactiveStatus()
        {
            levelText.SetActive(false);
            textStatus=false;
        }
            

            
    }

         
    
}