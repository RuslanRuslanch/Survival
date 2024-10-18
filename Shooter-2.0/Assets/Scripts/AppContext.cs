using TSI.Factory;
using TSI.Item;
using UnityEngine;

namespace TSI
{
    public class AppContext : MonoBehaviour
    {
        public static AppContext Instance;

        public PlayerInput PlayerInput { get; private set; }

        [Header("Level")]
        [SerializeField] private Level _level;

        [Header("Scene Deps")]
        [SerializeField] private EntityFactory _entityFactory;

        private void Start()
        {
            Instance ??= this;

            _entityFactory.Initialize();

            _level.Initialize();
        }

        private void OnEnable()
        {
            PlayerInput = new PlayerInput();

            PlayerInput.Enable();
        }

        private void OnDisable()
        {
            PlayerInput.Disable();
        }
    }
}