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
            $('#' + divId).html(result);
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
        $('#' + action).disabled;
        $.ajax({
            type: 'get',
            url: $('#' + action).data('url'),
            success: function (result) {
                var panel = $('#' + $('#' + action).data('display'));
                panel.html(result);
                cusvalidate(panel.find('form').attr('id'));
                ToolBarStateChange(false, true);
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
                cusvalidate(panel.find('form').attr('id'));
            },
            error: function () {
                alert("System Error!");
            }
        })
    }
};

function ToolBarStateChange(search, add, check, del, failed, attach) {
    $('#toolbar li').each(function () {
        $(this).find('.btn').removeAttr("disabled");
    });

    if (search != null) {
        $('#toolbar #Search').attr('disabled', search);
    }

    if (add != null) {
        $('#toolbar #Add').attr('disabled', add);
    }

    if (check != null) {
        $('#toolbar #Check').attr('disabled', check);
    }

    if (del != null) {
        $('#toolbar #Delete').attr('disabled', del);
    }

    if (failed != null) {
        $('#toolbar #Failed').attr('disabled', failed);
    }

    if (attach != null) {
        $('#toolbar #Attachment').attr('disabled', attach);
    }
}