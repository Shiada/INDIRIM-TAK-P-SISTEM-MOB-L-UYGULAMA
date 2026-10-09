using Indirimci.Models;

namespace Indirimci.Services;

public class DataService
{
    public List<Category> GetCategories()
    {
        var categories = new List<Category>
        {
            new() { Id = "giyim", Name = "Giyim", Icon = "👗",
                GradientStart = Color.FromArgb("#667eea"), GradientEnd = Color.FromArgb("#764ba2"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Çocuk Giyim", "Ayakkabı", "Aksesuar", "Çanta" } },
            new() { Id = "parfum", Name = "Parfüm", Icon = "🧴",
                GradientStart = Color.FromArgb("#f093fb"), GradientEnd = Color.FromArgb("#f5576c"),
                SubCategories = new() { "Kadın Parfüm", "Erkek Parfüm", "Unisex Parfüm", "Set", "Deodorant" } },
            new() { Id = "kozmetik", Name = "Kozmetik", Icon = "💄",
                GradientStart = Color.FromArgb("#4facfe"), GradientEnd = Color.FromArgb("#00f2fe"),
                SubCategories = new() { "Makyaj", "Cilt Bakım", "Saç Bakım", "Vücut Bakım" } },
            new() { Id = "spor", Name = "Spor", Icon = "⚽",
                GradientStart = Color.FromArgb("#43e97b"), GradientEnd = Color.FromArgb("#38f9d7"),
                SubCategories = new() { "Spor Giyim", "Spor Ayakkabı", "Fitness Ekipman", "Outdoor" } },
            new() { Id = "elektronik", Name = "Elektronik", Icon = "📱",
                GradientStart = Color.FromArgb("#fa709a"), GradientEnd = Color.FromArgb("#fee140"),
                SubCategories = new() { "Telefon", "Kulaklık", "Saat", "Tablet" } },
            new() { Id = "ev", Name = "Ev & Yaşam", Icon = "🏠",
                GradientStart = Color.FromArgb("#a18cd1"), GradientEnd = Color.FromArgb("#fbc2eb"),
                SubCategories = new() { "Ev Tekstil", "Mutfak", "Dekorasyon", "Banyo" } }
        };

        var brands = GetBrands();
        foreach (var cat in categories)
            cat.BrandCount = brands.Count(b => b.CategoryId == cat.Id);

        return categories;
    }

    public List<Brand> GetBrands()
    {
        return new List<Brand>
        {
            new() { Id = "zara", Name = "Zara", CategoryId = "giyim", LogoText = "ZARA",
                GradientStart = Color.FromArgb("#2c2c2c"), GradientEnd = Color.FromArgb("#000000"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Çocuk Giyim", "Ayakkabı", "Aksesuar", "Çanta" }, IsPopular = true },
            new() { Id = "bershka", Name = "Bershka", CategoryId = "giyim", LogoText = "BSK",
                GradientStart = Color.FromArgb("#434343"), GradientEnd = Color.FromArgb("#1a1a1a"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Ayakkabı", "Aksesuar" }, IsPopular = true },
            new() { Id = "defacto", Name = "DeFacto", CategoryId = "giyim", LogoText = "DF",
                GradientStart = Color.FromArgb("#ff4b4b"), GradientEnd = Color.FromArgb("#e31e24"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Çocuk Giyim", "Ayakkabı", "Aksesuar" }, IsPopular = true },
            new() { Id = "lcwaikiki", Name = "LC Waikiki", CategoryId = "giyim", LogoText = "LCW",
                GradientStart = Color.FromArgb("#4da6ff"), GradientEnd = Color.FromArgb("#0066cc"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Çocuk Giyim", "Ayakkabı", "Aksesuar" }, IsPopular = true },
            new() { Id = "hm", Name = "H&M", CategoryId = "giyim", LogoText = "H&M",
                GradientStart = Color.FromArgb("#ff3333"), GradientEnd = Color.FromArgb("#cc0000"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Çocuk Giyim", "Ayakkabı" }, IsPopular = true },
            new() { Id = "mango", Name = "Mango", CategoryId = "giyim", LogoText = "MNG",
                GradientStart = Color.FromArgb("#d4b896"), GradientEnd = Color.FromArgb("#c5a572"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Ayakkabı", "Aksesuar" }, IsPopular = false },
            new() { Id = "koton", Name = "Koton", CategoryId = "giyim", LogoText = "KTN",
                GradientStart = Color.FromArgb("#555555"), GradientEnd = Color.FromArgb("#2d2d2d"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Çocuk Giyim", "Ayakkabı" }, IsPopular = false },
            new() { Id = "pull_bear", Name = "Pull & Bear", CategoryId = "giyim", LogoText = "P&B",
                GradientStart = Color.FromArgb("#6b6b6b"), GradientEnd = Color.FromArgb("#4a4a4a"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Ayakkabı", "Aksesuar" }, IsPopular = false },
            new() { Id = "mad_parfum", Name = "MAD Parfüm", CategoryId = "parfum", LogoText = "MAD",
                GradientStart = Color.FromArgb("#a78bfa"), GradientEnd = Color.FromArgb("#8b5cf6"),
                SubCategories = new() { "Kadın Parfüm", "Erkek Parfüm", "Unisex Parfüm", "Set", "Deodorant" }, IsPopular = true },
            new() { Id = "bargello", Name = "Bargello", CategoryId = "parfum", LogoText = "BRG",
                GradientStart = Color.FromArgb("#f59e0b"), GradientEnd = Color.FromArgb("#d97706"),
                SubCategories = new() { "Kadın Parfüm", "Erkek Parfüm", "Unisex Parfüm", "Set" }, IsPopular = true },
            new() { Id = "golden_rose", Name = "Golden Rose", CategoryId = "kozmetik", LogoText = "GR",
                GradientStart = Color.FromArgb("#e0c88a"), GradientEnd = Color.FromArgb("#c9a96e"),
                SubCategories = new() { "Makyaj", "Cilt Bakım", "Saç Bakım" }, IsPopular = false },
            new() { Id = "flormar", Name = "Flormar", CategoryId = "kozmetik", LogoText = "FLR",
                GradientStart = Color.FromArgb("#f472b6"), GradientEnd = Color.FromArgb("#ec4899"),
                SubCategories = new() { "Makyaj", "Cilt Bakım", "Saç Bakım", "Vücut Bakım" }, IsPopular = true },
            new() { Id = "gratis", Name = "Gratis", CategoryId = "kozmetik", LogoText = "GRT",
                GradientStart = Color.FromArgb("#34d399"), GradientEnd = Color.FromArgb("#10b981"),
                SubCategories = new() { "Makyaj", "Cilt Bakım", "Saç Bakım", "Vücut Bakım" }, IsPopular = true },
            new() { Id = "watsons", Name = "Watsons", CategoryId = "kozmetik", LogoText = "WTS",
                GradientStart = Color.FromArgb("#38bdf8"), GradientEnd = Color.FromArgb("#0ea5e9"),
                SubCategories = new() { "Makyaj", "Cilt Bakım", "Saç Bakım", "Vücut Bakım" }, IsPopular = false },
            new() { Id = "nike", Name = "Nike", CategoryId = "spor", LogoText = "NK",
                GradientStart = Color.FromArgb("#fb923c"), GradientEnd = Color.FromArgb("#f97316"),
                SubCategories = new() { "Spor Giyim", "Spor Ayakkabı", "Aksesuar" }, IsPopular = true },
            new() { Id = "adidas", Name = "Adidas", CategoryId = "spor", LogoText = "ADI",
                GradientStart = Color.FromArgb("#3b82f6"), GradientEnd = Color.FromArgb("#1e40af"),
                SubCategories = new() { "Spor Giyim", "Spor Ayakkabı", "Aksesuar" }, IsPopular = true },
            new() { Id = "puma", Name = "Puma", CategoryId = "spor", LogoText = "PMA",
                GradientStart = Color.FromArgb("#ef4444"), GradientEnd = Color.FromArgb("#dc2626"),
                SubCategories = new() { "Spor Giyim", "Spor Ayakkabı", "Aksesuar" }, IsPopular = false },
            new() { Id = "decathlon", Name = "Decathlon", CategoryId = "spor", LogoText = "DCT",
                GradientStart = Color.FromArgb("#0ea5e9"), GradientEnd = Color.FromArgb("#0369a1"),
                SubCategories = new() { "Spor Giyim", "Spor Ayakkabı", "Fitness Ekipman", "Outdoor" }, IsPopular = false },
            new() { Id = "boyner", Name = "Boyner", CategoryId = "giyim", LogoText = "BYN",
                GradientStart = Color.FromArgb("#a78bfa"), GradientEnd = Color.FromArgb("#7c3aed"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Çocuk Giyim", "Ayakkabı", "Aksesuar" }, IsPopular = false },
            new() { Id = "trendyol", Name = "Trendyol", CategoryId = "giyim", LogoText = "TY",
                GradientStart = Color.FromArgb("#fba94c"), GradientEnd = Color.FromArgb("#f27a1a"),
                SubCategories = new() { "Kadın Giyim", "Erkek Giyim", "Çocuk Giyim", "Ayakkabı", "Aksesuar" }, IsPopular = true },
        };
    }

    public List<Deal> GetDeals()
    {
        var brands = GetBrands().ToDictionary(b => b.Id);
        var deals = new List<Deal>
        {
            new() { Id = "d1", BrandId = "zara", Title = "Sezon Sonu Büyük İndirim!", Description = "Tüm kış koleksiyonunda %50'ye varan indirimler başladı!", Discount = "%50'ye varan", Category = "Kadın Giyim", TimeAgo = "2 saat önce", IsNew = true, IsTrending = true, Icon = "👗" },
            new() { Id = "d2", BrandId = "mad_parfum", Title = "2 Al 1 Öde Kampanyası", Description = "Seçili parfümlerde 2 al 1 öde fırsatı!", Discount = "2 Al 1 Öde", Category = "Kadın Parfüm", TimeAgo = "3 saat önce", IsNew = true, IsTrending = true, Icon = "🧴" },
            new() { Id = "d3", BrandId = "defacto", Title = "Tüm Ürünlerde %40 İndirim", Description = "Online mağazada geçerli, sepette %40 indirim!", Discount = "%40", Category = "Erkek Giyim", TimeAgo = "5 saat önce", IsNew = true, IsTrending = true, Icon = "👔" },
            new() { Id = "d4", BrandId = "bargello", Title = "Yeni Sezon Parfümlerde %30", Description = "Bahar koleksiyonu parfümlerde %30 indirim!", Discount = "%30", Category = "Erkek Parfüm", TimeAgo = "6 saat önce", IsNew = true, IsTrending = false, Icon = "🧴" },
            new() { Id = "d5", BrandId = "lcwaikiki", Title = "Çocuk Giyimde Süper Fırsatlar", Description = "%60'a varan çocuk giyim indirimleri!", Discount = "%60'a varan", Category = "Çocuk Giyim", TimeAgo = "8 saat önce", IsNew = false, IsTrending = true, Icon = "👶" },
            new() { Id = "d6", BrandId = "nike", Title = "Spor Ayakkabıda %35 İndirim", Description = "Air Max, Air Force ve daha fazlası!", Discount = "%35", Category = "Spor Ayakkabı", TimeAgo = "10 saat önce", IsNew = false, IsTrending = true, Icon = "👟" },
            new() { Id = "d7", BrandId = "flormar", Title = "Makyaj Setlerinde %25 İndirim", Description = "Ruj, fondöten, far ve daha fazlası!", Discount = "%25", Category = "Makyaj", TimeAgo = "12 saat önce", IsNew = false, IsTrending = false, Icon = "💄" },
            new() { Id = "d8", BrandId = "bershka", Title = "Yeni Sezon İndirimleri", Description = "%30'a varan indirim fırsatı!", Discount = "%30'a varan", Category = "Kadın Giyim", TimeAgo = "14 saat önce", IsNew = false, IsTrending = false, Icon = "👗" },
            new() { Id = "d9", BrandId = "adidas", Title = "Outlet'te Ekstra %20", Description = "İndirim kodu: EXTRA20", Discount = "Ekstra %20", Category = "Spor Giyim", TimeAgo = "1 gün önce", IsNew = false, IsTrending = false, Icon = "🏃" },
            new() { Id = "d10", BrandId = "gratis", Title = "Cilt Bakımda 3 Al 2 Öde", Description = "Seçili cilt bakım ürünlerinde fırsat!", Discount = "3 Al 2 Öde", Category = "Cilt Bakım", TimeAgo = "1 gün önce", IsNew = false, IsTrending = false, Icon = "✨" },
            new() { Id = "d11", BrandId = "hm", Title = "Ayakkabıda %45 İndirim", Description = "Büyük ayakkabı koleksiyonu indirimi!", Discount = "%45'e varan", Category = "Ayakkabı", TimeAgo = "1 gün önce", IsNew = false, IsTrending = true, Icon = "👠" },
            new() { Id = "d12", BrandId = "trendyol", Title = "Süper İndirim Günleri", Description = "%70'e varan indirim!", Discount = "%70'e varan", Category = "Kadın Giyim", TimeAgo = "2 gün önce", IsNew = false, IsTrending = true, Icon = "🛍️" },
            new() { Id = "d13", BrandId = "zara", Title = "Aksesuar Koleksiyonunda %25", Description = "Çanta ve aksesuarlarda indirim!", Discount = "%25", Category = "Aksesuar", TimeAgo = "2 gün önce", IsNew = false, IsTrending = false, Icon = "👜" },
            new() { Id = "d14", BrandId = "mad_parfum", Title = "Erkek Parfümde %20 İndirim", Description = "Yeni çıkan kokular dahil!", Discount = "%20", Category = "Erkek Parfüm", TimeAgo = "2 gün önce", IsNew = false, IsTrending = false, Icon = "🧴" },
            new() { Id = "d15", BrandId = "decathlon", Title = "Outdoor Ekipmanlarda Fırsat", Description = "%40'a varan indirim!", Discount = "%40'a varan", Category = "Outdoor", TimeAgo = "3 gün önce", IsNew = false, IsTrending = false, Icon = "⛺" },
            new() { Id = "d16", BrandId = "koton", Title = "Bahar Koleksiyonu İndirimi", Description = "%35'e varan erken indirim!", Discount = "%35'e varan", Category = "Kadın Giyim", TimeAgo = "3 gün önce", IsNew = false, IsTrending = false, Icon = "🌸" },
        };

        foreach (var deal in deals)
        {
            if (brands.TryGetValue(deal.BrandId, out var brand))
            {
                deal.BrandName = brand.Name;
                deal.BrandColorStart = brand.GradientStart;
                deal.BrandColorEnd = brand.GradientEnd;
            }
        }

        return deals;
    }

    public List<AppNotification> GetSampleNotifications()
    {
        var brands = GetBrands().ToDictionary(b => b.Id);
        var notifications = new List<AppNotification>
        {
            new() { Id = "n1", BrandId = "zara", Title = "Zara'da Büyük İndirim! 🎉", Description = "%50'ye varan indirim başladı!", Time = "2 saat önce", IsUnread = true, Icon = "🏷️", DealId = "d1" },
            new() { Id = "n2", BrandId = "mad_parfum", Title = "MAD Parfüm: 2 Al 1 Öde!", Description = "Kaçırılmayacak kampanya!", Time = "3 saat önce", IsUnread = true, Icon = "🏷️", DealId = "d2" },
            new() { Id = "n3", BrandId = "defacto", Title = "DeFacto %40 İndirim", Description = "Tüm ürünlerde sepette %40!", Time = "5 saat önce", IsUnread = false, Icon = "🏷️", DealId = "d3" },
            new() { Id = "n4", BrandId = "nike", Title = "Nike Spor Ayakkabı İndirimi", Description = "%35 indirim fırsatı!", Time = "10 saat önce", IsUnread = false, Icon = "🏷️", DealId = "d6" },
            new() { Id = "n5", BrandId = "trendyol", Title = "Trendyol Süper Fırsat!", Description = "%70'e varan indirim!", Time = "2 gün önce", IsUnread = false, Icon = "📢", DealId = "d12" },
        };

        foreach (var notif in notifications)
        {
            if (brands.TryGetValue(notif.BrandId, out var brand))
            {
                notif.BrandColorStart = brand.GradientStart;
                notif.BrandColorEnd = brand.GradientEnd;
            }
        }

        return notifications;
    }

    public string GetCategoryName(string catId)
    {
        return catId switch
        {
            "giyim" => "Giyim",
            "parfum" => "Parfüm",
            "kozmetik" => "Kozmetik",
            "spor" => "Spor",
            "elektronik" => "Elektronik",
            "ev" => "Ev & Yaşam",
            _ => ""
        };
    }
}
