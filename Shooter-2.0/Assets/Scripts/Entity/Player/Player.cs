using System.Linq;
using TSI.Character.Movement;
using TSI.Character.State;
using TSI.Drop;
using TSI.Entity;
using TSI.Storages;
using UnityEngine;

namespace TSI.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : HealthEntity, IStateSwitcher
    {
        private PlayerState[] _allStates;

        private PlayerState _currentState;

        public Inventory Inventory { get; private set; }

        [Header("Movement")]
        [SerializeField] private PlayerMovementParameters _playerMovementParameters;

        [Header("Drop Picker")]
        [SerializeField] private DropPickerParameters _dropPickerParameters;

        [Header("Inventory")]
        [SerializeField] private InventoryParameters _inventoryParameters;

        public override void Initialize()
        {
            Inventory = new Inventory(_inventoryParameters.HotSlots, _inventoryParameters.AllSlots);

            var movement = new PlayerMovement(new GroundPlayerMovementLogic(_playerMovementParameters, GetComponent<CharacterController>(), transform, Camera.main.transform));

            var dropPicker = new DropPicker(_dropPickerParameters);

            _allStates = new PlayerState[]
            {
                new GroundMoveState(this, movement, null, dropPicker)
            };

            _currentState = _allStates[0];

            base.Initialize();
        }

        public void SelectItem()
        {
            _currentState.SelectItem();
        }

        public void UseItem()
        {
            _currentState.UseItem();
        }

        public void Translate()
        {
            _currentState.Translate();
        }

        public void Rotate()
        {
            _currentState.Rotate();
        }

        public void PickUp()
        {
            _currentState.PickUp();
        }

        private void Update()
        {
            Rotate();

            SelectItem();
            UseItem();

            PickUp();
        }

        private void FixedUpdate()
        {
            Translate();
        }

        public void SwitchState<T>() where T : PlayerState
        {
            var state = _allStates.FirstOrDefault(state => state is T);

            _currentState.Stop();
            state.Start();

            _currentState = state;
        }
    }
}