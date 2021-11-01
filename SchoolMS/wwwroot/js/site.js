

$(document).ready(function () {
    $("#searchInput").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Attendances/SearchStudent',
                headers: {
                    "RequestVerificationToken":
                        $('input[name="__RequestVerificationToken"]').val()
                },
                data: { "term": request.term },
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (xhr, textStatus, error) {
                    alert(xhr.statusText);
                },
                failure: function (response) {
                    alert("failure " + response.responseText);
                }
            });
        },
        //select: function (e, i) {
        //    $("#lblVendorName").text(i.item.value);
        //},
        minLength: 2
    });
});

$(document).ready(function () {
    $("#searchCourse").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Attendances/SearchCourse',
                headers: {
                    "RequestVerificationToken":
                        $('input[name="__RequestVerificationToken"]').val()
                },
                data: { "term": request.term },
                dataType: "json",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (xhr, textStatus, error) {
                    alert(xhr.statusText);
                },
                failure: function (response) {
                    alert("failure " + response.responseText);
                }
            });
        },
        //select: function (e, i) {
        //    $("#lblVendorName").text(i.item.value);
        //},
        minLength: 2
    });
});