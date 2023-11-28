using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using UnityEngine.UIElements;

public class SessionManager_8 : MonoBehaviour
{
    public static SessionManager_8 ins;
    [SerializeField] List<GameObject> ListSessions;
    int complete_session; 
    private void Start()
    {
        ins = this;
    }

    public void EnableNextSession()
    {
        ListSessions[complete_session].SetActive(false);
        complete_session++;
        if (complete_session < ListSessions.Count)
        {
            ListSessions[complete_session].SetActive(true);
        }
    }


}
