(function (app) {
    app.controller('cauhoiListController', cauhoiListController);

    cauhoiListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function cauhoiListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.cauhoi = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = search;
        $scope.getCauhoi = getCauhoi;
        $scope.deleteCauhoi = deleteCauhoi;
        $scope.selectAll = selectAll;
        $scope.isAll = false;
        $scope.deleteMultiple = deleteMultiple;

        function deleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            $ngBootbox.confirm('Bạn có chắc muốn xóa ' + listId.length + ' bản ghi không?').then(function () {
                var config = {
                    params: {
                        checkedCauhoi: JSON.stringify(listId)
                    }
                }
                apiService.del('/api/chude/deleteMultiple', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.cauhoi, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.cauhoi, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("cauhoi", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function deleteCauhoi(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/cauhoi/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }

        function search() {
            getCauhoi();
        }

        function getCauhoi(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/cauhoi/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
                } else {
                    if ($scope.keyword != '') {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi')
                    }
                }
                $scope.cauhoi = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.TotalCount = result.data.TotalCount;
            }, function () {
                console.log('Load chu de failed.');
            });
        }
        $scope.getCauhoi();
    };
})(angular.module('luyenthi.chude'));