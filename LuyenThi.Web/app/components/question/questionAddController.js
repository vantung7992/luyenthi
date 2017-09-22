(function (app) {
    app.controller('questionAddController', questionAddController);

    questionAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function questionAddController(apiService, $scope, notificationService, $state, commonService) {
        $scope.question = {
            CreatedDate: new Date(),
            CreatedBy: "Tungnv",
            Status: true
        }
        $scope.addQuestion = AddQuestion;
        $scope.listAnswer = new Array();
        $scope.newAnswer = NewAnswer;
        $scope.deleteAnswer = DeleteAnswer;
        $scope.getAllTopic = GetAllTopic;
        function AddQuestion() {
            document.getElementById('content').innerHTML = CKEDITOR.instances['displayContent'].getData();
            $scope.question.Content = document.getElementById('content').innerText;
            $scope.question.StringJsonAnswer = JSON.stringify($scope.listAnswer);
            apiService.post('/api/question/create', $scope.question, function (result) {
                notificationService.displaySuccess('Thêm mới thành công');
                $state.go('question');
            },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công: ' + error);
                });
        }
        function NewAnswer() {
            var newAnswer = new Object();
            newAnswer.Content = "";
            newAnswer.TrueAnswer = false;
            $scope.listAnswer.push(newAnswer);
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
        //Mặc định có 4 đáp án
        for (var i = 0; i < 4; i++) {
            NewAnswer();
        }
        $scope.sortableOptions = {
            stop: function (e, ui) {
                GetAnswerCode();
            }
        };
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px',
        }
        // CKFinder - ảnh
        $scope.ChoseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.question.Image = fileUrl;
            }
            finder.popup();
        }
        $scope.getAllTopic();
    }
})(angular.module('luyenthi.question'));