(function () {
    angular.module('luyenthi.question', ['luyenthi.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("question", {
            url: "/question",
            templateUrl: "/app/components/question/questionListView.html",
            controller: "questionListController"
        }).state("add_question", {
            url: "/add_question",
            templateUrl: "/app/components/question/questionAddView.html",
            controller: "questionAddController"
        }).state("edit_question", {
            url: "/edit_question/:id",
            templateUrl: "/app/components/question/questionEditView.html",
            controller: "questionEditController"
        });
    }
})();