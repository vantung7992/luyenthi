(function (app) {
    app.controller('cauhoiAddController', cauhoiAddController);

    cauhoiAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function cauhoiAddController(apiService, $scope, notificationService, $state, commonService) {
        var listDapan = new Array();
        $scope.ThemDapan = ThemDapan
        $scope.XoaDapan = XoaDapan
        function ThemDapan() {
            var dapan = new Object();
            dapan.Noidung = "";
            dapan.Dungsai = false;
            listDapan.push(dapan);
            LayMaDapan();
            $scope.dapans = listDapan;
        }
        function XoaDapan(input) {
            const index = listDapan.indexOf(input);
            listDapan.splice(index, 1);
            LayMaDapan();
        }

        $scope.sortableOptions = {
            stop: function (e, ui) {
                LayMaDapan();
            }
        };

        function LayMaDapan() {
            for (var i = 0; i < listDapan.length; i++) {
                listDapan[i].Ma = commonService.getMaDapan(i);
            }
        }

        $scope.cauhoi = {
            Ngaytao: new Date(),
            Trangthai: true
        }
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px',
        }

        $scope.AddCauhoi = AddCauhoi;
        function AddCauhoi() {
            apiService.post('/api/cauhoi/create', $scope.cauhoi, function (result) {
                notificationService.displaySuccess(result.data.Ten + ' đã được thêm mới.');
                $state.go('cauhoi');
            },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công: ' + error);
                });
        }

        $scope.ChoseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.cauhoi.Image = fileUrl;
            }
            finder.popup();
        }
    }

})(angular.module('luyenthi.cauhoi'));