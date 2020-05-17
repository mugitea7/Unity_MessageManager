using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message : MonoBehaviour
{

    [SerializeField] private bool mIsAbleToTalk = false;

    //TODO: structにして、立ち絵を追加.
    [SerializeField, TextArea(1, 10)] private List<string> mMessage = new List<string> { "ruhgurhgurhgurhg", "ijitjhtkfskdjfg" };

    public bool IsAbleToTalk
    {
        get
        {
            return mIsAbleToTalk;
        }
    }

    public List<string> GetMessage {
        get
        {
            return mMessage;
        }
    }

}
