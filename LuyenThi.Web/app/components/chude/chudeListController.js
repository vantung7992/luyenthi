(function (app) {
    app.controller('chudeListController', chudeListController);
    chudeListController.$inject = ['$scope', 'apiService'];

    function chudeListController($scope, apiService) {
        $scope.chude = [];
        $scope.getChude = getChude;

        function getChude() {
            apiService.get('/api/chude/getall', null, function (result) {
                $scope.chude = result.data;
            }, function () {
                console.log('Load chu de failed.');
            });
        }
        $scope.getChude();
    };
})(angular.module('luyenthi.chude'));