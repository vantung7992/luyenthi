(function () {
    angular.module('luyenthi.exam', ['luyenthi.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("exam", {
            url: "/exam",
            templateUrl: "/app/components/exam/examListView.html",
            controller: "examListController"
        }).state("add_exam", {
            url: "/add_exam",
            templateUrl: "/app/components/exam/examAddView.html",
            controller: "examAddController"
        }).state("edit_exam", {
            url: "/edit_exam/:id",
            templateUrl: "/app/components/exam/examEditView.html",
            controller: "examEditController"
        });
    }
})();