(function (app) {
    app.controller('topicAddController', topicAddController);

    topicAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function topicAddController(apiService, $scope, notificationService, $state,commonService) {
        $scope.topic = {
            CreatedDate: new Date(),
            Status: true,
            HotFlag: false,
            HomeFlag:false
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
        loadTopicParent();
    }
})(angular.module('luyenthi.topic'));