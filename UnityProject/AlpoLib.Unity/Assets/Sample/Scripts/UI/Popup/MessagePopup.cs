using alpoLib.Res;
using alpoLib.UI;
using TMPro;
using UnityEngine;

namespace alpoLib.Sample
{
    [PrefabPath("Addr/UI/Popup/MessagePopup.prefab")]
    public class MessagePopup : PopupBase
    {
        [SerializeField] protected TMP_Text messageText;
        [SerializeField] protected TMP_Text okText;

        public static MessagePopup CreateMessagePopup(string message, string ok)
        {
            var p = CreatePopup<MessagePopup>();
            p.messageText.text = message;
            p.okText.text = ok;
            return p;
        }

        public void OnClickOk()
        {
            Result = PopupCloseResult.Ok;
            Close();
        }
    }
}