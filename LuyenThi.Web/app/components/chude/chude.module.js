/// <reference path="D:\CONG VIEC\MY WORK\my project\Luyenthi\LuyenThi.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module("luyenthi.chude", ["luyenthi.common"]).config(config);
    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("chude", {
            url: "/chude",
            templateUrl: "/app/components/chude/chudeListView.html",
            controller: "chudeListController"
        }).state("chude_add", {
            url: "/chude_add",
            templateUrl: "/app/components/chude/chudeAddView.html",
            controller: "chudeAddController"
        });
    }
})();