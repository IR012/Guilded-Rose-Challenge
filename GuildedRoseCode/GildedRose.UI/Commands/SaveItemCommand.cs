using GildedRose.Application.Interfaces.Services;
using GildedRose.UI.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace GildedRose.UI.Commands
{
    public class SaveItemCommand : AsyncCommandBase
    {
        private ShopItemsViewModel _shopItemsViewModel;
        private readonly IItemsService _itemsService;

        public SaveItemCommand(ShopItemsViewModel shopItemsViewModel, IItemsService itemsService)
        {
            _shopItemsViewModel = shopItemsViewModel;
            _itemsService = itemsService;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            await _itemsService.SaveItemsAsync(_shopItemsViewModel.Items);
            MessageBox.Show("Items Saved");
        }

    }
}
