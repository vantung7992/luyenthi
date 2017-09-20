/// <reference path="D:\CONG VIEC\MY WORK\my project\Luyenthi\LuyenThi.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module("luyenthi.topic", ["luyenthi.common"]).config(config);
    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("topic", {
            url: "/topic",
            templateUrl: "/app/components/topic/topicListView.html",
            controller: "TopicListController"
        }).state("add_topic", {
            url: "/add_topic",
            templateUrl: "/app/components/topic/topicAddView.html",
            controller: "topicAddController"
        }).state("edit_topic", {
            url: "/edit_topic/:id",
            templateUrl: "/app/components/topic/topicEditView.html",
            controller: "topicEditController"
        });
    }
})();