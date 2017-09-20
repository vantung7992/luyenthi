(function (app) {
    app.controller('TopicListController', TopicListController);

    TopicListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function TopicListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.topics = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.search = Search;
        $scope.getTopic = GetTopic;
        $scope.deleteTopic = DeleteTopic;
        $scope.selectAll = SelectAll;
        $scope.isAll = false;
        $scope.deleteMultiple = DeleteMultiple;

        function DeleteMultiple() {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            $ngBootbox.confirm('Bạn có chắc muốn xóa ' + listId.length + ' bản ghi không?').then(function () {
                var config = {
                    params: {
                        checkedtopic: JSON.stringify(listId)
                    }
                }
                apiService.del('/api/topic/deleteMultiple', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                    Search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }

        function SelectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.topics, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.topics, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("topics", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        function DeleteTopic(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/topic/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    Search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                });
            });
        }

        function Search() {
            GetTopic();
        }

        function GetTopic(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/topic/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
                } else {
                    if ($scope.keyword != '') {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi')
                    }
                }
                $scope.topics = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.TotalCount = result.data.TotalCount;
            }, function () {
                console.log('Load chu de failed.');
            });
        }
        $scope.getTopic();
    };
})(angular.module('luyenthi.topic'));