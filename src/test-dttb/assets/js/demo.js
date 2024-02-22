// const PAGE_URL = "/danh-muc/";
let categoryTable;

$(function () {
  loadTableData();
});

function reloadData() {
  $("#category-table")
    .DataTable()
    .ajax.reload(() => {
      categoryTable.page(0).draw("page");
    }, true);
}

function loadTableData() {
  categoryTable = $("#category-table").MainTables({
    ajax: {
      url: "https://localhost:7041/api/category/get-category-paging",
      type: "POST",
      data: function (d) {
        let filter = {};
        let nameSearch = $("#NameSearch").val();
        let status = $("#StatusSearch").val();

        if (nameSearch) {
          filter.Name = nameSearch;
        }

        if (status) {
          filter.Status = status;
        }

        d.filter = filter;
      },
    },
    column: [
      {
        data: "Name",
        className: "text-center",
      },
      {
        data: "Slug",
        className: "text-center",
      },
      {
        data: "Image",
        className: "text-center",
      },
      {
        data: "IsActived",
        className: "text-center",
      },
      {
        data: "IsDeleted",
        className: "text-center",
      },
      {
        data: "Id",
        className: "text-center",
        //'render': function (data, type, row) {
        //    return data;
        //}
      },
    ],
  });
}
