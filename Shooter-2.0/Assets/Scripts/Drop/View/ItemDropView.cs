using UnityEngine;

namespace TSI.Drop
{
    [RequireComponent(typeof(AudioSource))]
    public class ItemDropView : BaseDropView
    {
        [Header("View")]
        [SerializeField] private AudioSource _source;
        [Space]
        [SerializeField] private AudioClip _clip;

        public override void OnPick()
        {
            if (_source.isPlaying)
                return;

            _source.PlayOneShot(_clip);

            Destroy(_source.gameObject);
        }
    }
}
