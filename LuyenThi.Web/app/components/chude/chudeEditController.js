(function (app) {
    app.controller('chudeEditController', chudeUpdateController);

    chudeUpdateController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];

    function chudeUpdateController(apiService, $scope, notificationService, $state, $stateParams,commonService) {
        $scope.chude = {
            Ngaytao: new Date(),
            Trangthai: true
        }

        $scope.UpdateChude = UpdateChude;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.chude.Seo = commonService.getSeoTitle($scope.chude.Ten);
        }

        function loadChudeDetail() {
            apiService.get('api/chude/getbyid/' + $stateParams.id, null, function (result) {
                $scope.chude = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            })
        }

        function UpdateChude() {
            apiService.put('/api/chude/update', $scope.chude, function (result) {
                notificationService.displaySuccess(result.data.Ten + ' đã được cập nhật.');
                $state.go('chude');
            },
                function (error) {
                    notificationService.displayError('Cập nhật không thành công: ' + error);
                });
        }

        function loadChudeCha() {
            apiService.get('/api/chude/getallparents', null, function (result) {
                $scope.chudecha = result.data;
            }, function () {
                console.log('Cannot get list parent');
            })
        }

        loadChudeCha();
        loadChudeDetail();
    }

})(angular.module('luyenthi.chude'));