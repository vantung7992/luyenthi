(function (app) {
    app.controller('dethiAddController', dethiAddController);
    dethiAddController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function dethiAddController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.dethi = {
            Ngaytao: new Date(),
            Nguoitao: 'Admin',
            Trangthai: true
        };
        $scope.addDethi = AddDethi;
        function AddDethi() {
            apiService.post('/api/dethi/create', $scope.dethi, function (result) {
                notificationService.displaySuccess('Tạo đề thi thành công');
                $state.go('dethi');
            }, function (error) {
                notificationService.displayError('Tạo đề thi không thành công: ' + error.data);
            })
        }
    }
}
)(angular.module('luyenthi.dethi'));