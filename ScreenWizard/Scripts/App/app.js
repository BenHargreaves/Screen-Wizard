(function () {

    var ScreenWizard = angular.module('ScreenWizard', ['ngRoute', 'ngMessages']);
    
    ScreenWizard.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider){
        
        $locationProvider.html5Mode(true);

        $routeProvider
            .when("/", {
                templateUrl: "/Views/main.html",
                controller: "MainCtrl"
            })
            .when("/List", {
                templateUrl: "/Views/ListScreen.html",
                controller: "ListCtrl"

            })
            .when("/Edit", {
                templateUrl: "/Views/EditScreen.html",
                controller: "EditCtrl"

            })
            .when("/ExistingScreens", {
                templateUrl: "/Views/ExistingScreens.html",
                controller: "ExistingScreenCtrl"
            })
            .when("/TableSelect", {
                templateUrl: "/Views/TableSelect.html",
                controller: "TableSelectCtrl"
            })
            .when("/FieldSelect", {
                templateUrl: "/Views/FieldSelect.html",
                controller: "FieldSelectCtrl"
            })
            .when("/GeneratedEditScreen", {
                templateUrl: "/Views/GeneratedEditScreen.html",
                controller: "GeneratedEditScreenCtrl"
            })

            .otherwise({redirectTo: "/"})

    }]);
})();