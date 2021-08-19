using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CP380_B1_BlockList.Models;

namespace CP380_B3_BlockBlazor.Data
{
    public class MiningService
    {
        private BlockList blist;
        private BlockService blockService1;
        private PendingTransactionService PendingTransactionService;
        public MiningService(BlockService blockService, PendingTransactionService pendingTransactionService)
        {
            PendingTransactionService = pendingTransactionService;
            blockService1 = blockService;
        }
        public Task<Block> onPost()
        {

            Console.WriteLine("yes");
            return null;
        }
    }
}