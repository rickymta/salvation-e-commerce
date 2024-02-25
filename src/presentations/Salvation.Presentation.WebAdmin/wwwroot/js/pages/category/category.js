let CategoryId = null;

$(function () {
    //$('#Image').change(function () {
    //    const file = this.files[0];
    //    if (file) {
    //        const reader = new FileReader();
    //        reader.onload = function (e) {
    //            $('#ImageShow').attr('src', e.target.result);
    //        }
    //        reader.readAsDataURL(file);
    //    }
    //});

    $(".page-link").click(function (e) {
        e.preventDefault();
        let page = $(this).data("page");
        let limit = $("#perpage").val();
        console.log(page, limit);
        window.location.href = `/danh-muc/${page}/${limit}`
    })
})

async function Create() {
    let Name = $("#Name").val()
    let Slug = $("#Slug").val()
    let Image = $("#Image").val()
    let ParentId = $("#ParentId").val()
    let IsActived = $("#IsActived").val()
    let IsDeleted = !IsActived

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

async function Edit(Id) {
    ClearModal();
    CategoryId = Id;

    const res = await AjaxProvider.Get({
        url: "/danh-muc/chi-tiet/" + Id,
    });

    if (res.code == 0) {
        $("#Name").val(res.data.name)
        $("#Slug").val(res.data.slug)
        $("#Image").val(res.data.image)
        $("#ImageShow").attr("src", res.data.image)
        $("#ParentId").val(res.data.parentId)
        $("#IsActived").val(res.data.isActived + "")
    }
}

function ClearModal() {
    CategoryId = null;
    $("#Name").val("")
    $("#Slug").val("")
    $("#Image").val("")
    $("#ImageShow").attr("src", "")
    $("#ParentId").val("")
    $("#IsActived").val("")
}

function CreateOrUpdate() {
    if (CategoryId != null) {
        Update(CategoryId)
    } else {
        Create()
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
    if (Image != "") {
        $("#ImageShow").attr("src", Image)
    }
}

function UploadImage() {
    var fileInput = document.getElementById('Image');
    var file = fileInput.files[0];
    var base64String = ""

    if (file) {
        console.log(file)
        var reader = new FileReader();
        reader.onload = async function (event) {
            base64String = event.target.result.split(',')[1];

            const res = await AjaxProvider.Post({
                url: "/danh-muc/tai-file",
                data: { FileString: base64String, FileName: file.name, FileSize: file.size, FileType: file.type }
            });

            if (res.code < 0) {
                Swal.fire({
                    title: "Lỗi",
                    text: "Tải file thất bại! Vui lòng kiểm tra lại!",
                    icon: "error",
                });
                return;
            }
        };
        reader.readAsDataURL(file);
    } else {
        console.log('No file selected.');
    }
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