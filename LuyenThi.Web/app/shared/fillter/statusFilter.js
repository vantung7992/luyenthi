(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true)
                return 'Kích hoạt';
            else
                return 'Khóa';
        }
    });
    app.filter('dapanDungsaiFilter', function () {
        return function (input) {
            if (input == true)
                return 'Đáp án đúng';
            else
                return 'Đáp án sai';
        }
    });
})(angular.module('luyenthi.common'));