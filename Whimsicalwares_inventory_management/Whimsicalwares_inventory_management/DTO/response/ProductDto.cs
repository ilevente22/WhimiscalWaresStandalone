using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whimsicalwares_inventory_management.DTO.response
{
    public class ProductDto
    {
        public string Bvin { get; set; }
        public string Sku { get; set; }
        public string ProductName { get; set; }
        public string ProductTypeId { get; set; }
        //public List<CustomProperty> CustomProperties { get; set; }
        //public decimal ListPrice { get; set; }
        //public decimal SitePrice { get; set; }
        //public string SitePriceOverrideText { get; set; }
        //public decimal SiteCost { get; set; }
        //public string MetaKeywords { get; set; }
        //public string MetaDescription { get; set; }
        //public string MetaTitle { get; set; }
        //public bool TaxExempt { get; set; }
        //public int TaxSchedule { get; set; }
        //public ShippingDetails ShippingDetails { get; set; }
        //public int ShippingMode { get; set; }
        //public int Status { get; set; }
        //public string ImageFileSmall { get; set; }
        //public string ImageFileSmallAlternateText { get; set; }
        //public string ImageFileMedium { get; set; }
        //public string ImageFileMediumAlternateText { get; set; }
        //public string CreationDateUtc { get; set; }
        public int MinimumQty { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        //public string ManufacturerId { get; set; }
        //public string VendorId { get; set; }
        //public bool GiftWrapAllowed { get; set; }
        //public decimal GiftWrapPrice { get; set; }
        //public string Keywords { get; set; }
        //public string PreContentColumnId { get; set; }
        //public string PostContentColumnId { get; set; }
        //public string UrlSlug { get; set; }
        public int InventoryMode { get; set; }
        public bool IsAvailableForSale { get; set; }
        //public bool Featured { get; set; }
        //public bool? AllowReviews { get; set; }
        //public List<object> Tabs { get; set; }
        public int StoreId { get; set; }
        public bool IsSearchable { get; set; }
        public int ShippingCharge { get; set; }
    }
}
