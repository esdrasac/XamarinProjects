using System;

using Find_Cep.Models;

namespace Find_Cep.ViewModels {
    public class ItemDetailViewModel : BaseViewModel {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null) {
            Title = item?.Text;
            Item = item;
        }
    }
}
