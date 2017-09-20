(function (app) {
    app.controller('topicAddController', topicAddController);

    topicAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function topicAddController(apiService, $scope, notificationService, $state,commonService) {
        $scope.topic = {
            Ngaytao: new Date(),
            Trangthai: true
        }

        $scope.AddTopic = AddTopic;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.topic.Seo = commonService.getSeoTitle($scope.topic.Ten);
        }

        function AddTopic() {
            apiService.post('/api/topic/create', $scope.topic, function (result) {
                notificationService.displaySuccess(result.data.Ten + ' đã được thêm mới.');
                $state.go('topic');
            },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công: ' + error);
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
    }

})(angular.module('luyenthi.topic'));