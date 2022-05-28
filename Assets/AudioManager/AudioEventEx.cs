using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Audio
{
    public static class AudioEventEx
    {
        private static GameObject uiEmitter;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            uiEmitter = null;
        }

        public static void Play(this AudioEvent audio)
        {
            if (!Application.isPlaying)
            {
                return;
            }
            if (uiEmitter == null)
            {
                uiEmitter = new GameObject("Ui AudioSource");
                GameObject.DontDestroyOnLoad(uiEmitter);
            }
            Play(audio, uiEmitter);
        }

        public static void Play(this AudioEvent audio, GameObject emitter)
        {
            if (audio != null)
            {
                AudioManager.PlayEvent(audio, emitter);
            }
            else
            {
                Debug.Log("audio not assigned");
            }
        }
    }
}