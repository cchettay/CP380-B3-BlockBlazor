using System;
using System.Collections.Generic;

namespace CP380_B1_BlockList.Models
{
    public class BlockList
    {
        public IList<Block> Chain { get; set; }

        public int Difficulty { get; set; } = 2;

        public BlockList()
        {
            Chain = new List<Block>();
            MakeFirstBlock();
        }

        public void MakeFirstBlock()
        {
            var block = new Block(DateTime.Now, null, new List<Payload>());
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public void AddBlock(Block block)
        {
            // TODO
            int chainlength = Chain.Count - 1;
            block.PreviousHash = Chain[chainlength].Hash;
            block.Mine(Difficulty);
            Chain.Add(block);
        }

        public bool IsValid()
        {
            // TODO
            string CValue = new string('C', Difficulty);
            int i;
            for (i = 0; i < Chain.Count; i++)
            {
                if (!Chain[i].Hash.StartsWith(CValue) || (i > 0 && !Chain[i].PreviousHash.Equals(Chain[i - 1].Hash)))
                {
                    return false;
                }

            }
            return true;
        }
    }
}