using System.Linq;
using TSI.BuildSystem;
using TSI.Drop;
using TSI.Entities.Character.State;
using TSI.Items;
using TSI.Storages;
using UnityEngine;

namespace TSI.Entities.Character
{
    public class Player : HealthEntity, IStateSwitcher
    {
        private PlayerState[] _allStates;
        private PlayerState _currentState;

        public PlayerInput Input { get; private set; }
        public Inventory Inventory { get; private set; }

        [Header("Movement")]
        [SerializeField] private GroundMovementData _groundMovementData;
        [Space]
        [SerializeField] private CameraMovementData _cameraMovementData;

        [Header("Building User")]
        [SerializeField, Min(0f)] private float _buildingUseMaxDistance;
        [SerializeField] private LayerMask _buildingUseSearchLayers;

        [Header("DropPicker")]
        [SerializeField] private DropPickerView _pickerView;
        [Space]
        [SerializeField, Min(0f)] private float _pickerMaxDistance;
        [SerializeField] private LayerMask _pickerSearchLayers;

        [Header("Inventory")]
        [SerializeField] private Slot[] _allSlots;
        [SerializeField] private Slot[] _hotSlots;
        [Space]
        [SerializeField] private ItemStackInspector[] _startItems;

        protected override void OnSpawn()
        {
            base.OnSpawn();

            Input = new PlayerInput();
            Inventory = new Inventory(null, _allSlots, _hotSlots);

            var dropPicker = new DropPicker(this, _pickerMaxDistance, _pickerSearchLayers);
            var buildingUser = new BuildingUser(Input, _buildingUseMaxDistance, _buildingUseSearchLayers);

            var groundMovementLogic = new GroundMovementLogic(_groundMovementData, Input);
            var cameraMovementLogic = new CameraMovementLogic(_cameraMovementData, Input);

            _allStates = new PlayerState[]
            {
                new GroundMoveState(this, dropPicker, groundMovementLogic, cameraMovementLogic),
                new SwimState(this, null, null),
                new BuildState(this, groundMovementLogic, cameraMovementLogic),
            };

            _currentState = _allStates[0];

            _pickerView.Init(dropPicker);

            Input.Enable();
        }

        private void OnDisable()
        {
            Input.Disable();
        }

        private void Update()
        {
            _currentState.Move();
            _currentState.Attack();
            _currentState.Build();
            _currentState.Pick();
        }

        public void SwitchState<T>() where T : PlayerState
        {
            var currentState = _allStates.FirstOrDefault(currentState => currentState is T);

            _currentState.Stop();
            currentState.Start();

            _currentState = currentState;
        }
    }
}