﻿using Diplomat.Core;
using Diplomat.Client.Proxy.Inventory;

namespace MultipleIntegration.DiplomatProcess
{
    public class RemoveInventoryProcess : Process<int>
    {
        private readonly IInventoryProxy _inventoryProxy;

        public RemoveInventoryProcess(IInventoryProxy inventoryProxy)
        {
            _inventoryProxy = inventoryProxy;
        }

        protected override void Execute(int id)
        {
            _inventoryProxy.Remove(id);
        }
    }
}
