using System;
using Unity.RenderStreaming;
using Unity.WebRTC;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Custom.RenderStreaming.WebInput
{
    public class WebBrowserInputChannelReceiver : InputChannelReceiverBase
    {
        [HideInInspector] public UnityEvent<int> Event_OnWebButtonClick = new UnityEvent<int>();

        public override event Action<InputDevice, InputDeviceChange> onDeviceChange;

        private RemoteInput remoteInput;

        private void Start()
        {
            
        }

        private void Update()
        {
            
        }

        public override void SetChannel(string connectionId, RTCDataChannel channel)
        {
            if (channel == null)
            {
                if (remoteInput != null)
                {
					onDeviceChange?.Invoke(remoteInput.RemoteGamepad, InputDeviceChange.Removed);
					onDeviceChange?.Invoke(remoteInput.RemoteKeyboard, InputDeviceChange.Removed);
					onDeviceChange?.Invoke(remoteInput.RemoteMouse, InputDeviceChange.Removed);
					onDeviceChange?.Invoke(remoteInput.RemoteTouchscreen, InputDeviceChange.Removed);
                    remoteInput.Dispose();
                    remoteInput = null;
                }
            }
            else
            {
                remoteInput = RemoteInputReceiver.Create();
                remoteInput.ActionButtonClick = OnButtonClick;
                channel.OnMessage += remoteInput.ProcessInput;
				onDeviceChange?.Invoke(remoteInput.RemoteGamepad, InputDeviceChange.Added);
				onDeviceChange?.Invoke(remoteInput.RemoteKeyboard, InputDeviceChange.Added);
				onDeviceChange?.Invoke(remoteInput.RemoteMouse, InputDeviceChange.Added);
				onDeviceChange?.Invoke(remoteInput.RemoteTouchscreen, InputDeviceChange.Added);
            }
            base.SetChannel(connectionId, channel);
        }




        public virtual void OnButtonClick(int elementId)
        {
            Event_OnWebButtonClick.Invoke(elementId);
        }

        public virtual void OnDestroy()
        {
            remoteInput?.Dispose();
        }
    }
}
