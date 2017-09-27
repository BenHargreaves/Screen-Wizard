(function () {


    angular.module('ScreenWizard')

        .controller('ExistingScreenCtrl', function ($scope, $http, $location, FieldService) {
            $http.get("http://localhost:52440/api/screen")
                .then(function (response) {
                    $scope.screens = response.data
                });

            $scope.selectScreen = function (screen) {
                FieldService.setScreen(screen);
                var type = screen.ScreenType;
                $location.path("/Generated" + type + "Screen")
            };
        });
    


    
})();
