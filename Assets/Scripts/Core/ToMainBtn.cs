using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ADAM.Core
{
    public class ToMainBtn : MonoBehaviour
    {

        public EventObject _event;

        public void OnClick_ToMainBtn()
        {  
            _event.OnOccure();
        }
    }
}
