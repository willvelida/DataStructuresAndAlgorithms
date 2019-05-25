﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ExploringGraphs
{
    public class Subset<T>
    {
        public Node<T> Parent { get; set; }
        public int Rank { get; set; }

        public override string ToString()
        {
            return $"Subset with rank {Rank}, parent: {Parent.Data} (index: {Parent.Index})";
        }
    }
}
