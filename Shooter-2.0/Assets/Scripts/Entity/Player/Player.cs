using TSI.Character.Movement;
using TSI.Drop;
using TSI.Entity;
using TSI.FSM;
using TSI.FSM.State;
using TSI.Item;
using TSI.Storage;
using UnityEngine;

namespace TSI.Character
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : HealthEntity
    {
        private BaseFSM _fsm;

        public Inventory Inventory { get; private set; }

        [Header("Movement")]
        [SerializeField] private PlayerMovementParameters _playerMovementParameters;

        [Header("Drop Picker")]
        [SerializeField] private DropPickerParameters _dropPickerParameters;

        [Header("Inventory")]
        [SerializeField] private ItemCache _itemCache;
        [SerializeField] private StorageView _storageView;
        [Space]
        [SerializeField] private InventoryParameters _inventoryParameters;

        public override void Initialize()
        {
            Inventory = new Inventory(_inventoryParameters.StartItems, _inventoryParameters.HotSlots, _inventoryParameters.AllSlots);

            var controller = GetComponent<CharacterController>();

            var movement = new PlayerGroundMovement(_playerMovementParameters,  controller, transform, Camera.main.transform);
            var dropPicker = new DropPicker(_dropPickerParameters);
            var slotSwitcher = new SlotSwitcher(_inventoryParameters.HotSlots, _itemCache);
            var inventoryUser = new StorageUser(Inventory);

            var allStates = new FSMState[]
            {
                new PlayerDefaultState(_fsm, dropPicker, slotSwitcher, movement, inventoryUser),
                new PlayerSwimState(_fsm, movement),
                new PlayerBuildState(_fsm),
            };

            _fsm = new BaseFSM(allStates);

            _storageView.Initialize(Inventory);

            base.Initialize();
        }

        private void Update()
        {
            _fsm.CurrentState?.Update();
        }
    }
}