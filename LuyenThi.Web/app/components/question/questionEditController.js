(function (app) {
    app.controller('questionEditController', questionUpdateController);

    questionUpdateController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function questionUpdateController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.listAnswer = new Array();
        $scope.newAnswers = NewAnswer;
        $scope.deleteAnswer = DeleteteAnswer;
        $scope.editQuestion = UpdateQuestion;
        $scope.getAllTopic = GetAllTopic;
        function UpdateQuestion() {
            $scope.question.strJsonDapan = JSON.stringify($scope.listDapan);
            apiService.put('api/question/update', $scope.question, function (result) {
                notificationService.displaySuccess('Cập nhật thành công!');
                $state.go('question');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công: ' + error.data);
            })
        }

        function LoadQuestionDetail() {
            apiService.get('api/question/getbyid/' + $stateParams.id, null, function (result) {
                $scope.question = result.data;
                apiService.get('api/answer/getbyquestion/' + $scope.question.ID, null, function (result) {
                    $scope.listAnswer = result.data;
                }, function (error) {
                    notificationService.displayError(error.data);
                });
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function LoadAnswer(questionID) {
            apiService.get('api/dapan/getbyquestion/' + questionID, null, function (result) {
                $scope.listAnswer = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function NewAnswer() {
            var newAnswer = new Object();
            newAnswer.Content = "";
            newAnswer.TrueAnswer = false;
            listDapan.push(newAnswer);
            GetAnswerCode();

        }

        function DeleteAnswer(input) {
            const index = $scope.listAnswer.indexOf(input);
            $scope.listAnswer.splice(index, 1);
            GetAnswerCode();
        }

        function GetAnswerCode() {
            for (var i = 0; i < $scope.listAnswer.length; i++) {
                $scope.listAnswer[i].Code = commonService.getAnswerCode(i);
                $scope.listAnswer[i].Order = i + 1;
            }
        }
        function GetAllTopic() {
            apiService.get('/api/topic/getallparents', null, function (result) {
                $scope.Topics = result.data;
            }, function (error) {
                console.log('Can not load Topic');
            });
        }
        // CKFinder - ảnh
        $scope.ChoseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.question.Image = fileUrl;
            }
            finder.popup();
        }
        //CKEditor - trình soạn thảo
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px',
        }
        $scope.sortableOptions = {
            stop: function (e, ui) {
                GetAnswerCode();
            }
        };
        $scope.question = {
            ID: 0,
            Ngaytao: new Date(),
            Nguoitao: "Admin",
            Trangthai: true
        }
        LoadQuestionDetail();
    }
})(angular.module('luyenthi.question'));