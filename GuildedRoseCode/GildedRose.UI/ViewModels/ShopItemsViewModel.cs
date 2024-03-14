using GildedRose.Application.Entities;
using GildedRose.Application.Interfaces.Entities;
using GildedRose.Application.Interfaces.Services;
using GildedRose.UI.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace GildedRose.UI.ViewModels
{
    public class ShopItemsViewModel : ViewModelBase
    {
        private IShop _shop;

        private readonly IItemsService _itemsService;

        private ObservableCollection<Item> _items;
        public IList<Item> Items
        {
            get => _items;
            set 
            { 
                _items = new ObservableCollection<Item>(value);
                _shop.Items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public ICommand NewItem { get; }
        public ICommand ResetItem { get; }
        public ICommand SaveItem { get; }

        public ShopItemsViewModel(IShop shop, IItemsService itemsService)
        {
            _shop = shop;
            _items = new ObservableCollection<Item>(_shop.Items);
            _itemsService = itemsService;

            NewItem = new NewQualityCommand(this, itemsService);
            ResetItem = new ResetItemCommand(this, itemsService);
            SaveItem = new SaveItemCommand(this, itemsService);
        }

    }
}
