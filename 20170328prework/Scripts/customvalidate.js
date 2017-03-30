//引用本js前須先引用bootstrap validate的js

function cusvalidate(formid) {
    $('#'+formid).validator({
        custom: {
            equals: function ($el) {
                var ispass;

                var min = $el.data('cusmin');
                var max = $el.data('cusmax');

                if ($el.val().length < min || $el.val().length > max) {
                    ispass = false;
                }

                if (ispass == false) {

                    return '字串長度需小於' + min + '，大於' + max;

                }
            }
        }
    })
}