using GildedRose.Application.Interfaces.Services;
using GildedRose.UI.ViewModels;
using System.Threading.Tasks;
using System.Windows;

namespace GildedRose.UI.Commands
{
    public class ResetItemCommand : AsyncCommandBase
    {
        private ShopItemsViewModel _shopItemsViewModel;
        private readonly IItemsService _itemsService;

        public ResetItemCommand(ShopItemsViewModel shopItemsViewModel, IItemsService itemsService) 
        {
            _shopItemsViewModel = shopItemsViewModel;
            _itemsService = itemsService;
        }

        protected override async Task ExecuteAsync(object? parameter)
        {
            var items = await _itemsService.ResetItemsAsync();
            _shopItemsViewModel.Items = items; 
            MessageBox.Show("Items Reset");
        }
    }
}
