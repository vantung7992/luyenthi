(function (app) {
    app.controller('examAddController', examAddController);
    examAddController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function examAddController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.exam = {
            CreatedDate: new Date(),
            CreatedBy: 'Admin',
            Status: true
        };

        $scope.keyword = '';
        $scope.isAllUnSelectQuestion = false;
        $scope.addExam = AddExam;
        $scope.listCheckedQuestion = [];
        $scope.listUncheckedQuestion = [];
        $scope.Topics = [];
        $scope.selectAllUnSelectQuestion = SelectAllUnSelectQuestion;
        $scope.changeTopic = ChangeTopic;
        $scope.search = Search;
        $scope.addSelectedQuestion = AddSelectedQuestion;
        $scope.removeSelectedQuestion = RemoveSelectedQuestion;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.exam.Seo = commonService.getSeoTitle($scope.exam.Name);
        }

        function GetAllTopic() {
            apiService.get('/api/topic/getallparents', null, function (result) {
                $scope.Topics = result.data;
            }, function (error) {
                console.log('Can not load Topic');
            });
        }

        function AddExam() {
            var listIDSelectedQuestion = '';
            var config = {
                params: {
                    exam: $scope.exam,
                    selectedQuestion:JSON.stringify(listIDSelectedQuestion)
                }
            }

            apiService.post('/api/exam/create', config, function (result) {
                notificationService.displaySuccess('Tạo đề thi thành công');
                $state.go('exam');
            }, function (error) {
                notificationService.displayError('Tạo đề thi không thành công: ' + error.data);
            })
        }

        function GetNoSelectQuestion(selectedQuestion) {
            var config = {
                params: {
                    selectedQuestion: selectedQuestion,
                    topicID: $scope.topicID,
                    keyword:$scope.keyword
                }
            };
            apiService.get('/api/question/getnoselectedquestion', config, function (result) {
                $scope.listUncheckedQuestion = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            })
        }

        function SelectAllUnSelectQuestion() {
            if ($scope.isAllUnSelectQuestion === false) {
                angular.forEach($scope.listUncheckedQuestion, function (item) {
                    item.checked = true;
                });
                $scope.isAllUnSelectQuestion = true;
            } else {
                angular.forEach($scope.listUncheckedQuestion, function (item) {
                    item.checked = false;
                });
                $scope.isAllUnSelectQuestion = false;
            }
        }

        function ChangeTopic() {
            GetNoSelectQuestion("");
        }

        function Search() {
            GetNoSelectQuestion("");
        }

        function AddSelectedQuestion() {
            var listSelectedQuestion = [];
            $.each($scope.selected, function (i, item) {
                const index = $scope.listCheckedQuestion.indexOf(item);
                if (index < 0) {
                    $scope.listCheckedQuestion.push(item);
                }
            });
        }
        function RemoveSelectedQuestion(question) {
            const index = $scope.listCheckedQuestion.indexOf(question);
            if (index>=0) {
                $scope.listCheckedQuestion.splice(index,1);
            }
        }

        $scope.$watch("listUncheckedQuestion", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $('#addQuestionModal').on('show.bs.modal', function (e) {
            // do something...
            var selectedQuestion = "";
            GetNoSelectQuestion(selectedQuestion);
        });

        GetAllTopic();
    }
}
)(angular.module('luyenthi.exam'));