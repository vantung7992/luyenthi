(function (app) {
    app.controller('topicEditController', topicUpdateController);

    topicUpdateController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];

    function topicUpdateController(apiService, $scope, notificationService, $state, $stateParams,commonService) {
        $scope.topic = {
            Ngaytao: new Date(),
            Trangthai: true
        }

        $scope.UpdateTopic = UpdateTopic;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.topic.Seo = commonService.getSeoTitle($scope.topic.Ten);
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
                notificationService.displaySuccess(result.data.Ten + ' đã được cập nhật.');
                $state.go('topic');
            },
                function (error) {
                    notificationService.displayError('Cập nhật không thành công: ' + error);
                });
        }

        function loadTopicCha() {
            apiService.get('/api/topic/getallparents', null, function (result) {
                $scope.topiccha = result.data;
            }, function () {
                console.log('Cannot get list parent');
            })
        }

        loadTopicCha();
        loadTopicDetail();
    }

})(angular.module('luyenthi.topic'));