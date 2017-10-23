(function (app) {
    app.controller('questionListController', questionListController);

    questionListController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];

    function questionListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.questions = [];
        $scope.Topics = {
            toppic: { ID: -1, Name: "Tất cả chủ đề" }
        };
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.keyword = '';
        $scope.isAll = false;
        $scope.search = Search;
        $scope.getQuestion = GetQuestion;
        $scope.deleteQuestion = DeleteQuestion;
        $scope.deleteMultiple = DeleteMultiple;
        $scope.selectAll = SelectAll;
        $scope.getAllTopic = GetAllTopic;
        $scope.changeTopic = ChangeTopic;
        $scope.topicID = -1;
        function GetAllTopic() {
            apiService.get('/api/topic/getallparents', null, function (result) {
                $scope.Topics = result.data;
            }, function (error) {
                console.log('Can not load Topic');
            });
        }
        function Search() {
            GetQuestion();
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
                apiService.del('/api/question/deleteMultiple', config, function (result) {
                    notificationService.displaySuccess('Xóa thành công ' + result.data + ' bản ghi');
                    Search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        function DeleteQuestion(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa câu hỏi này?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('/api/question/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công!');
                    Search();
                }, function () {
                    notificationService.displayError('Xóa không thành công!');
                });
            });
        }
        function GetQuestion(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    topicID: $scope.topicID,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/question/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy');
                } else {
                    if ($scope.keyword != '') {
                        notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi')
                    }
                }
                $scope.questions = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.TotalCount = result.data.TotalCount;
            }, function () {
                console.log('Load question failed.');
            });
        }
        function SelectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.questions, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.questions, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        function ChangeTopic() {
            Search();
        }
        $scope.$watch("questions", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);
        $scope.getAllTopic();
    };
})(angular.module('luyenthi.question'));