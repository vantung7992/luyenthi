(function () {
    angular.module('luyenthi.cauhoi', ['luyenthi.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("cauhoi", {
            url: "/cauhoi",
            templateUrl: "/app/components/cauhoi/cauhoiListView.html",
            controller: "cauhoiListController"
        });
    }
})();