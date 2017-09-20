(function (app) {
    app.controller('cauhoiEditController', cauhoiUpdateController);

    cauhoiUpdateController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function cauhoiUpdateController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        // CKFinder - ảnh
        $scope.ChoseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.cauhoi.Image = fileUrl;
            }
            finder.popup();
        }
        //CKEditor - trình soạn thảo
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px',
        }
        $scope.sortableOptions = {
            stop: function (e, ui) {
                LayMaDapan();
            }
        };
        $scope.cauhoi = {
            ID: 0,
            Ngaytao: new Date(),
            Nguoitao: "Admin",
            Trangthai: true
        }
        var listDapan = new Array();
        $scope.listDapan = listDapan;
        $scope.ThemDapan = ThemDapan
        $scope.XoaDapan = XoaDapan
        $scope.EditCauhoi = UpdateCauhoi

        function UpdateCauhoi() {
            $scope.cauhoi.strJsonDapan = JSON.stringify($scope.listDapan);
            apiService.put('api/cauhoi/update', $scope.cauhoi, function (result) {
                notificationService.displaySuccess('Cập nhật câu hỏi thành công');
                $state.go('cauhoi');
            }, function (error) {
                notificationService.displayError('Cập nhật câu hỏi không thành công ' + error.data);
            })
        }

        function LoadCauhoiDetail() {
            apiService.get('api/cauhoi/getbyid/' + $stateParams.id, null, function (result) {
                $scope.cauhoi = result.data;
                apiService.get('api/dapan/getbycauhoi/' + $scope.cauhoi.ID, null, function (result) {
                    listDapan = result.data;
                    $scope.listDapan = listDapan;
                }, function (error) {
                    notificationService.displayError(error.dapan);
                });
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function LoadDapan(idCauhoi) {
            apiService.get('api/dapan/getbycauhoi/' + idCauhoi, null, function (result) {
                $scope.listDapan = result.data;
            }, function (error) {
                notificationService.displayError(error.dapan);
            });
        }

        //Đáp án
        function ThemDapan() {
            var dapan = new Object();
            dapan.Noidung = "";
            dapan.Dungsai = false;
            listDapan.push(dapan);
            LayMaDapan();

        }

        function XoaDapan(input) {
            const index = listDapan.indexOf(input);
            listDapan.splice(index, 1);
            LayMaDapan();
        }

        function LayMaDapan() {
            for (var i = 0; i < listDapan.length; i++) {
                listDapan[i].Ma = commonService.getMaDapan(i);
                listDapan[i].Thutu = i + 1;
            }
        }


        LoadCauhoiDetail();
    }
})(angular.module('luyenthi.cauhoi'));