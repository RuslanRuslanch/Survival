using System;
using UnityEngine;

namespace TSI.Storage
{
    public class StorageView : MonoBehaviour, IDisposable
    {
        public Storage Storage { get; private set; }

        [SerializeField] private GameObject _slotsParent;

        public void Initialize(Storage storage)
        {
            Storage = storage;

            Storage.StorageOpened += OnOpen;
            Storage.StorageClosed += OnClose;
        }

        public void Dispose()
        {
            Storage.StorageOpened -= OnOpen;
            Storage.StorageClosed -= OnClose;
        }

        public virtual void OnClose()
        {
            _slotsParent.SetActive(false);
        }

        public virtual void OnOpen()
        {
            _slotsParent.SetActive(true);
        }
    }
}