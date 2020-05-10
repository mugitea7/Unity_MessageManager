using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{

    [SerializeField, TextArea(1, 10)] private List<string> mMessage = new List<string> { "ruhgurhgurhgurhg", "ijitjhtkfskdjfg" };

    public List<string> GetMessage {
        get
        {
            return mMessage;
        }
    }

}
