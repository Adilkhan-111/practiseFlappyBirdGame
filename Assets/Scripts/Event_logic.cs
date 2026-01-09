using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event_logic : MonoBehaviour
{
    public static event Action PlayerDied;
    public static void OnPlayerDied()
    {
        PlayerDied?.Invoke();
    }
    public static event Action PlayerScore;
    public static void OnPlayerScore()
    {
        PlayerScore?.Invoke();
    }
    
}
