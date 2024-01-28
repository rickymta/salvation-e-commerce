using Microsoft.AspNetCore.Mvc;
using Salvation.Library.Common.Abstractions;
using Salvation.Library.Models.ViewModels;

namespace Salvation.Presentation.WebApp.Components;

/// <summary>
/// CategoryComponent
/// </summary>
public class CategoryComponent : ViewComponent
{
    /// <summary>
    /// IRestProvider
    /// </summary>
    private readonly IRestProvider _restProvider;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="restProvider"></param>
    public CategoryComponent(IRestProvider restProvider)
    {
        _restProvider = restProvider;
    }

    /// <summary>
    /// Invoke
    /// </summary>
    /// <returns></returns>
    public async Task<IViewComponentResult> Invoke()
    {
        //var categoriesResult = await _restProvider.CallJsonAsync("https://localhost:7041/api/category/get-active-categories", HttpMethod.Get);
        //var result = await _restProvider.ConvertHttpResponseMessageToObject<List<CategoryViewModel>>(categoriesResult);
        var categories = new List<CategoryViewModel>
        {
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Laptop & phụ kiện",
                ParentId = null,
                Slug = "laptop-va-phu-kien",
                Children = null
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Máy đồng bộ",
                ParentId = null,
                Slug = "may-dong-bo",
                Children = null
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Máy chơi game",
                ParentId = null,
                Slug = "may-choi-game",
                Children = null
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Linh kiện máy tính",
                ParentId = null,
                Slug = "linh-kien-may-tinh",
                Children = new List<CategoryViewModel>
                {
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "CPU",
                        ParentId = null,
                        Slug = "cpu",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Mainboard",
                        ParentId = null,
                        Slug = "mainboard",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "RAM - Bộ nhớ trong",
                        ParentId = null,
                        Slug = "ram-bo-nho-trong",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Ổ cứng HDD",
                        ParentId = null,
                        Slug = "o-cung-hdd",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Ổ cứng SSD",
                        ParentId = null,
                        Slug = "o-cung-ssd",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "VGA - Card màn hình",
                        ParentId = null,
                        Slug = "vga-card-man-hinh",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Monitor - Màn hình",
                        ParentId = null,
                        Slug = "monitor-man-hinh",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Case - vỏ máy tính",
                        ParentId = null,
                        Slug = "case-vo-may-tinh",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "PSU - Nguồn",
                        ParentId = null,
                        Slug = "psu-nguon",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Sound Card",
                        ParentId = null,
                        Slug = "sound-card",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "ODD - Ổ đĩa quang",
                        ParentId = null,
                        Slug = "odd-o-dia-quang",
                        Children = null
                    },
                }
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Máy chủ & Máy trạm",
                ParentId = null,
                Slug = "may-chu-may-tram",
                Children = null
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Gaming Gear & Console",
                ParentId = null,
                Slug = "gaming-gear-va-console",
                Children = new List<CategoryViewModel>
                {
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Bàn phím chơi game",
                        ParentId = null,
                        Slug = "ban-phim-choi-game",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Chuột chơi game",
                        ParentId = null,
                        Slug = "chuot-choi-game",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Ghế chơi game",
                        ParentId = null,
                        Slug = "ghe-choi-game",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Bàn gaming",
                        ParentId = null,
                        Slug = "ban-gaming",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Tai nghe chơi game",
                        ParentId = null,
                        Slug = "tai-nghe-choi-game",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Tay cầm game",
                        ParentId = null,
                        Slug = "tay-cam-game",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Bàn di chuột",
                        ParentId = null,
                        Slug = "ban-di-chuot",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Máy chơi game console",
                        ParentId = null,
                        Slug = "may-choi-game-console",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Kính thực tế ảo",
                        ParentId = null,
                        Slug = "kinh-thuc-te-ao",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Game bản quyền",
                        ParentId = null,
                        Slug = "game-ban-quyen",
                        Children = null
                    },
                    new() {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Loa",
                        ParentId = null,
                        Slug = "loa",
                        Children = null
                    },
                }
            },
            new() {
                Id = Guid.NewGuid().ToString(),
                Name = "Giải pháp tản nhiệt",
                ParentId = null,
                Slug = "giai-phap-tan-nhiet",
                Children = null
            },
        };
        ViewBag.Categories = categories;
        return View();
    }
}
