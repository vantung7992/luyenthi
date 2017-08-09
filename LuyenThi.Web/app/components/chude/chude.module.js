/// <reference path="D:\CONG VIEC\MY WORK\my project\Luyenthi\LuyenThi.Web\Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module("luyenthi.chude", ["luyenthi.common"]).config(config);
    config.$inject = ["$stateProvider", "$urlRouterProvider"];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state("chude", {
            url: "/chude",
            templateUrl: "/app/components/chude/chudeListView.html",
            controller: "chudeListController"
        }).state("add_chude", {
            url: "/add_chude",
            templateUrl: "/app/components/chude/chudeAddView.html",
            controller: "chudeAddController"
        }).state("edit_chude", {
            url: "/edit_chude/:id",
            templateUrl: "/app/components/chude/chudeEditView.html",
            controller: "chudeEditController"
        });
    }
})();