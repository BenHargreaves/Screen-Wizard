(function () {

    var ScreenWizard = angular.module('ScreenWizard', ["ngRoute"]);
    
    ScreenWizard.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider){
        
        $locationProvider.html5Mode(true);

        $routeProvider
            .when("/", {
                templateUrl: "Views/main.html",
                controller: "MainCtrl"
            })
            .when("/list", {
                templateUrl: "Views/ListScreen.html",
                controller: "ListCtrl"

            })
            .when("/edit", {
                templateUrl: "Views/EditScreen.html",
                controller: "EditCtrl"

            })
            .otherwise({redirectTo: "/"})

    }]);
  ScreenWizard.controller("MainCtrl", function(){
    return true;
    });

  ScreenWizard.controller("ListCtrl", function(){
    return true;
    });

  ScreenWizard.controller("EditCtrl", function(){
    return true;
    });
})();