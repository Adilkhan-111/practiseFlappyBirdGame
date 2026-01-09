
using UnityEngine;

public class TriggerDetect : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("top") || collision.gameObject.CompareTag("bottom"))
        {
            gameObject.SetActive(false);
            Event_logic.OnPlayerDied();
            
        }

        
        
    }

    
}
