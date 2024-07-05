using UnityEngine;
using Provider.Manager;
using Actions;

namespace Manager.Sound 
{
    /// <summary>
    /// Manages all sound in the game
    /// </summary>
    public class SoundManager : MonoBehaviour
    {
        #region Variables
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;

        private bool musicOn;
        private bool sfxOn;
        #endregion

        #region Properties
        public bool IsSfxOn { get { return sfxOn; } }
        public bool IsMusicOn {  get { return musicOn; } }
        #endregion

        #region Unity Methods
        private void Awake()
        {
            ManagerProvider.Instance.SoundManager = this;
            musicOn = true;
            sfxOn = true;
            musicSource.Play();
            GameActions.OnMusicStatusChange += OnChangeMusicStatus;
            GameActions.OnSfxStatusChange += OnChangeSfxStatus;
            GameActions.OnPlaySFXAudio += PlaySFX;
        }

        private void OnDestroy()
        {
            GameActions.OnMusicStatusChange -= OnChangeMusicStatus;
            GameActions.OnSfxStatusChange -= OnChangeSfxStatus;
            GameActions.OnPlaySFXAudio -= PlaySFX;
        }
        #endregion

        #region Methods
        private void OnChangeSfxStatus(bool val)
        {
            sfxOn = val;
            sfxSource.mute = !val;
        }

        private void OnChangeMusicStatus(bool val)
        {
            musicOn = val;
            musicSource.mute = !val;
        }

        private void PlaySFX(AudioClip audioClip)
        {
            sfxSource.PlayOneShot(audioClip);
        }
        #endregion
    }
}