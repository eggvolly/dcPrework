function InitToolBar(divId, conName) {
    if (conName == '' || typeof (conName) == undefined) {
        return;
    }

    $.ajax({
        type: 'post',
        url: $('#toolpath').val(),
        data: {
            controllerName: conName
        },
        success: function (result) {
            $('#' + divId).append(result);
        },
        error: function () {
            alert("System Error!")
        }
    })
};

function ToolBtnClick(action) {
    if (action == '' || typeof (action) == undefined) {
        return;
    }
    if (action == 'Add') {
        $.ajax({
            type: 'get',
            url: $('#' + action).data('url'),
            success: function (result) {
                var panel = $('#' + $('#' + action).data('display'));
                panel.html(result);
            },
            error: function () {
                alert("System Error!");
            }
        })
    }
    else if (action == 'Search') {
        $.ajax({
            type: 'get',
            url: $('#' + action).data('url'),
            success: function (result) {
                var panel = $('#' + $('#' + action).data('display'));
                panel.html(result);
                $('#myModal').modal({
                    keyboard: false,
                    backdrop: false
                }, 'show');
            },
            error: function () {
                alert("System Error!");
            }
        })
    }
};