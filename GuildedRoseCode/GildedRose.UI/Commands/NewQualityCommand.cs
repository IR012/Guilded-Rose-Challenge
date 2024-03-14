using GildedRose.Application.Interfaces.Services;
using GildedRose.UI.ViewModels;

namespace GildedRose.UI.Commands
{
    public class NewQualityCommand : CommandBase
    {
        private ShopItemsViewModel _shopItemsViewModel;
        private readonly IItemsService _itemsService;

        public NewQualityCommand(ShopItemsViewModel shopItemsViewModel, IItemsService itemsService)
        {
            _shopItemsViewModel = shopItemsViewModel;
            _itemsService = itemsService;
        }

        public override void Execute(object? parameter)
        {
            var items = _itemsService.GetUpdatedQuality();
            _shopItemsViewModel.Items = items;
        }

    }
}
