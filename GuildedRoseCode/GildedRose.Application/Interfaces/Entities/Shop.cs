using GildedRose.Application.Entities;
using System.Collections.Generic;

namespace GildedRose.Application.Interfaces.Entities
{
    public interface IShop
    {
        public IList<Item> Items { get; set; }
        public void UpdateQuality();
    }
}
