(function () {
    angular.module('luyenthi.cauhoi', ['luyenthi.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("cauhoi", {
            url: "/cauhoi",
            templateUrl: "/app/components/cauhoi/cauhoiListView.html",
            controller: "cauhoiListController"
        }).state("add_cauhoi", {
            url: "/add_cauhoi",
            templateUrl: "/app/components/cauhoi/cauhoiAddView.html",
            controller: "cauhoiAddController"
        }).state("edit_cauhoi", {
            url: "/edit_cauhoi/:id",
            templateUrl: "/app/components/cauhoi/cauhoiEditView.html",
            controller: "cauhoiEditController"
        });
    }
})();