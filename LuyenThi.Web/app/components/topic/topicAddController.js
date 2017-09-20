(function (app) {
    app.controller('topicAddController', topicAddController);

    topicAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function topicAddController(apiService, $scope, notificationService, $state,commonService) {
        $scope.topic = {
            CreatedDate: new Date(),
            Status: true
        }

        $scope.AddTopic = AddTopic;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.topic.Seo = commonService.getSeoTitle($scope.topic.Name);
        }

        function AddTopic() {
            apiService.post('/api/topic/create', $scope.topic, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được thêm mới.');
                $state.go('topic');
            },
                function (error) {
                    notificationService.displayError('Thêm mới không thành công: ' + error);
                });
        }

        function loadTopicParent() {
            apiService.get('/api/topic/getallparents', null, function (result) {
                $scope.topicParents = result.data;
            }, function () {
                console.log('Cannot get list topic parent');
            })
        }
        loadTopicParent();
    }

})(angular.module('luyenthi.topic'));