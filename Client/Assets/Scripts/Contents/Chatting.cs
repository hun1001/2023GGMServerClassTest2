using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Google.Protobuf.Protocol;

public class Chatting : MonoBehaviour
{
    [SerializeField]
    private InputField _inputField = null;

    private void Awake()
    {
        _inputField.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_inputField.gameObject.activeSelf == false)
            {
                _inputField.gameObject.SetActive(true);
                _inputField.ActivateInputField();
            }
            else
            {
                if (string.IsNullOrEmpty(_inputField.text) == false)
                {
                    Managers.Network.Send(new C_Chat() { Chat = _inputField.text });
                    _inputField.text = string.Empty;
                }
                _inputField.gameObject.SetActive(false);
            }
        }
    }
}
