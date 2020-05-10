namespace Mugitea.MessageManager
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class MessageManager : SingletonMonoBehaviour<MessageManager>
    {

        [SerializeField] private float mMessageSpeed = 0;

        [SerializeField] private Text mMessageText = null;

        private bool mIsStsrtedMessage = false;

        private float mTime = 0f;

        private void Start()
        {
            mMessageText.text = "";
        }

        public void Message(List<string> messageList, KeyCode nextKey = KeyCode.Return)
        {  
            //重複防止.
            if(!mIsStsrtedMessage)
            {
                StartCoroutine(MessageCoroutine(messageList, nextKey));
            }
            
        }
        
        private IEnumerator MessageCoroutine(List<string> messageList, KeyCode nextKey)
        {
            mIsStsrtedMessage = true;
            mTime = 0f;

            mMessageText.text = "";

            yield return new WaitForEndOfFrame();

            foreach (string message in messageList) {

                foreach (char messageChar in message)
                {
                    if (mMessageSpeed <= 0)
                    {
                        mMessageText.text = message;
                        break;
                    }

                    mMessageText.text += messageChar;

                    //次の文字表示への待ち.
                    while (mTime < mMessageSpeed)
                    {
                        mTime += Time.deltaTime;

                        //メッセージ飛ばし.
                        if (Input.GetKeyDown(nextKey))
                        {
                            mMessageText.text = message;
                            yield return new WaitForSeconds(0.1f);
                            //二重ループを抜ける為.
                            goto MESSAGEEND;
                        }

                        yield return null;
                    }

                    mTime = 0f;
                }

                MESSAGEEND:

                //次のメッセージ送りの待ち.
                while (true)
                {
                    if (Input.GetKeyDown(nextKey))
                    {
                        mMessageText.text = "";
                        yield return new WaitForSeconds(0.1f);
                        break;
                    }

                    yield return null;
                }
            }

            mIsStsrtedMessage = false;

        }
        
    }

}