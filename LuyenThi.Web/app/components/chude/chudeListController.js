(function (app) {
    app.controller('chudeListController', chudeListController);

    chudeListController.$inject = ['$scope', 'apiService', 'notificationService'];

    function chudeListController($scope, apiService, notificationService) {
        $scope.chude = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        $scope.getChude = getChude;

        function search() {
            getChude();
        }

        function getChude(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/chude/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
                } else{
                    if ($scope.keyword!='') {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi')
                    }
                }
                $scope.chude = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.TotalCount = result.data.TotalCount;
            }, function () {
                console.log('Load chu de failed.');
            });
        }
        $scope.getChude();
    };
})(angular.module('luyenthi.chude'));