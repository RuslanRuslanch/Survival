using UnityEngine;

namespace TSI.Storage
{
    public class StorageUser : IUsable
    {
        private readonly Storage _storage;

        public StorageUser(Storage storage)
        {
            _storage = storage;
        }

        public bool TryUse()
        {
            if (Input.GetKeyDown(KeyCode.I) == false)
                return false;

            Use();

            return true;
        }

        public void Use()
        {
            if (_storage.IsOpened)
            {
                _storage.Close();
            }
            else
            {
                _storage.Open();
            }
        }
    }
}