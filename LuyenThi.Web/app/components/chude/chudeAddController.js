(function (app) {
    app.controller('chudeAddController', chudeAddController);

    chudeAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function chudeAddController(apiService, $scope, notificationService, $state,commonService) {
        $scope.chude = {
            Ngaytao: new Date(),
            Trangthai: true
        }

        $scope.AddChude = AddChude;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.chude.Seo = commonService.getSeoTitle($scope.chude.Ten);
        }

        function AddChude() {
            apiService.post('/api/chude/create', $scope.chude, function (result) {
                notificationService.displaySuccess(result.data.Ten + ' đã được thêm mới.');
                $state.go('chude');
            },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công: ' + error);
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
    }

})(angular.module('luyenthi.chude'));