﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NBlockChain.Models
{
    public class BlockHeader
    {
        public byte[] BlockId { get; set; }

        public uint Height { get; set; }

        public BlockStatus Status { get; set; }

        public long Timestamp { get; set; }

        public uint Version { get; set; }

        public long Nonce { get; set; }

        public byte[] PreviousBlock { get; set; }

        public byte[] MerkelRoot { get; set; }

        public byte[] CombineHashableElementsWithNonce(long nonce)
        {
            return MerkelRoot
                .Concat(PreviousBlock)
                .Concat(BitConverter.GetBytes(Height))
                .Concat(BitConverter.GetBytes(Version))
                .Concat(BitConverter.GetBytes(nonce))
                .ToArray();
        }

    }

    public enum BlockStatus
    {
        Open = 0,
        Closed = 1,
        Notarized = 2
    }
}
