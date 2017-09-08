(function () {
    angular.module('luyenthi.dethi', ['luyenthi.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("dethi", {
            url: "/dethi",
            templateUrl: "/app/components/dethi/dethiListView.html",
            controller: "dethiListController"
        }).state("add_dethi", {
            url: "/add_dethi",
            templateUrl: "/app/components/dethi/dethiAddView.html",
            controller: "dethiAddController"
        });
    }
})();