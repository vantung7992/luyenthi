(function (app) {
    app.controller('dethiListController', dethiListController);

    dethiListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function dethiListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.listDethi = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.keyword = '';
        $scope.search = Search;
        $scope.getCauhoi = GetCauhoi;
        //$scope.deleteCauhoi = DeleteCauhoi;
        //$scope.deleteMultipleCauhoi = DeleteMultipleCauhoi;
        //$scope.selectAll = SelectAll;
        $scope.isAll = false;

        function GetCauhoi(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('api/dethi/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displaySuccess('Không tìm thấy đề thi nào');
                } else {
                    if ($scope.keyword != '') {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' đề thi');
                    }
                }

                $scope.listDethi = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.TotalCount = result.data.TotalCount;
            }, function (error) {
                notificationService.displayError('Gặp lỗi khi tải danh sách đề thi: ' + error.data);
            });
        }

        function Search() {
            GetCauhoi();
        }

        $scope.getCauhoi();

    }
}
)(angular.module('luyenthi.dethi'));