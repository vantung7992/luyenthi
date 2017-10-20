(function (app) {
    app.controller('topicEditController', topicUpdateController);

    topicUpdateController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService'];

    function topicUpdateController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.UpdateTopic = UpdateTopic;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.topic.Seo = commonService.getSeoTitle($scope.topic.Name);
        }

        function loadTopicDetail() {
            apiService.get('/api/topic/getbyid/' + $stateParams.id, null, function (result) {
                $scope.topic = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            })
        }

        function UpdateTopic() {
            apiService.put('/api/topic/update', $scope.topic, function (result) {
                notificationService.displaySuccess(result.data.Namess + ' đã được cập nhật.');
                $state.go('topic');
            },
                function (error) {
                    notificationService.displayError('Cập nhật không thành công: ' + error);
                });
        }

        function loadTopicParent() {
            apiService.get('/api/topic/getallparents', $stateParams.id, function (result) {
                $scope.topicParents = result.data;
            }, function () {
                console.log('Cannot get list parent');
            })
        }

        // CKEditer - Trình soạn thảo
        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px',
        }
        // CKFinder - ảnh
        $scope.ChoseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.topic.Image = fileUrl;
            }
            finder.popup();
        }
        loadTopicDetail();
        loadTopicParent();

    }

})(angular.module('luyenthi.topic'));