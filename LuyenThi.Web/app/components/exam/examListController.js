(function (app) {
    app.controller('dethiListController', dethiListController);

    dethiListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function dethiListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.listDethi = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.keyword = '';
        $scope.search = Search;
        $scope.getDethi = GetDethi;
        $scope.deleteDethi = DeleteDethi;
        //$scope.deleteMultipleCauhoi = DeleteMultipleCauhoi;
        //$scope.selectAll = SelectAll;
        $scope.isAll = false;

        function GetDethi(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/dethi/getall', config, function (result) {
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
            GetDethi();
        }

        function DeleteDethi(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa ?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                apiService.del('/api/dethi/delete', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công đề thi mã: ' + result.data.ID);
                    Search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công: ' + error.data);
                });
            });
        }

        $scope.getDethi();
    }
}
)(angular.module('luyenthi.dethi'));