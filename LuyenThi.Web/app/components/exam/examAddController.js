(function (app) {
    app.controller('examAddController', examAddController);
    examAddController.$inject = ['$scope', 'apiService', 'notificationService', '$ngBootbox', '$filter'];
    function examAddController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.exam = {
            CreatedDate: new Date(),
            CreatedBy: 'Admin',
            Status: true
        };

        $scope.addExam = AddExam;
        $scope.listCheckedQuestion = [];
        $scope.listUncheckedQuestion = [];
        $scope.Topics = [];

        function GetAllTopic() {
            apiService.get('/api/topic/getallparents', null, function (result) {
                $scope.Topics = result.data;
            }, function (error) {
                console.log('Can not load Topic');
            });
        }

        function AddExam() {
            apiService.post('/api/exam/create', $scope.exam, function (result) {
                notificationService.displaySuccess('Tạo đề thi thành công');
                $state.go('exam');
            }, function (error) {
                notificationService.displayError('Tạo đề thi không thành công: ' + error.data);
            })
        }

        function GetNoSelectQuestion(selectedQuestion) {
            var config = {
                params: {
                    selectedQuestion: selectedQuestion
                }
            };
            apiService.get('/api/question/getselectedquestion', config, function (result) {
                $scope.listUncheckedQuestion = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            })
        }
        $('#addQuestionModal').on('show.bs.modal', function (e) {
            // do something...
            var selectedQuestion = "";
            GetNoSelectQuestion(selectedQuestion);
        });


        GetAllTopic();
    }
}
)(angular.module('luyenthi.exam'));