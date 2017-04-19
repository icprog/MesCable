var materialTable = {};

(function (mt) {

    //找到选中的序号传入的是$(tr)
    mt.findInputChecked = function ($tr) {
        var checkResult = $tr.find("div").map(function (i) {
            if ($(this).hasClass("checked")) {

                return i
            }
        }).get(0);
        if (checkResult == null) {
            checkResult = -1;
        }
        return checkResult;
    }


})(materialTable)