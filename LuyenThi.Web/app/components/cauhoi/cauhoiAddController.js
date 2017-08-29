(function (app) {
    app.controller('cauhoiAddController', cauhoiAddController);

    cauhoiAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function cauhoiAddController(apiService, $scope, notificationService, $state, commonService) {
        var listDapan = new Array();
        $scope.ThemDapan = ThemDapan
        $scope.XoaDapan = XoaDapan
        $scope.cauhoi = {
            Ngaytao: new Date(),
            Trangthai: true,
            Tag: "Cauhoi1",
            Noidung: "abc",
            Ngaysua: new Date(),
            Nguoitao: "abc",
            Nguoisua: "abc",
            Ghichu: "abc",
            Image: "ac",
            Goiy: "abc"
        }
        $scope.AddCauhoi = AddCauhoi;
        function AddCauhoi() {
            var text = CKEDITOR.instances['noidung'].getData();
            document.getElementById('displayHtml').innerHTML = text;
            var str = document.getElementById('displayHtml').innerText;
            alert(str);
            return;
            $scope.cauhoi.strJsonDapan = JSON.stringify($scope.dapans);
            apiService.post('/api/cauhoi/create', $scope.cauhoi, function (result) {
                notificationService.displaySuccess('Thêm mới thành công');
                $state.go('cauhoi');
            },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công: ' + error);
                });
        }

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
        for (var i = 0; i < 4; i++) {
            ThemDapan();
        }

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px',
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