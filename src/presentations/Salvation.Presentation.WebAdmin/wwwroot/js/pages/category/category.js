//const PAGE_URL = '/danh-muc/';
//let categoryTable;

//$(function () {
//    loadTableData();
//})

//function reloadData() {
//    $("#category-table").DataTable().ajax.reload(() => {
//        categoryTable.page(0).draw('page');
//    }, true);
//}

//function loadTableData() {
//    categoryTable = $("#category-table").MainTables({
//        'ajax': {
//            'url': PAGE_URL + 'get-data',
//            'type': 'POST',
//            'data': function (d) {
//                let filter = {};
//                let nameSearch = $("#NameSearch").val();
//                let status = $("#StatusSearch").val();

//                if (nameSearch) {
//                    filter.Name = nameSearch;
//                }

//                if (status) {
//                    filter.Status = status
//                }

//                d.filter = filter;
//            }
//        },
//        'column': [
//            {
//                'data': 'Name',
//                'className': 'text-center'
//            },
//            {
//                'data': 'Slug',
//                'className': 'text-center'
//            },
//            {
//                'data': 'Image',
//                'className': 'text-center'
//            },
//            {
//                'data': 'IsActived',
//                'className': 'text-center'
//            },
//            {
//                'data': 'IsDeleted',
//                'className': 'text-center'
//            },
//            {
//                'data': 'Id',
//                'className': 'text-center',
//                //'render': function (data, type, row) {
//                //    return data;
//                //}
//            }
//        ]
//    });
//}

async function Create() {
    let Name = $("#Name").val();
    let Slug = $("#Slug").val();
    let Image = $("#Image").val();
    let ParentId = $("#ParentId").val();
    let IsActived = $("#IsActived").val();
    let IsDeleted = !IsActived;

    const category = { Name, Slug, Image, ParentId, IsActived, IsDeleted }

    const res = await AjaxProvider.Post({
        url: "/danh-muc/tao-moi",
        data: category
    });

    if (res.code < 0) {
        Swal.fire({
            title: "Lỗi",
            text: "Thêm mới thất bại! Vui lòng kiểm tra lại!",
            icon: "error",
        });
        return;
    } else {
        Swal.fire({
            title: "Thông báo",
            html: "Thêm mới thành công!",
            icon: "success"
        }).then(() => {
            window.location.href = '/danh-muc';
        });
    }
}

function GenerateSlug() {
    let Name = $("#Name").val();
    $("#Slug").val(stringToSlug(Name));
}

async function Update(Id) {
    let Name = $("#Name").val();
    let Slug = $("#Slug").val();
    let Image = $("#Image").val();
    let ParentId = $("#ParentId").val();
    let IsActived = $("#IsActived").val();
    let IsDeleted = !IsActived;

    const category = { Id, Name, Slug, Image, ParentId, IsActived, IsDeleted }

    const res = await AjaxProvider.Post({
        url: "/danh-muc/cap-nhat",
        data: category
    });

    if (res.code < 0) {
        Swal.fire({
            title: "Lỗi",
            text: "Cập nhật thất bại! Vui lòng kiểm tra lại!",
            icon: "error",
        });
        return;
    } else {
        Swal.fire({
            title: "Thông báo",
            html: "Cập nhật thành công!",
            icon: "success"
        }).then(() => {
            window.location.href = '/danh-muc';
        });
    }
}

async function Active(Id, status) {
    const category = { Id, IsActived: status }

    const res = await AjaxProvider.Post({
        url: "/danh-muc/cap-nhat-trang-thai",
        data: category
    });

    if (res.code < 0) {
        Swal.fire({
            title: "Lỗi",
            text: "Cập nhật thất bại! Vui lòng kiểm tra lại!",
            icon: "error",
        });
        return;
    } else {
        Swal.fire({
            title: "Thông báo",
            html: "Cập nhật thành công!",
            icon: "success"
        }).then(function () {
            location.reload()
        });
    }
}

async function Delete(Id) {
    const res = await AjaxProvider.Get({
        url: "/danh-muc/xoa-danh-muc/" + Id
    });

    if (res.code < 0) {
        Swal.fire({
            title: "Lỗi",
            text: "Xoá thất bại! Vui lòng kiểm tra lại!",
            icon: "error",
        });
        return;
    } else {
        Swal.fire({
            title: "Thông báo",
            html: "Xoá thành công!",
            icon: "success"
        }).then(function () {
            location.reload()
        });
    }
}

function ShowImage() {
    let Image = $("#Image").val();
    $("#ImageShow").attr("src", Image)
}

function stringToSlug(str) {
    // Chuyển hết sang chữ thường
    str = str.toLowerCase();

    // xóa dấu
    str = str
        .normalize('NFD') // chuyển chuỗi sang unicode tổ hợp
        .replace(/[\u0300-\u036f]/g, ''); // xóa các ký tự dấu sau khi tách tổ hợp

    // Thay ký tự đĐ
    str = str.replace(/[đĐ]/g, 'd');

    // Xóa ký tự đặc biệt
    str = str.replace(/([^0-9a-z-\s])/g, '');

    // Xóa khoảng trắng thay bằng ký tự -
    str = str.replace(/(\s+)/g, '-');

    // Xóa ký tự - liên tiếp
    str = str.replace(/-+/g, '-');

    // xóa phần dư - ở đầu & cuối
    str = str.replace(/^-+|-+$/g, '');

    // return
    return str;
}