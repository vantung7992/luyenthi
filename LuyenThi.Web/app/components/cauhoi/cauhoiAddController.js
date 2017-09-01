(function (app) {
    app.controller('cauhoiAddController', cauhoiAddController);

    cauhoiAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function cauhoiAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.cauhoi = {
            Ngaytao: new Date(),
            Nguoitao: "Admin",
            Trangthai: true
        }
        $scope.AddCauhoi = AddCauhoi;
        function AddCauhoi() {
            document.getElementById('noidung').innerHTML = CKEDITOR.instances['noidunghienthi'].getData();
            $scope.cauhoi.Noidung = document.getElementById('noidung').innerText;
            $scope.cauhoi.strJsonDapan = JSON.stringify($scope.listDapan);
            apiService.post('/api/cauhoi/create', $scope.cauhoi, function (result) {
                notificationService.displaySuccess('Thêm mới thành công');
                $state.go('cauhoi');
            },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công: ' + error);
                });
        }
        //Đáp án
        var listDapan = new Array();
        $scope.listDapan = listDapan;
        $scope.ThemDapan = ThemDapan
        function ThemDapan() {
            var dapan = new Object();
            dapan.Noidung = "";
            dapan.Dungsai = false;
            listDapan.push(dapan);
            LayMaDapan();

        }
        $scope.XoaDapan = XoaDapan
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
                listDapan[i].Thutu = i + 1;
            }
        }

        //Mặc định có 4 đáp án
        for (var i = 0; i < 4; i++) {
            ThemDapan();
        }

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px',
        }
        // CKFinder - ảnh
        $scope.ChoseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.cauhoi.Image = fileUrl;
            }
            finder.popup();
        }
    }
})(angular.module('luyenthi.cauhoi'));