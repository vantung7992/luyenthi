(function (app) {
    app.controller('chudeAddController', chudeAddController);

    chudeAddController.$inject = ['apiService','$scope'];

    function chudeAddController(apiService,$scope) {
        $scope.chude = {
            Ngaytao: new Date()
        }
        $scope.IDChudeCha = [];

        function loadChudeCha() {
            apiService.get('/api/chude/getallparents', null, function (result) {
                $scope.ChudeCha = result.data;
            }, function () {
                console.log('Cannot get list parent');
            })
        }
    };
})(angular.module('luyenthi.chude'));