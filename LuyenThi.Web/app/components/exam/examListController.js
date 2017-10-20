(function (app) {
    app.controller('examListController', examListController);

    examListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function examListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.listExam = [];
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.keyword = '';
        $scope.search = Search;
        $scope.getExam = GetExam;
        $scope.deleteExam = DeleteExam;
        $scope.deleteMultiple = DeleteMultiple;
        $scope.selectAll = SelectAll;
        $scope.isAll = false;

        function GetExam(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/exam/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displaySuccess('Không tìm thấy đề thi nào');
                } else {
                    if ($scope.keyword != '') {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' đề thi');
                    }
                }

                $scope.listExam = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.TotalCount = result.data.TotalCount;
            }, function (error) {
                notificationService.displayError('Gặp lỗi khi tải danh sách đề thi: ' + error.data);
            });
        }

        function Search() {
            GetExam();
        }

        function DeleteExam(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa ?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                };
                apiService.del('/api/exam/delete', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công đề thi mã: ' + result.data.ID);
                    Search();
                }, function (error) {
                    notificationService.displayError('Xóa không thành công: ' + error.data);
                });
            });
        }

        function SelectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.listExam, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.listExam, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        function DeleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            $ngBootbox.confirm('Bạn có chắc muốn xóa ' + listId.length + ' bản ghi không?').then(function () {
                var config = {
                    params: {
                        checkedQuestion: JSON.stringify(listId)
                    }
                }
                apiService.del('/api/exam/deleteMultiple', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                    Search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        $scope.$watch("listExam", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);
        $scope.getExam();
    }
}
)(angular.module('luyenthi.exam'));